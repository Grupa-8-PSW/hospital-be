﻿using IntegrationAPI.Connections.Interface;
using IntegrationLibrary.Core.Model;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System.Data;
using System.Net;
using System.Text.Json;
using System.Timers;
using Firebase.Auth;
using Firebase.Storage;
using IntegrationAPI.ExceptionHandler.Validators;
using IntegrationLibrary.Core.Service;
using IntegrationLibrary.Core.Service.Interfaces;
using HospitalLibrary.Core.Enums;
using IntegrationAPI.ConnectionService.Interface;
using Microsoft.Extensions.DependencyInjection;
using HospitalAPI.Connections;
using HospitalAPI.DTO;
using IntegrationLibrary.Core.Model.DTO;
using IntegrationLibraryAPI.Connections;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;
using IntegrationAPI.ExceptionHandler.Exceptions;
using IntegrationAPI.Middlewares;
using IntegrationAPI.Mapper;
using IntegrationLibrary.Core.Repository.Interfaces;

namespace IntegrationAPI.Connections
{
    public class BloodBankHTTPConnection : BackgroundService, IBloodBankHTTPConnection
    {

        private readonly IBloodConsumptionConfigurationService _service;
        private readonly IBloodBankService _bankService;
        private readonly IHospitalHTTPConnection _hospitalHttpConnection;
        private readonly IUrgentRequestRepository _urgentRequestRepository;
        private String api = "reports/sendReports";

        public BloodBankHTTPConnection(IServiceScopeFactory factory, IUrgentRequestRepository urgentRequestRepository)
        {
            _service = factory.CreateScope().ServiceProvider
                .GetRequiredService<IBloodConsumptionConfigurationService>();

            _bankService = factory.CreateScope().ServiceProvider.GetRequiredService<IBloodBankService>();

            _hospitalHttpConnection = factory.CreateScope().ServiceProvider.GetRequiredService<IHospitalHTTPConnection>();

            _urgentRequestRepository = factory.CreateScope().ServiceProvider.GetRequiredService<IUrgentRequestRepository>();
        }

        public bool CheckForSpecificBloodType(BloodBank bloodBank, string bloodType)
        {
            RestClient restClient = BloodBankConnectionValidator.ValidateURL(bloodBank.ServerAddress + "/bloodBanks/checkForBloodType");
            RestRequest request = new RestRequest();
            request.AddParameter("type", bloodType);
            request.AddHeader("apiKey", bloodBank.APIKey);
            RestResponse res = BloodBankConnectionValidator.Authenticate(restClient, request);
            return JsonSerializer.Deserialize<bool>(res.Content);
        }

        public bool CheckBloodAmount(string api, string bloodType, double quant)
        {
            RestClient restClient = BloodBankConnectionValidator.ValidateURL("http://localhost:8081/" + "bloodBanks/checkBloodAmount");
            RestRequest request = new RestRequest();
            request.AddParameter("bloodType", bloodType);
            request.AddParameter("quantity", quant);
            request.AddHeader("apiKey", api);
            RestResponse res = BloodBankConnectionValidator.Authenticate(restClient, request);
            return JsonSerializer.Deserialize<bool>(Boolean.Parse(res.Content));
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            TimeSpan delay = TimeSpan.Zero;
            do
            {
                DateTime now = DateTime.Now;
                BloodConsumptionConfiguration bcc = _service.FindActiveConfiguration();
                if (bcc == null)
                {
                    delay = TimeSpan.FromSeconds(5);
                    Console.WriteLine("No configs found in DB..");
                }
                else
                {
                    delay = await CheckIfServerCrashed(now, bcc, delay);

                    delay = CreateInitialDelay(now, bcc, delay);

                    delay = CheckIfStartTime(now, bcc, delay);

                    delay = await SendToBanks(now, bcc, delay);
                }

                await Task.Delay(delay, stoppingToken);

            }
            while (!stoppingToken.IsCancellationRequested);
        }


        public async Task<TimeSpan> SendToBanks(DateTime now, BloodConsumptionConfiguration bcc, TimeSpan delay)
        {
            if (now.Hour == bcc.NextSendingTime.Hour && now.Minute == bcc.NextSendingTime.Minute)
            {
                Guid uniqueSuffix = Guid.NewGuid();
                //var scopedService = scope.ServiceProvider.GetRequiredService<IBloodBankHTTPConnection>();
                byte[] file = _service.GeneratePdf(bcc, _service.FindValidBloodUnits(_hospitalHttpConnection.GetAllBloodUnits(), out var configuration));
                using (var stream = File.Create("./Reports/bloodConsumptionReport" + uniqueSuffix + ".PDF"))
                {
                }

                await File.WriteAllBytesAsync("./Reports/bloodConsumptionReport" + uniqueSuffix + ".PDF", file);
                SendUrlToBloodBanks(await Upload(uniqueSuffix));
                bcc.NextSendingTime = bcc.NextSendingTime + TimeSpan.FromSeconds(10);
                bcc.NextSendingTime = DateTime.SpecifyKind(bcc.NextSendingTime, DateTimeKind.Utc);
                _service.Update(bcc);
                return TimeSpan.FromSeconds(10);
            }

            return delay;
        }

