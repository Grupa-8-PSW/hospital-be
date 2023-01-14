using HospitalLibrary.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Core.Model.DTO
{
    public class QuantitiesPerBloodTypeStatisticDTO
    {
        public List<BloodType> BloodTypes { get; set; }
        public List<double> Quantities { get; set; }

        public QuantitiesPerBloodTypeStatisticDTO()
        {
            BloodTypes = new List<BloodType>();
            Quantities = new List<double>();
        }
    }
}
