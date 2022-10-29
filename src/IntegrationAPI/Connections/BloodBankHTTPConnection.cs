using IntegrationAPI.Connections.Interface;
using IntegrationLibrary.Core.Model;
using RestSharp;
using System.Data;
using System.Text.Json;

namespace IntegrationAPI.Connections
{
    public class BloodBankHTTPConnection : IBloodBankHTTPConnection
    {
        public bool CheckForSpecificBloodType(BloodBank bloodBank, string bloodType)
        {
            RestClient restClient = new RestClient(bloodBank.ServerAddress +  "bloodBanks/checkForBloodType");
            RestRequest request = new RestRequest();
            request.AddParameter("type", bloodType);
            request.AddHeader("apiKey", "1");
            var data = restClient.Get(request);
            var a = data.StatusCode;
            var b = data.Content;
            return JsonSerializer.Deserialize<bool>(Boolean.Parse(b));
        }

        public Task<RestResponse> CheckForSpecificBloodTypeAmount(string bankName, string bloodType, double quantity)
        {
            throw new NotImplementedException();
        }
    }
}
