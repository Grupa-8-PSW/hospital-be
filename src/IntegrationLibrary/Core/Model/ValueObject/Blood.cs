using System;
using HospitalLibrary.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalLibrary.Core.Enums;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace IntegrationLibrary.Core.Model.ValueObject
{
    public class Blood : ValueObject<Blood>
    {
        public BloodType BloodType { get; }

        public int Quantity { get; set; }

        public Blood(BloodType bloodType, int quantity)
        {
            Quantity = quantity;
            BloodType = bloodType;
            Validate();
        }



        private void Validate()
        {
            if (Quantity < 0 || BloodType == null)
                throw new Exception("Wrong Data");
        }

        protected override bool EqualsCore(Blood other)
        {
            return BloodType == other.BloodType && Quantity == other.Quantity;
        }


        protected override int GetHashCodeCore()
        {
            unchecked
            {
                int hashCode = BloodType.GetHashCode();
                hashCode ^= Quantity.GetHashCode();
                return hashCode;
            }
        }
    }
}
