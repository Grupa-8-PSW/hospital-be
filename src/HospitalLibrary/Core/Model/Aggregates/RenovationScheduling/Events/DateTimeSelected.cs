namespace HospitalLibrary.Core.Model.Aggregates.RenovationScheduling.Events
{
    public class DateTimeSelected : DomainEvent
    {
        public DateTimeSelected(DateTime timestamp) : base(timestamp)
        {
        }
    }
}
