namespace HospitalLibrary.Core.Model.Aggregates.RenovationScheduling.Events
{
    public class DurationSelected : DomainEvent
    {
        public DurationSelected(DateTime timestamp) : base(timestamp)
        {
        }
    }
}
