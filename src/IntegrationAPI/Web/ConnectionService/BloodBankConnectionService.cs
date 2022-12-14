using IntegrationAPI.Web.Connection.HTTPConnection;
using IntegrationAPI.Web.Connection.HTTPConnection.Interface;
using IntegrationAPI.Web.ConnectionService.Interface;

namespace IntegrationAPI.Web.ConnectionService
{
    public class BloodBankConnectionService : IBloodBankConnectionService
    {
        private IBloodBankHTTPConnection bloodBankHTTPConnection;

        public BloodBankConnectionService(IBloodBankHTTPConnection bloodBankHTTPConnection)
        {
            this.bloodBankHTTPConnection = bloodBankHTTPConnection;
        }

        public bool BloodQuantityExists(double quantity)
        {
            return bloodBankHTTPConnection.BloodQuantityExists(quantity);
        }
    }
}
