using HospitalLibrary.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Core.Model
{
    public class Blood
    {
        public int Id { get; set; }
        public BloodType Type { get; set; }
        public int Quantity { get; set; }

        public Blood()
        {
        }

        public Blood(int id, BloodType bloodType, int quantity)
        {
            Id = id;
            Type = bloodType;
            Quantity = quantity;
        }
    }
}
