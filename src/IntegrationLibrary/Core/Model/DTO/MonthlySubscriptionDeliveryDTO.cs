using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Core.Model.DTO
{
    public class MonthlySubscriptionDeliveryDTO
    {
        public int hospitalSubscriptionId;
        public bool delivered;

        public MonthlySubscriptionDeliveryDTO()
        {
        }

        public MonthlySubscriptionDeliveryDTO(int hospitalSubscriptionId, bool delivered)
        {
            this.hospitalSubscriptionId = hospitalSubscriptionId;
            this.delivered = delivered;
        }
    }
}
