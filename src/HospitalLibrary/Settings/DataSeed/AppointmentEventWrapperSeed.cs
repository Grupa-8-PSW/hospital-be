using HospitalLibrary.Core.Enums;
using HospitalLibrary.Core.Model.Aggregates.AppointmentScheduling;
using HospitalLibrary.Core.Model.Aggregates.AppointmentScheduling.Events;
using HospitalLibrary.Core.Model.ValueObjects;
using HospitalLibrary.Core.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Settings.DataSeed
{
    public static class AppointmentEventWrapperSeed
    {
        public static void SeedAppointementEvents(IServiceProvider services)
        {
            var eventRepository = services.GetRequiredService<IAppointmentEventWrapperRepository>();

            eventRepository.Create(new AppointmentEventWrapper()
            {
                PatientId = 1,
                Data = new SessionStarted(new DateTime(2023, 1, 14, 19, 5, 10)),
                EventType = Core.Enums.EventType.SESSION_STARTED,
            });
            eventRepository.Create(new AppointmentEventWrapper()
            {
                AggregateId = 1,
                PatientId = 1,
                Data = new DateTimeSelected(new DateTime(2023, 1, 14, 19, 5, 20) , new DateTime(2023, 1, 15)),
                EventType = Core.Enums.EventType.DATE_TIME_SELECTED,
            });
            eventRepository.Create(new AppointmentEventWrapper()
            {
                AggregateId = 1,
                PatientId = 1,
                Data = new DoctorSpecializationSelected(new DateTime(2023, 1, 14, 19, 5, 25), DoctorSpecialization.GENERAL_PRACTICIONER),
                EventType = Core.Enums.EventType.DOCTOR_SPECIALIZATION_SELECTED,
            });
            eventRepository.Create(new AppointmentEventWrapper()
            {
                AggregateId = 1,
                PatientId = 1,
                Data = new DoctorSelected(new DateTime(2023, 1, 14, 19, 5, 37), 1),
                EventType = Core.Enums.EventType.DOCTOR_SELECTED,
            });
            eventRepository.Create(new AppointmentEventWrapper()
            {
                AggregateId = 1,
                PatientId = 1,
                Data = new AvailableAppointmentSelected(new DateTime(2023, 1, 14, 19, 5, 45), new DateRange(DateTime.Now, DateTime.Now)),
                EventType = Core.Enums.EventType.APPOINTMENT_SELECTED,
            });
            eventRepository.Create(new AppointmentEventWrapper()
            {
                AggregateId = 1,
                PatientId = 1,
                Data = new AppointmentScheduled(new DateTime(2023, 1, 14, 19, 5, 59)),
                EventType = Core.Enums.EventType.SESSION_END,
            });


            eventRepository.Create(new AppointmentEventWrapper()
            {
                PatientId = 1,
                Data = new SessionStarted(new DateTime(2023, 1, 14, 19, 5, 1)),
                EventType = Core.Enums.EventType.SESSION_STARTED,
            });
            eventRepository.Create(new AppointmentEventWrapper()
            {
                AggregateId = 2,
                PatientId = 1,
                Data = new DateTimeSelected(new DateTime(2023, 1, 14, 19, 5, 9), new DateTime(2023, 1, 15)),
                EventType = Core.Enums.EventType.DATE_TIME_SELECTED,
            });
            eventRepository.Create(new AppointmentEventWrapper()
            {
                AggregateId = 2,
                PatientId = 1,
                Data = new DoctorSpecializationSelected(new DateTime(2023, 1, 14, 19, 5, 18), DoctorSpecialization.GENERAL_PRACTICIONER),
                EventType = Core.Enums.EventType.DOCTOR_SPECIALIZATION_SELECTED,
            });
            eventRepository.Create(new AppointmentEventWrapper()
            {
                AggregateId = 2,
                PatientId = 1,
                Data = new DoctorSelected(new DateTime(2023, 1, 14, 19, 5, 35), 1),
                EventType = Core.Enums.EventType.DOCTOR_SELECTED,
            });
            eventRepository.Create(new AppointmentEventWrapper()
            {
                AggregateId = 2,
                PatientId = 1,
                Data = new AvailableAppointmentSelected(new DateTime(2023, 1, 14, 19, 6, 1), new DateRange(DateTime.Now, DateTime.Now)),
                EventType = Core.Enums.EventType.APPOINTMENT_SELECTED,
            });
            eventRepository.Create(new AppointmentEventWrapper()
            {
                AggregateId = 2,
                PatientId = 1,
                Data = new AppointmentScheduled(new DateTime(2023, 1, 14, 19, 6, 15)),
                EventType = Core.Enums.EventType.SESSION_END,
            });



            eventRepository.Create(new AppointmentEventWrapper()
            {
                PatientId = 3,
                Data = new SessionStarted(new DateTime(2023, 1, 14, 19, 4, 5)),
                EventType = Core.Enums.EventType.SESSION_STARTED,
            });
            eventRepository.Create(new AppointmentEventWrapper()
            {
                AggregateId = 3,
                PatientId = 3,
                Data = new DateTimeSelected(new DateTime(2023, 1, 14, 19, 4, 25), new DateTime(2023, 1, 15)),
                EventType = Core.Enums.EventType.DATE_TIME_SELECTED,
            });
            eventRepository.Create(new AppointmentEventWrapper()
            {
                AggregateId = 3,
                PatientId = 3,
                Data = new DoctorSpecializationSelected(new DateTime(2023, 1, 14, 19, 4, 32), DoctorSpecialization.GENERAL_PRACTICIONER),
                EventType = Core.Enums.EventType.DOCTOR_SPECIALIZATION_SELECTED,
            });
            eventRepository.Create(new AppointmentEventWrapper()
            {
                AggregateId = 3,
                PatientId = 3,
                Data = new DoctorSelected(new DateTime(2023, 1, 14, 19, 4, 47), 1),
                EventType = Core.Enums.EventType.DOCTOR_SELECTED,
            });
            eventRepository.Create(new AppointmentEventWrapper()
            {
                AggregateId = 3,
                PatientId = 3,
                Data = new AvailableAppointmentSelected(new DateTime(2023, 1, 14, 19, 5, 1), new DateRange(DateTime.Now, DateTime.Now)),
                EventType = Core.Enums.EventType.APPOINTMENT_SELECTED,
            });
            eventRepository.Create(new AppointmentEventWrapper()
            {
                AggregateId = 3,
                PatientId = 3,
                Data = new AppointmentScheduled(new DateTime(2023, 1, 14, 19, 5, 15)),
                EventType = Core.Enums.EventType.SESSION_END,
            });




            eventRepository.Create(new AppointmentEventWrapper()
            {
                PatientId = 4,
                Data = new SessionStarted(new DateTime(2023, 1, 14, 19, 4, 5)),
                EventType = Core.Enums.EventType.SESSION_STARTED,
            });
            eventRepository.Create(new AppointmentEventWrapper()
            {
                AggregateId = 4,
                PatientId = 4,
                Data = new DateTimeSelected(new DateTime(2023, 1, 14, 19, 4, 35), new DateTime(2023, 1, 15)),
                EventType = Core.Enums.EventType.DATE_TIME_SELECTED,
            });
            eventRepository.Create(new AppointmentEventWrapper()
            {
                AggregateId = 4,
                PatientId = 4,
                Data = new DoctorSpecializationSelected(new DateTime(2023, 1, 14, 19, 4, 42), DoctorSpecialization.GENERAL_PRACTICIONER),
                EventType = Core.Enums.EventType.DOCTOR_SPECIALIZATION_SELECTED,
            });
            eventRepository.Create(new AppointmentEventWrapper()
            {
                AggregateId = 4,
                PatientId = 4,
                Data = new DoctorSpecializationSelected(new DateTime(2023, 1, 14, 19, 4, 49), DoctorSpecialization.GENERAL_PRACTICIONER),
                EventType = Core.Enums.EventType.DOCTOR_SPECIALIZATION_SELECTED,
            });
            eventRepository.Create(new AppointmentEventWrapper()
            {
                AggregateId = 4,
                PatientId = 4,
                Data = new DoctorSelected(new DateTime(2023, 1, 14, 19, 5, 5), 1),
                EventType = Core.Enums.EventType.DOCTOR_SELECTED,
            });
            eventRepository.Create(new AppointmentEventWrapper()
            {
                AggregateId = 4,
                PatientId = 4,
                Data = new DoctorSelected(new DateTime(2023, 1, 14, 19, 5, 22), 1),
                EventType = Core.Enums.EventType.DOCTOR_SELECTED,
            });
            eventRepository.Create(new AppointmentEventWrapper()
            {
                AggregateId = 4,
                PatientId = 4,
                Data = new AvailableAppointmentSelected(new DateTime(2023, 1, 14, 19, 5, 38), new DateRange(DateTime.Now, DateTime.Now)),
                EventType = Core.Enums.EventType.APPOINTMENT_SELECTED,
            });
            eventRepository.Create(new AppointmentEventWrapper()
            {
                AggregateId = 4,
                PatientId = 4,
                Data = new AvailableAppointmentSelected(new DateTime(2023, 1, 14, 19, 5, 49), new DateRange(DateTime.Now, DateTime.Now)),
                EventType = Core.Enums.EventType.APPOINTMENT_SELECTED,
            });
            eventRepository.Create(new AppointmentEventWrapper()
            {
                AggregateId = 4,
                PatientId = 4,
                Data = new AvailableAppointmentSelected(new DateTime(2023, 1, 14, 19, 5, 58), new DateRange(DateTime.Now, DateTime.Now)),
                EventType = Core.Enums.EventType.APPOINTMENT_SELECTED,
            });
            eventRepository.Create(new AppointmentEventWrapper()
            {
                AggregateId = 4,
                PatientId = 4,
                Data = new AppointmentScheduled(new DateTime(2023, 1, 14, 19, 6, 2)),
                EventType = Core.Enums.EventType.SESSION_END,
            });

            eventRepository.Create(new AppointmentEventWrapper()
            {
                PatientId = 4,
                Data = new SessionStarted(new DateTime(2023, 1, 14, 19, 4, 5)),
                EventType = Core.Enums.EventType.SESSION_STARTED,
            });
            eventRepository.Create(new AppointmentEventWrapper()
            {
                AggregateId = 5,
                PatientId = 4,
                Data = new DateTimeSelected(new DateTime(2023, 1, 14, 19, 4, 35), new DateTime(2023, 1, 15)),
                EventType = Core.Enums.EventType.DATE_TIME_SELECTED,
            });
            eventRepository.Create(new AppointmentEventWrapper()
            {
                AggregateId = 5,
                PatientId = 4,
                Data = new DateTimeSelected(new DateTime(2023, 1, 14, 19, 4, 45), new DateTime(2023, 1, 15)),
                EventType = Core.Enums.EventType.DATE_TIME_SELECTED,
            });
            eventRepository.Create(new AppointmentEventWrapper()
            {
                AggregateId = 5,
                PatientId = 4,
                Data = new DateTimeSelected(new DateTime(2023, 1, 14, 19, 4, 59), new DateTime(2023, 1, 15)),
                EventType = Core.Enums.EventType.DATE_TIME_SELECTED,
            });

        }
    }
}
