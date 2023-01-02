using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Core.Model.DTO
{
    public class BloodOfferDTO
    {
        public string BloodType { get; set; }
        public decimal PriceAmount { get; set; }
        public int BloodAmount { get; set; }
    }
}
