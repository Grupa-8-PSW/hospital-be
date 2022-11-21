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
        public String StartTime { get; set; }
        public String StartDate { get; set; }

        public uint FrequencyPeriodInHours { get; set; }
        
        public uint ConsumptionPeriodHours { get; set; }

    }
}
