using Org.BouncyCastle.Asn1.Mozilla;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Core.Model.DTO
{
    public class MonthlySubscriptionMessageDTO
    {

        public List<BloodDTO> RequestedBlood { get; set; }
        public int HospitalSubscriptionId { get; set; }
        public string DeliveryDate { get; set; }
        public string BloodBankAPIKey { get; set; }
        public int BloodCenterId { get; set; }

        public MonthlySubscriptionMessageDTO()
        {

        }
    }

}
