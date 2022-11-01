using IntegrationAPI.Web.Connection.HTTPConnection.Interface;
using Microsoft.OpenApi.Models;
using RestSharp;
using System.Text.Json;
using System.Xml.Linq;


namespace IntegrationAPI.Web.Connection.HTTPConnection
{
    public class BloodBankHTTPConnection : IBloodBankHTTPConnection
    {
        public bool BloodQuantityExists(double quantity)
        {
            RestClient restClient = new RestClient("http://localhost:8081/bloodBanks/check");
            RestRequest request = new RestRequest();
            request.AddParameter("quantity", 12);
            request.AddParameter("type", "Apos");
            var data = restClient.Get<bool>(request);
            return JsonSerializer.Deserialize<bool>(data);
        }

        public Task<RestResponse> CheckForSpecificBloodTypeAmount(string bankName, string bloodType, double quantity)
        {
            var client = new RestClient("https://localhost:8081/bloodBanks/check/");
            var request = new RestRequest("checkBlood", Method.Get);
            request.AddParameter("bankName", bankName);
            request.AddParameter("bloodType", bloodType);
            request.AddParameter("quantity", quantity);
            var response = client.GetAsync(request);
            return response;
        }
    }
}
