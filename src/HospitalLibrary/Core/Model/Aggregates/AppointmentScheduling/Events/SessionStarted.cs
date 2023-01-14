using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalLibrary.Core.Model.Aggregates;

namespace HospitalLibrary.Core.Model.Aggregates.AppointmentScheduling.Events
{
    public class SessionStarted : DomainEvent
    {
        public SessionStarted(DateTime timestamp) : base(timestamp)
        {
        }

    }
}
