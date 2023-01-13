namespace HospitalLibrary.Core.Model.Aggregates.RenovationScheduling.Events
{
    public class SessionStarted : DomainEvent
    {
        public SessionStarted(DateTime timestamp) : base(timestamp)
        {
        }
    }
}
