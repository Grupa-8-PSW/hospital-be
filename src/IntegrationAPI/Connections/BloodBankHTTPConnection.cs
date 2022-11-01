using IntegrationAPI.Connections.Interface;
using IntegrationLibrary.Core.Model;
using Microsoft.AspNetCore.Mvc;
using IntegrationLibrary.Persistence.Migrations;
using RestSharp;
using System.Data;
using System.Net;
using System.Text.Json;
using IntegrationAPI.ExceptionHandler.Validators;

namespace IntegrationAPI.Connections
{
    public class BloodBankHTTPConnection : IBloodBankHTTPConnection
    {
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
    }
}
