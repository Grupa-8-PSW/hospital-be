using HospitalLibrary.GraphicalEditor.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalLibrary.Core.Enums;

namespace HospitalLibrary.Core.Model
{
    public class BloodUnitRequest
    {
        public int Id { get; set; }
        public BloodType Type { get; set; }
        public int AmountL { get; set; }
        public string Reason { get; set; }
        public DateTime CreationDate { get; set; }

        public BloodUnitRequest()
        {
        }

        public BloodUnitRequest(int id, BloodType type, int amountL, string reason, DateTime creationDate)
        {
            Id = id;
            Type = type;
            AmountL = amountL;
            Reason = reason;
            CreationDate = creationDate;
        }
    }
}
