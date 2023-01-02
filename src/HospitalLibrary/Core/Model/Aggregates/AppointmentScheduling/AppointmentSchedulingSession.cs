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

        public AppointmentSchedulingSession(int patientId)
        {
            PatientId = patientId;
            Causes(new SessionStarted(Id));
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

        public void SelectDateAndTime(IClock clock)
        {

            Causes(new DateSelected(Id, new DateTime()));
        }

        public void SelectDoctorSpecialization(IClock clock)
        {

            Causes(new DoctorSpecializationSelected(Id, Enums.DoctorSpecialization.GENERAL_PRACTICIONER));
        }

        public void SelectDoctor(IClock clock)
        {

            Causes(new DoctorSelected(Id, 0));
        }

        public void SelectAvailableAppointment(IClock clock)
        {

            Causes(new AvailableAppointmentSelected(Id, 0));
        }

        public void ScheduleAppointment(IClock clock)
        {

            Causes(new AppointmentScheduled(Id, new DateRange(DateTime.Now, DateTime.Now)));
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