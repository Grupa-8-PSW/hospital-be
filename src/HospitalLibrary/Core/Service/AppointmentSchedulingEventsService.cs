using HospitalLibrary.Core.Model.Aggregates;
using HospitalLibrary.Core.Model.Aggregates.AppointmentScheduling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Service
{
    public class AppointmentSchedulingEventsService : IAppointmentSchedulingEventsService
    {

        public AppointmentSchedulingEventsService() { }

        public void SaveSessionStartedEvent()
        {
            
        }

        public void SaveDateTimeSelectedEvent(DateTime selectedDateTime)
        {
            
        }
    }
}
