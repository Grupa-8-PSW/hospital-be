using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegrationAPI.Connections.Interface;
using IntegrationAPI.ConnectionService.Interface;
using IntegrationLibrary.Core.Model;
using RestSharp;

namespace IntegrationLibrary.Core.Service
{
    public class BloodBankConnectionService : IBloodBankConnectionService
    {
        private IBloodBankHTTPConnection bloodBankHTTPConnection;
        private IBloodBankService bloodBankService;

        public BloodBankConnectionService(IBloodBankHTTPConnection bloodBankHTTPConnection, IBloodBankService bloodBankService)
        {
            this.bloodBankHTTPConnection = bloodBankHTTPConnection;
            this.bloodBankService = bloodBankService;
        }

        public bool CheckForSpecificBloodType(int bloodBankId, string bloodType)
        {
            BloodBank bloodBank = bloodBankService.GetById(bloodBankId);
            return bloodBankHTTPConnection.CheckForSpecificBloodType(bloodBank, bloodType);
        }

        public Task<RestResponse> CheckForSpecificBloodTypeAmount(string bankName, string bloodType, double quantity)
        {
            throw new NotImplementedException();
        }

        public bool CheckBloodAmount(string api, string bloodType, double quant)
        {
            return bloodBankHTTPConnection.CheckBloodAmount(api, bloodType, quant);
        }
    }
}
