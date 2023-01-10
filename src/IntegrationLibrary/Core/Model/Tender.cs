using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegrationLibrary.Core.Model.ValueObject;
using IntegrationLibrary.Core.Repository.Interfaces;

namespace IntegrationLibrary.Core.Model
{
    public class Tender
    {
        public int Id { get; private set; }
        public TenderStatus Status { get; private set; }
        public DateRange DateRange { get; private set; }
        public List<Blood> Blood { get; private set; }


        public Tender(TenderStatus status, DateRange dateRange, List<Blood> blood)
        {
            Status = status;
            DateRange = dateRange;
            Blood = blood;
        }

        protected bool Equals(Tender other)
        {
            return Id == other.Id && Status == other.Status && DateRange.Equals(other.DateRange) && Blood.Equals(other.Blood);
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Tender)obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, (int)Status, DateRange, Blood);
        }

        public void EndTenderLifeCycle()
        {
            this.Status = TenderStatus.Inactive;
        }
        

    }
}
