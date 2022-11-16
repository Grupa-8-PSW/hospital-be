using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Org.BouncyCastle.Asn1.Cms;

namespace IntegrationLibrary.Core.Model
{
    public class BloodConsumptionConfiguration
    {
        public int Id { get; set; }
        [Required]
        public uint FrequencyPeriodInHours { get; set; }
        public TimeSpan ConsumptionPeriodHours { get; set; }

        //public TimeOnly StartTime { get; set; }
        public DateTime StartDateTime { get; set; }


        public BloodConsumptionConfiguration(int id, uint frequencyPeriodInHours, TimeSpan consumptionPeriodHours, DateTime startDateTime)
        {
            Id = id;
            FrequencyPeriodInHours = frequencyPeriodInHours;
            ConsumptionPeriodHours = consumptionPeriodHours;
            StartDateTime = startDateTime;
        }

        public BloodConsumptionConfiguration(uint frequencyPeriodInHours, TimeSpan consumptionPeriodHours, DateTime startDateTime)
        {
            FrequencyPeriodInHours = frequencyPeriodInHours;
            ConsumptionPeriodHours = consumptionPeriodHours;
            StartDateTime = startDateTime;
        }

        public BloodConsumptionConfiguration()
        {
        }
    }
}
