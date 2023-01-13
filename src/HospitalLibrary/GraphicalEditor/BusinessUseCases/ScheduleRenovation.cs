using HospitalLibrary.Core.Model.Aggregates.RenovationScheduling;
using HospitalLibrary.Core.Model.Aggregates.RenovationScheduling.Events;
using HospitalLibrary.GraphicalEditor.Enums;
using HospitalLibrary.GraphicalEditor.Repository.Interfaces;

namespace HospitalLibrary.GraphicalEditor.BusinessUseCases
{
    public class ScheduleRenovation
    {
        private readonly IRenovationSchedulingSessionRepository _sessionRepository;

        public ScheduleRenovation(IRenovationSchedulingSessionRepository sessionRepository)
        {
            _sessionRepository = sessionRepository;
        }

        public int CreateNewSessionEvent()
        {
            RenovationEventWrapper e = new()
            {
                Data = new SessionStarted(DateTime.Now),
                EventType = RenovationEventType.SESSION_STARTED
            };
            return _sessionRepository.Create(e).AggregateId;
        }

        public void CreateSessionStartedEvent(int aggregateId)
        {
            RenovationEventWrapper e = new()
            {
                AggregateId = aggregateId,
                Data = new SessionStarted(DateTime.Now),
                EventType = RenovationEventType.SESSION_STARTED
            };
            _sessionRepository.Create(e);
        }

        public void CreateTypeSelectedEvent(int aggregateId)
        {
            RenovationEventWrapper e = new()
            {
                AggregateId = aggregateId,
                Data = new RenovationTypeSelected(DateTime.Now),
                EventType = RenovationEventType.TYPE_SELECTED
            };
            _sessionRepository.Create(e);
        }

        public void CreateRoomSelectedEvent(int aggregateId)
        {
            RenovationEventWrapper e = new()
            {
                AggregateId = aggregateId,
                Data = new RoomSelected(DateTime.Now),
                EventType = RenovationEventType.ROOM_SELECTED
            };
            _sessionRepository.Create(e);
        }

        public void CreateDateTimeSelectedEvent(int aggregateId)
        {
            RenovationEventWrapper e = new()
            {
                AggregateId = aggregateId,
                Data = new DateTimeSelected(DateTime.Now),
                EventType = RenovationEventType.DATE_TIME_SELECTED
            };
            _sessionRepository.Create(e);
        }

        public void CreateDurationSelectedvent(int aggregateId)
        {
            RenovationEventWrapper e = new()
            {
                AggregateId = aggregateId,
                Data = new DurationSelected(DateTime.Now),
                EventType = RenovationEventType.DURATION_SELECTED
            };
            _sessionRepository.Create(e);
        }

        public void CreateAvailableSlotSelectedEvent(int aggregateId)
        {
            RenovationEventWrapper e = new()
            {
                AggregateId = aggregateId,
                Data = new AvailableSlotSelected(DateTime.Now),
                EventType = RenovationEventType.AVAILABLE_SLOT_SELECTED
            };
            _sessionRepository.Create(e);
        }

        public void CreateRenovationScheduledEvent(int aggregateId)
        {
            RenovationEventWrapper e = new()
            {
                AggregateId = aggregateId,
                Data = new RenovationScheduled(DateTime.Now),
                EventType = RenovationEventType.SESSION_ENDED
            };
            _sessionRepository.Create(e);
        }

    }
}
