namespace HospitalLibrary.Core.Model.Aggregates.RenovationScheduling.Events
{
    public class RoomSelected : DomainEvent
    {
        public RoomSelected(DateTime timestamp) : base(timestamp)
        {
        }
    }
}
