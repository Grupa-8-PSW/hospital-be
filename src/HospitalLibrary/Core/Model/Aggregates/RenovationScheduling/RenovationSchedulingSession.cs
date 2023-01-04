using HospitalLibrary.Core.Model.Aggregates.RenovationScheduling.Events;

namespace HospitalLibrary.Core.Model.Aggregates.RenovationScheduling
{
    public class RenovationSchedulingSession : EventSourcedAggregate
    {
        public int InitialVersion { get; private set; }

        public RenovationSchedulingSession()
        { }

        public override void Apply(DomainEvent @event)
        {
            When((dynamic)@event);
            Version = Version++;
        }

        public RenovationSchedulingSessionSnapshot GetRenovationSchedulingSessionSnapshot()
        {
            return new RenovationSchedulingSessionSnapshot
            {
                Version = Version
            };
        }

        private void Causes(DomainEvent @event)
        {
            Changes.Add(@event);
            Apply(@event);
        }

        private void When(RenovationScheduled scheduled)
        {
            throw new NotImplementedException();
        }
    }
}
