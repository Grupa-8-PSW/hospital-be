using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using HospitalLibrary.Core.Model.Aggregates;
using HospitalLibrary.Core.Model.Aggregates.AppointmentScheduling.Events;
using HospitalLibrary.Core.Model.ValueObjects;
using HospitalLibrary.Core.Repository;

namespace HospitalLibrary.Core.Model.Aggregates.AppointmentScheduling 
{ 
    public class AppointmentSchedulingSession : EventSourcedAggregate
    {
        private readonly IAppointmentEventWrapperRepository _eventWrapperRepository;
        private int PatientId { get; set; }
        private IClock Clock { get; set; }

        public AppointmentSchedulingSession(IAppointmentEventWrapperRepository eventWrapperRepository)
        {
            PatientId = 0;
            _eventWrapperRepository = eventWrapperRepository;
        }

        public AppointmentSchedulingSession(int patientId, IClock clock)
        {
            PatientId = patientId;
            Clock = clock;
        }

        public AppointmentSchedulingSession(AppointmentSchedulingSessionSnapshot snapShot)
        {
            // Restore all state
            Version = snapShot.Version;
        }

        public AppointmentSchedulingSessionSnapshot GetAppointmentSchedulingSessionSnapshot()
        {
            var snapshot = new AppointmentSchedulingSessionSnapshot();

            // Save all state

            snapshot.Version = Version;

            return snapshot;
        }

        public void SessionStarted()
        {
            Causes(new SessionStarted(Clock.Time()));
        }

        public void SelectDateAndTime()
        {

            Causes(new DateTimeSelected(Clock.Time(), new DateTime()));
        }

        public void SelectDoctorSpecialization()
        {

            Causes(new DoctorSpecializationSelected(Clock.Time(), Enums.DoctorSpecialization.GENERAL_PRACTICIONER));
        }

        public void SelectDoctor()
        {

            Causes(new DoctorSelected(Clock.Time(), 0));
        }

        public void SelectAvailableAppointment()
        {

            Causes(new AvailableAppointmentSelected(Clock.Time(), new DateRange(DateTime.Now, DateTime.Now)));
        }

        public void ScheduleAppointment()
        {

            Causes(new AppointmentScheduled(Clock.Time()));
        }

        private void Causes(DomainEvent @event)
        {
            Changes.Add(@event);
            Apply(@event);
        }

        public override void Apply(DomainEvent @event)
        {
            When((dynamic)@event);
            Version = Version++;
        }

        private void When(SessionStarted sessionStarted)
        {
           
        }

        private void When(DateTimeSelected dateTimeSelected)
        {
            //KADA SE DESI OVAJ DOGADJAJ STA DA SE URADI DALJE? (WHEN DateTimeSelected DO ...)
            
        }

        private void When(DoctorSpecializationSelected doctorSpecializationSelected)
        {
        
        }

        private void When(DoctorSelected doctorSelected)
        {
        
        }

        private void When(AvailableAppointmentSelected availableAppointmentSelected)
        {
        
        }

        private void When(AppointmentScheduled appointmentScheduled)
        {

        }
    }
}