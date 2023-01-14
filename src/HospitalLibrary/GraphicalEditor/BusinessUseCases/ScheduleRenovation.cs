using HospitalLibrary.Core.Model.Aggregates.RenovationScheduling;
using HospitalLibrary.Core.Model.Aggregates.RenovationScheduling.Events;
using HospitalLibrary.GraphicalEditor.Enums;
using HospitalLibrary.GraphicalEditor.Model.DTO;
using HospitalLibrary.GraphicalEditor.Repository.Interfaces;
using System.Text.Json.Nodes;

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

        public List<int> GetAll()
        {
            return _sessionRepository.GetScheduledRenovations();
        }

        public List<RenovationSessionDTO> ViewsPerEachStep()
        {
            List<RenovationSessionDTO> sessions = new();
            DateTime start = new();
            DateTime end = new();
            foreach (var id in _sessionRepository.GetScheduledRenovations())
            {
                var session = new RenovationSessionDTO(id);
                foreach (var ev in _sessionRepository.GetAll())
                {
                    if (id == ev.AggregateId)
                    {
                        if (ev.EventType == RenovationEventType.SESSION_STARTED)
                        {
                            var obj = JsonNode.Parse(ev.Data.ToString());
                            start = Convert.ToDateTime(obj["Timestamp"].ToString());
                            session.Type++;
                        }
                        if (ev.EventType == RenovationEventType.TYPE_SELECTED)
                            session.Room++;
                        if (ev.EventType == RenovationEventType.ROOM_SELECTED)
                            session.Interval++;
                        if (ev.EventType == RenovationEventType.DATE_TIME_SELECTED)
                            session.Duration++;
                        if (ev.EventType == RenovationEventType.DURATION_SELECTED)
                            session.Available++;
                        if (ev.EventType == RenovationEventType.AVAILABLE_SLOT_SELECTED)
                            session.Changes++;
                        if (ev.EventType == RenovationEventType.SESSION_ENDED)
                        {
                            var obj = JsonNode.Parse(ev.Data.ToString());
                            end = Convert.ToDateTime(obj["Timestamp"].ToString());
                            session.Schedule++;
                        }
                    }
                }
                var diff = end - start;
                session.Seconds = diff.Seconds;
                sessions.Add(session);
            }
            return sessions;
        }

        public List<double> ViewsAverage()
        {
            List<int> types = new();
            List<int> rooms = new();
            List<int> intervals = new();
            List<int> durations = new();
            List<int> availability = new();
            List<int> changes = new();
            List<int> schedules = new();

            foreach (var id in _sessionRepository.GetScheduledRenovations())
            {
                var session = new RenovationSessionDTO(id);
                foreach (var ev in _sessionRepository.GetAll())
                {
                    if (id == ev.AggregateId)
                    {
                        if (ev.EventType == RenovationEventType.SESSION_STARTED)
                            session.Type++;
                        if (ev.EventType == RenovationEventType.TYPE_SELECTED)
                            session.Room++;
                        if (ev.EventType == RenovationEventType.ROOM_SELECTED)
                            session.Interval++;
                        if (ev.EventType == RenovationEventType.DATE_TIME_SELECTED)
                            session.Duration++;
                        if (ev.EventType == RenovationEventType.DURATION_SELECTED)
                            session.Available++;
                        if (ev.EventType == RenovationEventType.AVAILABLE_SLOT_SELECTED)
                            session.Changes++;
                        if (ev.EventType == RenovationEventType.SESSION_ENDED)
                            session.Schedule++;
                    }
                }
                types.Add(session.Type);
                rooms.Add(session.Room);
                intervals.Add(session.Interval);
                durations.Add(session.Duration);
                availability.Add(session.Available);
                changes.Add(session.Changes);
                schedules.Add(session.Schedule);
            }
            return new List<double>()
            {
                types.Average(),
                rooms.Average(),
                intervals.Average(),
                durations.Average(),
                availability.Average(),
                changes.Average(),
                schedules.Average()
            };
        }

        public List<double> ViewsTotal()
        {
            List<int> types = new();
            List<int> rooms = new();
            List<int> intervals = new();
            List<int> durations = new();
            List<int> availability = new();
            List<int> changes = new();
            List<int> schedules = new();

            foreach (var id in _sessionRepository.GetScheduledRenovations())
            {
                var session = new RenovationSessionDTO(id);
                foreach (var ev in _sessionRepository.GetAll())
                {
                    if (id == ev.AggregateId)
                    {
                        if (ev.EventType == RenovationEventType.SESSION_STARTED)
                            session.Type++;
                        if (ev.EventType == RenovationEventType.TYPE_SELECTED)
                            session.Room++;
                        if (ev.EventType == RenovationEventType.ROOM_SELECTED)
                            session.Interval++;
                        if (ev.EventType == RenovationEventType.DATE_TIME_SELECTED)
                            session.Duration++;
                        if (ev.EventType == RenovationEventType.DURATION_SELECTED)
                            session.Available++;
                        if (ev.EventType == RenovationEventType.AVAILABLE_SLOT_SELECTED)
                            session.Changes++;
                        if (ev.EventType == RenovationEventType.SESSION_ENDED)
                            session.Schedule++;
                    }
                }
                types.Add(session.Type);
                rooms.Add(session.Room);
                intervals.Add(session.Interval);
                durations.Add(session.Duration);
                availability.Add(session.Available);
                changes.Add(session.Changes);
                schedules.Add(session.Schedule);
            }
            return new List<double>()
            {
                types.Sum(),
                rooms.Sum(),
                intervals.Sum(),
                durations.Sum(),
                availability.Sum(),
                changes.Sum(),
                schedules.Sum()
            };
        }

    }
}
