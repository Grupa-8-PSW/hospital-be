using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegrationLibrary.Core.Model.ValueObject;

namespace IntegrationLibrary.Core.Model
{
    public class MonthlySubscription
    {

        public int Id { get; private set; }
        public List<Blood> RequestedBlood { get; private set; }
        public DateTime DeliveryDate { get; private set; }
        public BloodBank Bank { get; private set; }
        public int BankId { get; private set; }
        public SubscriptionStatus Status { get; private set; }

        public MonthlySubscription()
        {
                
        }

        public MonthlySubscription(int id, List<Blood> requestedBlood, DateTime deliveryDate, BloodBank bank, int bankId, SubscriptionStatus status)
        {
            Id = id;
            RequestedBlood = requestedBlood;
            DeliveryDate = deliveryDate;
            Bank = bank;
            BankId = bankId;
            Status = status;
        }

        internal void ChangeStatus(SubscriptionStatus status)
        {
            this.Status = status;
        }

        public void AddBank(BloodBank bloodBank)
        {
            this.Bank = bloodBank;
        }

        public void SetNextDeliveryDate()
        {
            this.DeliveryDate = this.DeliveryDate.AddMonths(1);
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((MonthlySubscription)obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, (int)Status, RequestedBlood, DeliveryDate, Bank,
                                    BankId, Status);
        }
    }
}
