namespace HospitalLibrary.Core.Model.Aggregates.RenovationScheduling.Events
{
    public class RenovationTypeSelected : DomainEvent
    {
        public RenovationTypeSelected(int aggregateId) : base(aggregateId)
        {
        }
    }
}
