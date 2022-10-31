using IntegrationAPI.Connections.Interface;
using IntegrationLibrary.Core.Model;
using Microsoft.AspNetCore.Mvc;
using IntegrationLibrary.Persistence.Migrations;
using RestSharp;
using System.Data;
using System.Net;
using System.Text.Json;

namespace IntegrationAPI.Connections
{
    public class BloodBankHTTPConnection : IBloodBankHTTPConnection
    {
        public bool CheckForSpecificBloodType(BloodBank bloodBank, string bloodType) 
        {
            RestClient restClient = new RestClient("http://localhost:8081/" +  "bloodBanks/checkForBloodType");
            RestRequest request = new RestRequest();
            request.AddParameter("type", bloodType);
            request.AddHeader("apiKey", bloodBank.APIKey);
            RestResponse res = new();
            res = restClient.Get(request);
            return JsonSerializer.Deserialize<bool>(res.Content);
        }

        public Task<RestResponse> CheckForSpecificBloodTypeAmount(string bankName, string bloodType, double quantity)
        {
            throw new NotImplementedException();
        }

        public bool CheckBloodAmount(string api, string bloodType, double quant)
        {
            RestClient restClient = new RestClient("http://localhost:8081/" + "bloodBanks/checkBloodAmount");
            RestRequest request = new RestRequest();
            request.AddParameter("bloodType", bloodType);
            request.AddParameter("quantity", quant);
            request.AddHeader("apiKey", api);
            var data = restClient.Get(request);
            var a = data.StatusCode;
            var b = data.Content;
            return JsonSerializer.Deserialize<bool>(Boolean.Parse(b));
        }
    }
}
