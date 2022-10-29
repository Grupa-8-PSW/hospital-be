using IntegrationLibrary.Core.Model;
using RestSharp;

namespace IntegrationAPI.Connections.Interface
{
    public interface IBloodBankHTTPConnection
    {
        public bool CheckForSpecificBloodType(BloodBank bloodBank, string bloodType);
        Task<RestResponse> CheckForSpecificBloodTypeAmount(string bankName, string bloodType, double quantity);
    }
}
