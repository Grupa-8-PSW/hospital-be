using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Org.BouncyCastle.Asn1.Cms;

namespace IntegrationLibrary.Core.Model.DTO
{
    public class BloodConsumptionReportDTO
    {
        public TimeOnly StartTime { get; set; }
        public DateTime StartDate { get; set; }

        public uint FrequencyPeriodInHours { get; set; }
        
        public TimeSpan ConsumptionPeriodHours { get; set; }

    }
}
