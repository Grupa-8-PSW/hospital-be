namespace HospitalLibrary.Core.Model.Aggregates.RenovationScheduling.Events
{
    public class RenovationTypeSelected : DomainEvent
    {
        public RenovationTypeSelected(DateTime timestamp) : base(timestamp)
        {
        }
    }
}
