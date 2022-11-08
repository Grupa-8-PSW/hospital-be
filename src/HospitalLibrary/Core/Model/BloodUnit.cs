using HospitalLibrary.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Model
{
    public class BloodUnit
    {
        BloodType BloodType { get; set; }
        int AmountMl { get; set; }

        public BloodUnit()
        {
        }

        public BloodUnit(BloodType bloodType, int amountMl)
        {
            BloodType = bloodType;
            AmountMl = amountMl;
        }
    }
}
