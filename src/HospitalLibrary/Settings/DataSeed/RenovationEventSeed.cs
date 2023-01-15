using HospitalLibrary.Core.Model.Aggregates.RenovationScheduling;
using HospitalLibrary.Core.Model.Aggregates.RenovationScheduling.Events;
using HospitalLibrary.GraphicalEditor.Enums;
using HospitalLibrary.GraphicalEditor.Repository.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace HospitalLibrary.Settings.DataSeed
{
    public static class RenovationEventSeed
    {
        public static void SeedRenovationEvents(IServiceProvider services)
        {
            var eventRepository = services.GetRequiredService<IRenovationSchedulingSessionRepository>();

            eventRepository.Create(new RenovationEventWrapper()
            {
                Data = new SessionStarted(new DateTime(2023, 1, 14, 19, 5, 10)),
                EventType = RenovationEventType.SESSION_STARTED,
            });
            eventRepository.Create(new RenovationEventWrapper()
            {
                AggregateId = 1,
                Data = new RenovationTypeSelected(new DateTime(2023, 1, 14, 19, 5, 20)),
                EventType = RenovationEventType.TYPE_SELECTED,
            });
            eventRepository.Create(new RenovationEventWrapper()
            {
                AggregateId = 1,
                Data = new RoomSelected(new DateTime(2023, 1, 14, 19, 5, 25)),
                EventType = RenovationEventType.ROOM_SELECTED,
            });
            eventRepository.Create(new RenovationEventWrapper()
            {
                AggregateId = 1,
                Data = new DateTimeSelected(new DateTime(2023, 1, 14, 19, 5, 37)),
                EventType = RenovationEventType.DATE_TIME_SELECTED,
            });
            eventRepository.Create(new RenovationEventWrapper()
            {
                AggregateId = 1,
                Data = new DurationSelected(new DateTime(2023, 1, 14, 19, 5, 40)),
                EventType = RenovationEventType.DURATION_SELECTED,
            });
            eventRepository.Create(new RenovationEventWrapper()
            {
                AggregateId = 1,
                Data = new AvailableSlotSelected(new DateTime(2023, 1, 14, 19, 5, 45)),
                EventType = RenovationEventType.AVAILABLE_SLOT_SELECTED,
            });
            eventRepository.Create(new RenovationEventWrapper()
            {
                AggregateId = 1,
                Data = new RenovationScheduled(new DateTime(2023, 1, 14, 19, 5, 59)),
                EventType = RenovationEventType.SESSION_ENDED,
            });



            eventRepository.Create(new RenovationEventWrapper()
            {
                Data = new SessionStarted(new DateTime(2023, 1, 14, 19, 5, 1)),
                EventType = RenovationEventType.SESSION_STARTED,
            });
            eventRepository.Create(new RenovationEventWrapper()
            {
                AggregateId = 2,
                Data = new RenovationTypeSelected(new DateTime(2023, 1, 14, 19, 5, 20)),
                EventType = RenovationEventType.TYPE_SELECTED,
            });
            eventRepository.Create(new RenovationEventWrapper()
            {
                AggregateId = 2,
                Data = new RoomSelected(new DateTime(2023, 1, 14, 19, 5, 25)),
                EventType = RenovationEventType.ROOM_SELECTED,
            });
            eventRepository.Create(new RenovationEventWrapper()
            {
                AggregateId = 2,
                Data = new DateTimeSelected(new DateTime(2023, 1, 14, 19, 5, 37)),
                EventType = RenovationEventType.DATE_TIME_SELECTED,
            });
            eventRepository.Create(new RenovationEventWrapper()
            {
                AggregateId = 2,
                Data = new DurationSelected(new DateTime(2023, 1, 14, 19, 5, 45)),
                EventType = RenovationEventType.DURATION_SELECTED,
            });
            eventRepository.Create(new RenovationEventWrapper()
            {
                AggregateId = 2,
                Data = new AvailableSlotSelected(new DateTime(2023, 1, 14, 19, 6, 1)),
                EventType = RenovationEventType.AVAILABLE_SLOT_SELECTED,
            });
            eventRepository.Create(new RenovationEventWrapper()
            {
                AggregateId = 2,
                Data = new RenovationScheduled(new DateTime(2023, 1, 14, 19, 6, 15)),
                EventType = RenovationEventType.SESSION_ENDED,
            });




            eventRepository.Create(new RenovationEventWrapper()
            {
                Data = new SessionStarted(new DateTime(2023, 1, 14, 19, 4, 5)),
                EventType = RenovationEventType.SESSION_STARTED,
            });
            eventRepository.Create(new RenovationEventWrapper()
            {
                AggregateId = 3,
                Data = new RenovationTypeSelected(new DateTime(2023, 1, 14, 19, 4, 35)),
                EventType = RenovationEventType.TYPE_SELECTED,
            });
            eventRepository.Create(new RenovationEventWrapper()
            {
                AggregateId = 3,
                Data = new RoomSelected(new DateTime(2023, 1, 14, 19, 4, 42)),
                EventType = RenovationEventType.ROOM_SELECTED,
            });


            eventRepository.Create(new RenovationEventWrapper()
            {
                AggregateId = 3,
                Data = new RenovationTypeSelected(new DateTime(2023, 1, 14, 19, 4, 44)),
                EventType = RenovationEventType.TYPE_SELECTED,
            });
            eventRepository.Create(new RenovationEventWrapper()
            {
                AggregateId = 3,
                Data = new RoomSelected(new DateTime(2023, 1, 14, 19, 4, 49)),
                EventType = RenovationEventType.ROOM_SELECTED,
            });
            eventRepository.Create(new RenovationEventWrapper()
            {
                AggregateId = 3,
                Data = new DateTimeSelected(new DateTime(2023, 1, 14, 19, 5, 5)),
                EventType = RenovationEventType.DATE_TIME_SELECTED,
            });
            eventRepository.Create(new RenovationEventWrapper()
            {
                AggregateId = 3,
                Data = new DurationSelected(new DateTime(2023, 1, 14, 19, 5, 22)),
                EventType = RenovationEventType.DURATION_SELECTED,
            });
            eventRepository.Create(new RenovationEventWrapper()
            {
                AggregateId = 3,
                Data = new AvailableSlotSelected(new DateTime(2023, 1, 14, 19, 5, 38)),
                EventType = RenovationEventType.AVAILABLE_SLOT_SELECTED,
            });


            eventRepository.Create(new RenovationEventWrapper()
            {
                AggregateId = 3,
                Data = new DurationSelected(new DateTime(2023, 1, 14, 19, 5, 49)),
                EventType = RenovationEventType.DURATION_SELECTED,
            });
            eventRepository.Create(new RenovationEventWrapper()
            {
                AggregateId = 3,
                Data = new DateTimeSelected(new DateTime(2023, 1, 14, 19, 5, 58)),
                EventType = RenovationEventType.DATE_TIME_SELECTED,
            });
            eventRepository.Create(new RenovationEventWrapper()
            {
                AggregateId = 3,
                Data = new RoomSelected(new DateTime(2023, 1, 14, 19, 6, 2)),
                EventType = RenovationEventType.ROOM_SELECTED,
            });
            eventRepository.Create(new RenovationEventWrapper()
            {
                AggregateId = 3,
                Data = new DateTimeSelected(new DateTime(2023, 1, 14, 19, 6, 15)),
                EventType = RenovationEventType.DATE_TIME_SELECTED,
            });
            eventRepository.Create(new RenovationEventWrapper()
            {
                AggregateId = 3,
                Data = new DurationSelected(new DateTime(2023, 1, 14, 19, 6, 22)),
                EventType = RenovationEventType.DURATION_SELECTED,
            });
            eventRepository.Create(new RenovationEventWrapper()
            {
                AggregateId = 3,
                Data = new AvailableSlotSelected(new DateTime(2023, 1, 14, 19, 6, 38)),
                EventType = RenovationEventType.AVAILABLE_SLOT_SELECTED,
            });
            eventRepository.Create(new RenovationEventWrapper()
            {
                AggregateId = 3,
                Data = new RenovationScheduled(new DateTime(2023, 1, 14, 19, 6, 49)),
                EventType = RenovationEventType.SESSION_ENDED,
            });

        }
    }
}
