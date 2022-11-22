using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalLibrary.Core.Enums;

namespace IntegrationLibrary.Core.Model
{
    public class BloodUnit
    {
        public int Id { get; set; }
        public DateTime DatePrescribed { get; set; }
        public BloodType BloodType { get; set; }
        public int Amount { get; set; }

        public BloodUnit()
        {
        }

        public BloodUnit(int id, DateTime datePrescribed, BloodType bloodType, int amount)
        {
            Id = id;
            DatePrescribed = datePrescribed;
            BloodType = bloodType;
            Amount = amount;
        }
    }
}
