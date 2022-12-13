using IntegrationLibrary.Core.Model;
using Org.BouncyCastle.Asn1.Cmp;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegrationLibrary.Core.Model.DTO;


namespace IntegrationAPI.ConnectionService.Interface
{
    public interface IBloodBankConnectionService
    {
        public bool CheckForSpecificBloodType(int bloodBankId, string bloodType);
        Task<RestResponse> CheckForSpecificBloodTypeAmount(string bankName, string bloodType, double quantity);

        public bool CheckBloodAmount(int id, string bloodType, double quant);

        public bool SendUrgentRequest(string apiKey);
        public bool SendTenderOffer(string apiKey, int tenderID);

        public void SendMonthlySubscriptionOffer(MonthlySubscriptionDTO monthlySubscriptionDTO);

    }
}
