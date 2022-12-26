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
    public class BloodOffer  : ValueObject<BloodOffer>
    {
        public string BloodType { get; set; }
        public int BloodAmount { get; set; }
        public Money Price { get; set; }


        public BloodOffer(string bloodType, int bloodAmount, Money price)
        {
            BloodType = bloodType;
            BloodAmount = bloodAmount;
            Price = price;
            // Validate();
        }

        public BloodOffer(string bloodType, int bloodAmount)
        {
            BloodType = bloodType;
            BloodAmount = bloodAmount;
        }

        public BloodOffer() { }


        public void Validate()
        {
            if (BloodAmount < 0 || BloodAmount ==null || BloodType == null ) throw new Exception("Wrong data");
        }

        // protected override bool EqualsCore(Blood other)
        // {
        //     throw new NotImplementedException();
        // }

        protected override int GetHashCodeCore()
        {
            throw new NotImplementedException();
        }

        protected override bool EqualsCore(BloodOffer other)
        {
            throw new NotImplementedException();
        }
    }
}
