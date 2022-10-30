using IntegrationAPI.Connections.Interface;
using IntegrationLibrary.Core.Model;
using Microsoft.AspNetCore.Mvc;
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
            RestClient restClient = new RestClient(bloodBank.ServerAddress +  "/bloodBanks/checkForBloodType");
            RestRequest request = new RestRequest();
            request.AddParameter("type", bloodType);
            request.AddHeader("apiKey", "2");
            RestResponse res = new();
            try {
                res = restClient.Get(request);
            }catch (HttpRequestException ex)
            {
                if (ex.StatusCode == HttpStatusCode.Unauthorized)
                { 
                }
            }
            return Boolean.Parse(res.Content);
        }

        public Task<RestResponse> CheckForSpecificBloodTypeAmount(string bankName, string bloodType, double quantity)
        {
            throw new NotImplementedException();
        }
    }
}
