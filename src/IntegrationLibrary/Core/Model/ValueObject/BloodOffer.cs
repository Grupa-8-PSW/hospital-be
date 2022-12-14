using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IntegrationLibrary.Core.Model.ValueObject
{
    public class BloodOffer  : ValueObject<Blood>
    {
        public string BloodType { get; }
        public int BloodAmount { get; }
        public Money Price { get; }


        public BloodOffer(string bloodType, int bloodAmount, Money price)
        {
            BloodType = bloodType;
            BloodAmount = bloodAmount;
            Price = price;
            Validate();
        }


        public void Validate()
        {
            if (BloodAmount < 0 || BloodAmount ==null || BloodType == null ) throw new Exception("Wrong data");
        }

        protected override bool EqualsCore(Blood other)
        {
            throw new NotImplementedException();
        }

        protected override int GetHashCodeCore()
        {
            throw new NotImplementedException();
        }
    }
}
