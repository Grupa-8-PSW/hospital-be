using HospitalLibrary.Core.Model;

namespace HospitalAPI.DTO
{
    public class AppointmentEventStatisticDTO
    {
        public int AverageNumberOfStep { get; set; }
        public int AverageSecondsOfScheduling { get; set; }
        public StepViewCountStatistic StepViewCountStatistic { get; set; }
        public SessionStepTimeSpent DurationViewingEachStep { get; set; }
        public int SuccesfullPercentage { get; set; }
        public AgeStatistic AgeStatistic { get; set; }
    }
}
