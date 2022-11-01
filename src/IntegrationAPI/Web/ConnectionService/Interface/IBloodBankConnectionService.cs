using RestSharp;

namespace IntegrationAPI.Web.ConnectionService.Interface
{
    public interface IBloodBankConnectionService
    {
        public bool BloodQuantityExists(double quantity);
        Task<RestResponse> CheckForSpecificBloodTypeAmount(string bankName, string bloodType, double quantity);
    }
}
