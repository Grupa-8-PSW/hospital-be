namespace HospitalLibrary.Core.Model.Aggregates.RenovationScheduling.Events
{
    public class RoomSelected : DomainEvent
    {
        public RoomSelected(int aggregateId) : base(aggregateId)
        {
        }
    }
}
