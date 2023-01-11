using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Model
{
    public class AppointmentStatistic
    {
        public StepViewCountStatistic? PatientOnEachStepNumber { get; set; }
        public SessionStepTimeSpent? PatientOnEachStepDuration { get; set; }
        public int AverageNumberOfStepForScheduleAppointment { get; set; }
        public int AverageDurationOfStepForScheduleAppointment { get; set; }
    }
}
