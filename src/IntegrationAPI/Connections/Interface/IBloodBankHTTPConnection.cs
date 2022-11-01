using IntegrationLibrary.Core.Model;
using RestSharp;

namespace IntegrationAPI.Connections.Interface
{
    public interface IBloodBankHTTPConnection
    {
        public bool CheckForSpecificBloodType(BloodBank bloodBank, string bloodType);
        public bool CheckBloodAmount(string api, string bloodType, double quant);
    }
}
