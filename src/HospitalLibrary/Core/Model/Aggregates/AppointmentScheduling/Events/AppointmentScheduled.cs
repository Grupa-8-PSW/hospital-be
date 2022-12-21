using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalLibrary.Core.Model.Aggregates;
using HospitalLibrary.Core.Model.ValueObjects;

namespace HospitalLibrary.Core.Model.Aggregates.AppointmentScheduling.Events
{
    public class AppointmentScheduled : DomainEvent
    {
        public AppointmentScheduled(int id, DateRange dateRange) : base(id)
        {
            DateRange = dateRange;
        }

        public DateRange DateRange { get; private set; }
    }
}
