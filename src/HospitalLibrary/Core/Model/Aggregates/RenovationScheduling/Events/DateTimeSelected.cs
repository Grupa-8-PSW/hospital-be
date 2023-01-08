namespace HospitalLibrary.Core.Model.Aggregates.RenovationScheduling.Events
{
    public class DateTimeSelected : DomainEvent
    {
        public DateTimeSelected(int aggregateId) : base(aggregateId)
        {
        }
    }
}
