namespace HospitalLibrary.Core.Model.Aggregates.RenovationScheduling.Events
{
    public class AvailableSlotSelected : DomainEvent
    {
        public AvailableSlotSelected(int aggregateId) : base(aggregateId)
        {
        }
    }
}
