using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalLibrary.Core.Model.Aggregates;

namespace HospitalLibrary.Core.Model.Aggregates.AppointmentScheduling.Events
{
    public class DoctorSelected : DomainEvent
    {
        public DoctorSelected(int id, int doctorId) : base(id)
        {
            DoctorId = doctorId;
        }

        public int DoctorId { get; private set; }
    }
}
