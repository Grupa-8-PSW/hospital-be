using HospitalLibrary.Core.Enums;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Model.Aggregates;
using HospitalLibrary.Core.Model.Aggregates.AppointmentScheduling;
using HospitalLibrary.Core.Model.Aggregates.AppointmentScheduling.Events;
using HospitalLibrary.Core.Model.ValueObjects;
using HospitalLibrary.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Service
{
    public class AppointmentSchedulingEventsService : IAppointmentSchedulingEventsService
    {

        private readonly IAppointmentEventWrapperRepository _eventWrapperRepository;

        public AppointmentSchedulingEventsService(IAppointmentEventWrapperRepository eventWrapperRepository)
        {
            _eventWrapperRepository = eventWrapperRepository;
        }

        public int SaveSessionStartedEvent(int patientId)
        {
            AppointmentEventWrapper e = new AppointmentEventWrapper()
            {
                PatientId = patientId,
                Data = new SessionStarted(DateTime.Now),
                EventType = Enums.EventType.SESSION_STARTED
            };
            return _eventWrapperRepository.Create(e).AggregateId;
        }

        public void SaveDateTimeSelectedEvent(int aggregateId, int patientId, DateTime selectedDateTime)
        {
            AppointmentEventWrapper e = new AppointmentEventWrapper()
            {
                AggregateId = aggregateId,
                PatientId = patientId,
                Data = new DateTimeSelected(DateTime.Now, selectedDateTime),
                EventType = Enums.EventType.DATE_TIME_SELECTED
            };
            _eventWrapperRepository.Create(e);
        }

        public void SaveDoctorSpecializationSelectedEvent(int aggregateId, int patientId, DoctorSpecialization doctorSpecialization)
        {
            AppointmentEventWrapper e = new AppointmentEventWrapper()
            {
                AggregateId = aggregateId,
                PatientId = patientId,
                Data = new DoctorSpecializationSelected(DateTime.Now, doctorSpecialization),
                EventType = Enums.EventType.DOCTOR_SPECIALIZATION_SELECTED
            };
            _eventWrapperRepository.Create(e);
        }

        public void SaveDoctorSelectedEvent(int aggregateId, int patientId, int doctorId)
        {
            AppointmentEventWrapper e = new AppointmentEventWrapper()
            {
                AggregateId = aggregateId,
                PatientId = patientId,
                Data = new DoctorSelected(DateTime.Now, doctorId),
                EventType = Enums.EventType.DOCTOR_SELECTED
            };
            _eventWrapperRepository.Create(e);
        }

        public void SaveAppointmentSelectedEvent(int aggregateId, int patientId, DateRange dateRange)
        {
            AppointmentEventWrapper e = new AppointmentEventWrapper()
            {
                AggregateId = aggregateId,
                PatientId = patientId,
                Data = new AvailableAppointmentSelected(DateTime.Now, dateRange),
                EventType = Enums.EventType.APPOINTMENT_SELECTED
            };
            _eventWrapperRepository.Create(e);
        }

        public void SaveAppointmentScheduledEvent(int aggregateId, int patientId)
        {
            AppointmentEventWrapper e = new AppointmentEventWrapper()
            {
                AggregateId = aggregateId,
                PatientId = patientId,
                Data = new AppointmentScheduled(DateTime.Now),
                EventType = Enums.EventType.SESSION_END
            };
            _eventWrapperRepository.Create(e);
        }
    }
}
