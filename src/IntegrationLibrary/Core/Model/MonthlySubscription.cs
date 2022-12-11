using System;
using System.Collections.Generic;
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
        public SubscriptionStatus Status { get; set; }
    }
}