        private TimeSpan CheckIfStartTime(DateTime now, BloodConsumptionConfiguration bcc, TimeSpan delay)
        {
            if (now.Hour == bcc.StartDateTime.Hour && now.Minute == bcc.StartDateTime.Minute)
            {
                Console.WriteLine("Starting of report sending..");
                bcc.NextSendingTime = bcc.StartDateTime + TimeSpan.FromSeconds(10);
                bcc.NextSendingTime = DateTime.SpecifyKind(bcc.NextSendingTime, DateTimeKind.Utc);
                _service.Update(bcc);
                delay = TimeSpan.FromSeconds(10);
            }

            return delay;
        }

        private static TimeSpan CreateInitialDelay(DateTime now, BloodConsumptionConfiguration bcc, TimeSpan delay)
        {
            if (now < bcc.StartDateTime)
            {
                delay = bcc.StartDateTime - now;
            }

            return delay;
        }

        private async Task<TimeSpan> CheckIfServerCrashed(DateTime now, BloodConsumptionConfiguration bcc, TimeSpan delay)
        {
            if (now > bcc.NextSendingTime)
            {
                bcc.NextSendingTime = bcc.NextSendingTime + bcc.FrequencyPeriodInHours;
                bcc.NextSendingTime = DateTime.SpecifyKind(bcc.NextSendingTime, DateTimeKind.Utc);
                _service.Update(bcc);
                Guid uniqueSuffix = Guid.NewGuid();
                byte[] file = _service.GeneratePdf(bcc, _service.FindValidBloodUnits(_hospitalHttpConnection.GetAllBloodUnits(), out var configuration));
                using (var stream = File.Create("./Reports/bloodConsumptionReport" + uniqueSuffix + ".PDF"))
                {
                }
                await File.WriteAllBytesAsync("./Reports/bloodConsumptionReport" + uniqueSuffix + ".PDF", file);
                SendUrlToBloodBanks(await Upload(uniqueSuffix));
                return TimeSpan.FromSeconds(10);
            }

            return delay;
        }

        private void SendUrlToBloodBanks(string url)
        {
            var bloodBanks = _bankService.GetAll();
            foreach (var bloodBank in bloodBanks)
            {
                RestClient restClient = BloodBankConnectionValidator.ValidateURL(bloodBank.ServerAddress + api);
                RestRequest request = new RestRequest();
                request.AddParameter("url", url);
                request.AddHeader("apiKey", bloodBank.APIKey);
                try
                {
                    RestResponse res = BloodBankConnectionValidator.Authenticate(restClient, request);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        public async void SendUrgentRequest(BloodUnitUrgentRequest urgentRequest, String status)
        {
            var client = new RestClient("http://localhost:8081");
            var request = new RestRequest("/bloodBanks/urgentRequest", Method.Post);

            request.AddHeader("apiKey", urgentRequest.APIKey);
            request.AddJsonBody(urgentRequest);
            RestResponse res = new RestResponse();
            try
            {
                res = await client.ExecuteAsync(request);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            bool hasEnoughBlood = JsonSerializer.Deserialize<bool>(Boolean.Parse(res.Content));

            if (!hasEnoughBlood)
                Console.WriteLine("The blood bank does not have enough blood !");
            else if (status == "URGENT")
            {
                UrgentRequest urgRequest = new UrgentRequest(_bankService.GetByApiKey(urgentRequest.APIKey).Id, DateTime.Now, TenderOfferMapper.BloodDtoToBloodAmount(urgentRequest.bloodUnits));
                _urgentRequestRepository.SaveUrgentRequest(urgRequest);

                _hospitalHttpConnection.RestockBlood(urgentRequest.bloodUnits);
            } else
                _hospitalHttpConnection.RestockBlood(urgentRequest.bloodUnits);
        }


        private async Task<string> Upload(Guid g)
        {
            // Get any Stream - it can be FileStream, MemoryStream or any other type of Stream
            var stream = File.Open(@"./Reports/bloodConsumptionReport" + g + ".pdf", FileMode.Open);

            //authentication
            var auth = new FirebaseAuthProvider(new FirebaseConfig("AIzaSyAQTVZHRWBwsKNe7VVV7X5uCOqyb33MEUA"));
            var a = await auth.SignInWithEmailAndPasswordAsync("asdf@gmail.com", "asdf123");

            // Constructr FirebaseStorage, path to where you want to upload the file and Put it there
            var task = new FirebaseStorage(
                "isapsw-6ef61.appspot.com",
                new FirebaseStorageOptions
                {
                    AuthTokenAsyncFactory = () => Task.FromResult(a.FirebaseToken),
                    ThrowOnCancel = true,
                })
                .Child("reports")
                .Child("bloodConsumptionReport" + g + ".pdf")
                .PutAsync(stream);

            // Track progress of the upload
            task.Progress.ProgressChanged += (s, e) => Console.WriteLine($"Progress: {e.Percentage} %");

            // await the task to wait until upload completes and get the download url
            var downloadUrl = await task;
            stream.Close();
            return downloadUrl;
        }
    }
}