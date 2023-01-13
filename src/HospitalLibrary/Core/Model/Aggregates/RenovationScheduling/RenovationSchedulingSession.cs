using HospitalLibrary.Core.Model.Aggregates.RenovationScheduling.Events;
using HospitalLibrary.Core.Model.ValueObjects;

namespace HospitalLibrary.Core.Model.Aggregates.RenovationScheduling
{
    public class RenovationSchedulingSession : EventSourcedAggregate
    {
        private IClock Clock { get; set; }

        public int InitialVersion { get; private set; }

        public RenovationSchedulingSessionSnapshot GetRenovationSchedulingSessionSnapshot()
        {
            return new RenovationSchedulingSessionSnapshot
            {
                Version = Version
            };
        }

        public RenovationSchedulingSession(IClock clock)
        {
            Clock = clock;
        }

        public RenovationSchedulingSession(int id)
        {
            Causes(new SessionStarted(id));
        }

        public void SelectRenovationType()
        {
            Causes(new RenovationTypeSelected(Clock.Time()));
        }

        public void SelectRoom()
        {
            Causes(new RoomSelected(Clock.Time()));
        }

        public void SelectDateTime()
        {
            Causes(new DateTimeSelected(Clock.Time()));
        }

        public void SelectDuration()
        {
            Causes(new DurationSelected(Clock.Time()));
        }

        public void SelectAvailableSlot()
        {
            Causes(new AvailableSlotSelected(Clock.Time()));
        }

        public void ScheduleRenovation()
        {
            Causes(new RenovationScheduled(Clock.Time()));
        }

        public override void Apply(DomainEvent @event)
        {
            When((dynamic)@event);
            Version = Version++;
        }

        private void Causes(DomainEvent @event)
        {
            Changes.Add(@event);
            Apply(@event);
        }

        private void When(SessionStarted started)
        {
            //throw new NotImplementedException();
        }

        private void When(RenovationTypeSelected selected)
        {
            //throw new NotImplementedException();
        }

        private void When(RoomSelected selected)
        {
            //throw new NotImplementedException();
        }

        private void When(DateTimeSelected selected)
        {
            //throw new NotImplementedException();
        }

        private void When(DurationSelected selected)
        {
            //throw new NotImplementedException();
        }

        private void When(AvailableSlotSelected selected)
        {
            //throw new NotImplementedException();
        }

        private void When(RenovationScheduled scheduled)
        {
            //throw new NotImplementedException();
        }
    }
}
