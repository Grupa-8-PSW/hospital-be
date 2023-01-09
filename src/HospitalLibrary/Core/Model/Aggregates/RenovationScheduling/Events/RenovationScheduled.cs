namespace HospitalLibrary.Core.Model.Aggregates.RenovationScheduling.Events
{
    public class RenovationScheduled : DomainEvent
    {
        public RenovationScheduled(int aggregateId) : base(aggregateId)
        {
        }
    }
}
