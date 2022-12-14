using HospitalLibrary.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Core.Model.DTO
{
    public class BloodUnitDTO
    {
        public int Id { get; set; }
        public DateTime DatePrescribed { get; set; }
        public BloodType BloodType { get; set; }
        public int Amount { get; set; }

        public BloodUnitDTO()
        {
        }

        public BloodUnitDTO(int id, DateTime datePrescribed, BloodType bloodType, int amount)
        {
            Id = id;
            DatePrescribed = datePrescribed;
            BloodType = bloodType;
            Amount = amount;
        }
    }
}
