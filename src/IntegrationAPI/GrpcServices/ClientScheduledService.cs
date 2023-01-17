using Grpc.Core;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using System.Timers;
using Blood;
using HospitalAPI.Connections;
using IntegrationAPI.ConnectionService.Interface;
using IntegrationAPI.GrpcServices;
using IntegrationLibrary.Core.Service.Interfaces;
using IntegrationLibraryAPI.Connections;
using BloodDTO = IntegrationLibrary.Core.Model.DTO.BloodDTO;
using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Core.Repository.Interfaces;
using IntegrationAPI.Mapper;
using BloodUnit = Blood.BloodUnit;
using BloodUnitRequest = Blood.BloodUnitRequest;

namespace IntegrationAPI
{
    public class ClientScheduledService : IClientScheduledService
    {
        private System.Timers.Timer timer;
        private Channel channel;
        //private Blood client;
        private IBloodService _bloodService;
        private IHospitalHTTPConnectionService _hospitalHTTPConnectionService;
        private readonly IHospitalHTTPConnection _hospitalHttpConnection;
        private  IBloodBankService _bloodBankService;
        private  IUrgentRequestRepository _urgentRequestRepository;

        public ClientScheduledService(IBloodService bloodService, 
                                      IHospitalHTTPConnectionService hospitalHTTPConnectionService,
                                      IHospitalHTTPConnection hospitalHttpConnection,
                                      IServiceScopeFactory factory) 
        {
            _hospitalHTTPConnectionService = hospitalHTTPConnectionService;
            _bloodService = bloodService;
            _hospitalHttpConnection = hospitalHttpConnection;
            _bloodBankService = factory.CreateScope().ServiceProvider.GetRequiredService<IBloodBankService>();
            _urgentRequestRepository = factory.CreateScope().ServiceProvider.GetRequiredService<IUrgentRequestRepository>();
        }

        public async Task communicate(string apiKey)
        {
            channel = new Channel("127.0.0.1:8787", ChannelCredentials.Insecure);
            var client = new BloodProvider.BloodProviderClient(channel);
            List<BloodDTO> storageList = _bloodService.GetMissingQuantities(_hospitalHTTPConnectionService.GetAllBlood());
            List<BloodUnit> bloodUnitsProto = new List<BloodUnit>();
            foreach (BloodDTO bloodUnit in storageList)
            {
                BloodUnit bu = new BloodUnit();
                bu.BloodType = ConvertBloodTypeToBloodTypeEnum(bloodUnit.Type);
                bu.Quantity = bloodUnit.Quantity;
                bloodUnitsProto.Add(bu);
            }

            try
            {
                BloodResponse response = await client.communicateAsync(new BloodUnitRequest() { BankBankApiKey = apiKey, BloodUnits = { bloodUnitsProto } });
                if (response.Status == RequestResponseStatus.BloodAvailable)
                {
                    UrgentRequest urgRequest = new UrgentRequest(_bloodBankService.GetByApiKey(apiKey).Id, DateTime.Now, TenderOfferMapper.BloodDtoToBloodAmount(storageList));
                    _urgentRequestRepository.SaveUrgentRequest(urgRequest);
                    _hospitalHttpConnection.RestockBlood(storageList);
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.StackTrace);
            }
           
        }

        public BloodTypeEnum ConvertBloodTypeToBloodTypeEnum(string bloodType)
        {
            BloodTypeEnum forReturn = new BloodTypeEnum();
            if (bloodType == "ZERO_POSITIVE")
            {
                forReturn = BloodTypeEnum.OPos;
            } else if (bloodType == "ZERO_NEGATIVE")
            {
                forReturn = BloodTypeEnum.ONeg;
            }
            else if (bloodType == "A_POSITIVE")
            {
                forReturn = BloodTypeEnum.APos;
            }
            else if (bloodType == "A_NEGATIVE")
            {
                forReturn = BloodTypeEnum.ANeg;
            }
            else if (bloodType == "B_POSITIVE")
            {
                forReturn = BloodTypeEnum.BPos;
            }
            else if (bloodType == "B_NEGATIVE")
            {
                forReturn = BloodTypeEnum.BNeg;
            }
            else if (bloodType == "AB_POSITIVE")
            {
                forReturn = BloodTypeEnum.AbPos;
            }
            else if (bloodType == "AB_NEGATIVE")
            {
                forReturn = BloodTypeEnum.AbNeg;
            }

            return forReturn;
        }

    }
}
