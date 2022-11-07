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
        public int Period { get; set; }
        public String StartTime { get; set; }
        public String StartDate { get; set; }

        public BloodConsumptionConfiguration( int period, String startTime, String startDate)
        {
            this.Period = period;
            this.StartDate = startDate;
            this.StartTime = startTime;        
        }

        public BloodConsumptionConfiguration()
        {
        }
    }
}
