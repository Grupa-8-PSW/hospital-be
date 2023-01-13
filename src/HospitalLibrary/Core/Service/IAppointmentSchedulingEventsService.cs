using HospitalLibrary.Core.Enums;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Model.ValueObjects;
using HospitalLibrary.Core.Util;

namespace HospitalLibrary.Core.Service
{
    public interface IAppointmentSchedulingEventsService
    {

        public int SaveSessionStartedEvent(int patientId);
        public void SaveDateTimeSelectedEvent(int aggregateId, int patientId, DateTime selectedDateTime);
        public void SaveDoctorSpecializationSelectedEvent(int aggregateId, int patientId, DoctorSpecialization doctorSpecialization);
        public void SaveDoctorSelectedEvent(int aggregateId, int patientId, int doctorId);
        public void SaveAppointmentSelectedEvent(int aggregateId, int patientId, DateRange dateRange);
        public void SaveAppointmentScheduledEvent(int aggregateId, int patientId);
        public int GetAverageNumberOfSteps();
        public int GetAverageDurationInMins();
        public StepViewCountStatistic NumberOfViewsForStep();
    }
}
