
using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Core.Model.DTO;
using RestSharp;

namespace IntegrationAPI.Connections.Interface
{
    public interface IBloodBankHTTPConnection
    {
        public bool CheckForSpecificBloodType(BloodBank bloodBank, string bloodType);
        public bool CheckBloodAmount(string api, string bloodType, double quant);

        public bool SendUrgentRequest(BloodUnitUrgentRequest bloodUnit);
    }
}
