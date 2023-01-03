using HospitalLibrary.Core.Model.ValueObjects;

namespace HospitalLibrary.Core.Model.Aggregates.RenovationScheduling.Events
{
    public class RenovationScheduled : DomainEvent
    {
        public RenovationScheduled(int aggregateId, DateRange dateRange)
            : base(aggregateId)
        {
            DateRange = dateRange;
        }

        public DateRange DateRange { get; private set; }
    }
}
