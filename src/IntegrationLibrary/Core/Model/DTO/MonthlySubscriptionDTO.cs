using Org.BouncyCastle.Asn1.Mozilla;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Core.Model.DTO
{
    public class MonthlySubscriptionDTO
    {

        public List<BloodDTO> RequestedBlood { get; set; }
        public string HospitalSubscriptionId { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string BloodBankAPIKey { get; set; }

        public MonthlySubscriptionDTO()
        {

        }
    }

}
