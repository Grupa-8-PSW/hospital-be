using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegrationAPI.Connections.Interface;
using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Core.Service.Interface;
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
    }
}
