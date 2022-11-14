using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Core.Model
{
    public class BloodConsumptionConfiguration
    {
        public int Id { get; set; }
        [Required]
        public uint FrequencyPeriodInHours { get; set; }
        public uint ConsumptionPeriodHours { get; set; }

        public String StartTime { get; set; }
        public String StartDate { get; set; }

        
        public BloodConsumptionConfiguration(int id, uint frequencyPeriodInHours, uint consumptionPeriodHours, string startTime, string startDate)
        {
            Id = id;
            FrequencyPeriodInHours = frequencyPeriodInHours;
            ConsumptionPeriodHours = consumptionPeriodHours;
            StartTime = startTime;
            StartDate = startDate;
        }

        public BloodConsumptionConfiguration(uint frequencyPeriodInHours, uint consumptionPeriodHours, string startTime, string startDate)
        {
            FrequencyPeriodInHours = frequencyPeriodInHours;
            ConsumptionPeriodHours = consumptionPeriodHours;
            StartTime = startTime;
            StartDate = startDate;
        }

        public BloodConsumptionConfiguration()
        {
        }
    }
}
