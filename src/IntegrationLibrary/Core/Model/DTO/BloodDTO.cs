using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalLibrary.Core.Enums;

namespace IntegrationLibrary.Core.Model.DTO
{
    public class BloodDTO
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public int Quantity { get; set; }

        public BloodDTO()
        {
        }

        public BloodDTO(int id, string bloodType, int quantity)
        {
            Id = id;
            Type = bloodType;
            Quantity = quantity;
        }
    }
}
