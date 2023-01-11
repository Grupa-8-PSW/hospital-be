using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalLibrary.Core.Model.Aggregates;

namespace HospitalLibrary.Core.Model.Aggregates.AppointmentScheduling.Events
{
    public class AvailableAppointmentSelected : DomainEvent
    {
        public AvailableAppointmentSelected(int id, DateTime timestamp, int appointmentId) : base(id, timestamp)
        {
            AppointmentId = appointmentId;
        }

        public int AppointmentId { get; private set; }
    }
}
