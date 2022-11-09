using HospitalLibrary.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Model
{
    public class BloodUnit : ITherapySubject
    {
        public BloodType BloodType { get; set; }
        public int AmountMl { get; set; }

        public BloodUnit()
        {
        }

        public BloodUnit(int id, BloodType bloodType, int amountMl)
        {
            Id = id;
            BloodType = bloodType;
            AmountMl = amountMl;
        }

        public string Print()
        {
            throw new NotImplementedException();
        }
    }
}
