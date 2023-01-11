using HospitalLibrary.Core.Enums;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Model.ValueObjects;
using HospitalLibrary.Core.Util;

namespace HospitalLibrary.Core.Service
{
    public interface IAppointmentSchedulingEventsService
    {

        public void SaveSessionStartedEvent();
        public void SaveDateTimeSelectedEvent(DateTime selectedDateTime);

    }
}
