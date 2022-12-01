using System;
using HospitalLibrary.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalLibrary.Core.Enums;

namespace IntegrationLibrary.Core.Model
{
    public class Blood : ValueObject<Blood>
    {
        public BloodType BloodType { get; }

        public int Quantity { get; }

        public Blood(BloodType bloodType, int quantity)
        {
            Quantity = quantity;
            BloodType = bloodType;
        }

        protected override bool EqualsCore(Blood other)
        {
            return BloodType==other.BloodType && Quantity==other.Quantity;
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
