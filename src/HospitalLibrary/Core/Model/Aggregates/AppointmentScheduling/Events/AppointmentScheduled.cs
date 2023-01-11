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
        public AppointmentScheduled(int id, DateTime timestamp, DateRange dateRange) : base(id, timestamp)
        {
            DateRange = dateRange;
        }

        public DateRange DateRange { get; private set; }
    }
}
