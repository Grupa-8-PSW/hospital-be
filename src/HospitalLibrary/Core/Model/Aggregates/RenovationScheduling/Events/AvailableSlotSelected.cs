namespace HospitalLibrary.Core.Model.Aggregates.RenovationScheduling.Events
{
    public class AvailableSlotSelected : DomainEvent
    {
        public AvailableSlotSelected(DateTime timestamp) : base(timestamp)
        {
        }
    }
}
