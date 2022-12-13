using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Core.Model
{
    public class MonthlySubscription
    {
        public int Id { get; set; }
        public List<Blood> RequestedBlood { get; set; }
        public DateTime DeliveryDate { get; set; }
        public BloodBank Bank { get; set; }
        public int BankId { get; set; }
        public SubscriptionStatus Status { get; set; }

        public MonthlySubscription(List<Blood> requestedBlood, DateTime deliveryDate, BloodBank bank, int bankId, SubscriptionStatus status)
        {
            RequestedBlood = requestedBlood;
            DeliveryDate = deliveryDate;
            Bank = bank;
            BankId = bankId;
            Status = status;
        }

        public MonthlySubscription()
        {
                
        }
        
    }
}
