using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegrationAPI.Connections.Interface;
using IntegrationAPI.ConnectionService;
using IntegrationAPI.ConnectionService.Interface;
using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Core.Model.DTO;
using IntegrationLibrary.Core.Service.Interfaces;
using RestSharp;

namespace IntegrationLibrary.Core.Service
{
    public class BloodBankConnectionService : IBloodBankConnectionService
    {
        private IBloodBankHTTPConnection bloodBankHTTPConnection;
        private IBloodBankService bloodBankService;
        private readonly IBloodService _bloodService;
        private readonly IHospitalHTTPConnectionService _hospitalHTTPConnectionService;
        public BloodBankConnectionService(IBloodBankHTTPConnection bloodBankHTTPConnection, 
                                          IBloodBankService bloodBankService,
                                          IBloodService bloodService,
                                          IHospitalHTTPConnectionService hospitalHttpConnectionService)
        {
            this.bloodBankHTTPConnection = bloodBankHTTPConnection;
            this.bloodBankService = bloodBankService;
            this._bloodService = bloodService;
            this._hospitalHTTPConnectionService = hospitalHttpConnectionService;
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

        public bool CheckBloodAmount(int id, string bloodType, double quant)
        {
            BloodBank bloodBank = bloodBankService.GetById(id);
            return bloodBankHTTPConnection.CheckBloodAmount(bloodBank.APIKey, bloodType, quant);
        }


        public bool SendUrgentRequest(string apiKey)
        {
            BloodUnitUrgentRequest request = new BloodUnitUrgentRequest();
            request.bloodUnits = _bloodService.GetMissingQuantities(_hospitalHTTPConnectionService.GetAllBlood());
            request.APIKey = apiKey;
            bloodBankHTTPConnection.SendUrgentRequest(request);
            return true;
        }
    }
}
