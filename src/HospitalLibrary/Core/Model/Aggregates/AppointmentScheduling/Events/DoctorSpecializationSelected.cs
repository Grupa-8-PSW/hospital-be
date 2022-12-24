using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalLibrary.Core.Enums;
using HospitalLibrary.Core.Model.Aggregates;

namespace HospitalLibrary.Core.Model.Aggregates.AppointmentScheduling.Events
{
    public class DoctorSpecializationSelected : DomainEvent
    {
        public DoctorSpecializationSelected(int id, DoctorSpecialization doctorSpecialization) : base(id)
        {
            DoctorSpecialization = doctorSpecialization;
        }

        public DoctorSpecialization DoctorSpecialization { get; private set; }
    }
}
