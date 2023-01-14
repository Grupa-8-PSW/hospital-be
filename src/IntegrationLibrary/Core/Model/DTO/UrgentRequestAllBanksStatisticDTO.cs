using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Core.Model.DTO
{
    public class UrgentRequestAllBanksStatisticDTO
    {
        public List<string> BloodBanks { get; set; }
        public List<double> Quantities { get; set; }

        public UrgentRequestAllBanksStatisticDTO()
        {
            BloodBanks = new List<string>();
            Quantities = new List<double>();   
        }
    }
}
