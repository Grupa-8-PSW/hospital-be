using IntegrationLibrary.Core.Model.ValueObject;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Core.Model.DTO
{
    public class MonthlySubscriptionDTO
    {

        public int Id { get; set; }
        public List<Blood> RequestedBlood { get; set; }
        public DateTime DeliveryDate { get; set; }
        public BloodBank Bank { get; set; }
        public int BankId { get; set; }
        public SubscriptionStatus Status { get; set; }
        public int BloodCenterId { get; set; }

        public MonthlySubscriptionDTO(List<Blood> requestedBlood, DateTime deliveryDate, int id, BloodBank bank, SubscriptionStatus status, int bankId)
        {
            this.RequestedBlood = requestedBlood;
            this.DeliveryDate = deliveryDate;
            this.Id = id;
            this.Bank = bank;
            this.BankId = bankId;
            this.Status = status;
        }

        [JsonConstructor]
        public MonthlySubscriptionDTO() { }


    }
}
