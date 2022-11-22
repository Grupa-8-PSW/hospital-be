using IntegrationLibrary.Core.Model.DTO;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Org.BouncyCastle.Asn1.Cms;

using static Org.BouncyCastle.Bcpg.Attr.ImageAttrib;


namespace IntegrationLibrary.Core.Model
{
    public class BloodConsumptionConfiguration
    {
        public int Id { get; set; }
        [Required]

        public DateTime StartDateTime { get; set; }
        public TimeSpan FrequencyPeriodInHours { get; set; }
        public TimeSpan ConsumptionPeriodHours { get; set; }


        public BloodConsumptionConfiguration(int id, DateTime startDateTime, TimeSpan frequencyPeriodInHours, TimeSpan consumptionPeriodHours)
        {
            this.Id = id;
            this.StartDateTime = startDateTime;
            this.FrequencyPeriodInHours = frequencyPeriodInHours;
            this.ConsumptionPeriodHours = consumptionPeriodHours;
        }

        public BloodConsumptionConfiguration( DateTime startDateTime, TimeSpan frequencyPeriodInHours, TimeSpan consumptionPeriodHours)
        {
            this.StartDateTime = startDateTime;
            this.FrequencyPeriodInHours = frequencyPeriodInHours;
            this.ConsumptionPeriodHours = consumptionPeriodHours;
        }


        public BloodConsumptionConfiguration(DateTime startDateTime)
        {
            this.StartDateTime = startDateTime;
        }

        public BloodConsumptionConfiguration()
        {
        }

        public BloodConsumptionConfiguration(BloodConsumptionReportDTO dto)
        {
            String dateTimeFormat = "dd/MMM/yyyy HH:mm:ss";
            var StartDateTime1 = DateTime.ParseExact(dto.StartDate+" "+dto.StartTime, dateTimeFormat, new CultureInfo("en-GB")).ToUniversalTime();
            this.StartDateTime = DateTime.SpecifyKind(StartDateTime1, DateTimeKind.Utc);
            
            this.ConsumptionPeriodHours = new TimeSpan((int)dto.ConsumptionPeriodHours, 0, 0);
            this.FrequencyPeriodInHours = new TimeSpan((int)dto.FrequencyPeriodInHours, 0, 0);
        }

    }
}
