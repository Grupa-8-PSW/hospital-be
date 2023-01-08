namespace HospitalLibrary.Core.Model.Aggregates.RenovationScheduling.Events
{
    public class SessionStarted : DomainEvent
    {
        public SessionStarted(int aggregateId) : base(aggregateId)
        {
        }
    }
}
