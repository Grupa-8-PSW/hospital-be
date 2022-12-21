using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Model
{
    public class AppointmentStatistic
    {
        public PatientOnEachStepNumberStatistic? PatientOnEachStepNumber { get; set; }
        public PatientOnEachStepMinutesStatistic? PatientOnEachStepDuration { get; set; }
        public int AverageNumberOfStepForScheduleAppointment { get; set; }
        public int AverageDurationOfStepForScheduleAppointment { get; set; }
    }
}
