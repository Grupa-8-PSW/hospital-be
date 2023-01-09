using HospitalLibrary.Core.Model.Aggregates.RenovationScheduling.Events;
using HospitalLibrary.Core.Model.ValueObjects;

namespace HospitalLibrary.Core.Model.Aggregates.RenovationScheduling
{
    public class RenovationSchedulingSession : EventSourcedAggregate
    {
        public int InitialVersion { get; private set; }

        public RenovationSchedulingSessionSnapshot GetRenovationSchedulingSessionSnapshot()
        {
            return new RenovationSchedulingSessionSnapshot
            {
                Version = Version
            };
        }

        public RenovationSchedulingSession()
        {
            Causes(new SessionStarted(Id));
        }

        public void SelectRenovationType()
        {
            Causes(new RenovationTypeSelected(Id));
        }

        public void SelectRoom()
        {
            Causes(new RoomSelected(Id));
        }

        public void SelectDateTime()
        {
            Causes(new DateTimeSelected(Id));
        }

        public void SelectDuration()
        {
            Causes(new DurationSelected(Id));
        }

        public void SelectAvailableSlot()
        {
            Causes(new AvailableSlotSelected(Id));
        }

        public void ScheduleRenovation()
        {
            Causes(new RenovationScheduled(Id));
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
