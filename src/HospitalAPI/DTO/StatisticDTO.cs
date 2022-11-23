using HospitalLibrary.Core.Model;

namespace HospitalAPI.DTO
{
    public class StatisticDTO
    {
        public AgeStatistic? AgeStatistic { get; set; }
        public GenderStatistic? GenderStatistic { get; set; }
        public BloodTypeStatistic? BloodTypeStatistic { get; set; }
    }
}