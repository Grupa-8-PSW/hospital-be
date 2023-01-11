using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using HospitalLibrary.Core.Model.Aggregates;
using HospitalLibrary.Core.Model.Aggregates.AppointmentScheduling.Events;
using HospitalLibrary.Core.Model.ValueObjects;

namespace HospitalLibrary.Core.Model.Aggregates.AppointmentScheduling 
{ 
    public class AppointmentSchedulingSession : EventSourcedAggregate
    {
        private int PatientId { get; set; }
        private IClock Clock { get; set; }

        public AppointmentSchedulingSession()
        {
            PatientId = 0;
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
            Causes(new SessionStarted(Id, Clock.Time()));
        }

        public void SelectDateAndTime()
        {

            Causes(new DateSelected(Id, Clock.Time(), new DateTime()));
        }

        public void SelectDoctorSpecialization()
        {

            Causes(new DoctorSpecializationSelected(Id, Clock.Time(), Enums.DoctorSpecialization.GENERAL_PRACTICIONER));
        }

        public void SelectDoctor()
        {

            Causes(new DoctorSelected(Id, Clock.Time(), 0));
        }

        public void SelectAvailableAppointment()
        {

            Causes(new AvailableAppointmentSelected(Id, Clock.Time(), 0));
        }

        public void ScheduleAppointment()
        {

            Causes(new AppointmentScheduled(Id, Clock.Time(), new DateRange(DateTime.Now, DateTime.Now)));
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

        private void When(DateSelected dateTimeSelected)
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