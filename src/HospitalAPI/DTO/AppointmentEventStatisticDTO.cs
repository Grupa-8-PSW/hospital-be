using HospitalLibrary.Core.Model;

namespace HospitalAPI.DTO
{
    public class AppointmentEventStatisticDTO
    {
        public int AverageNumberOfStep { get; set; }
        public int AverageSecondsOfScheduling { get; set; }
        public StepViewCountStatistic StepViewCountStatistic { get; set; }
    }
}
