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
    public class BloodOffer
    {
        public string BloodType { get; }
        public int BloodAmount { get; }
        public Money Price { get; }


        public BloodOffer(string tip, int bloodAmount, decimal priceAmount)
        {
            BloodType = tip;
            BloodAmount = bloodAmount;
            Price = new Money(priceAmount, Currency.USD);
            Validate();

        }


        public void Validate()
        {
            if (BloodAmount < 0 || BloodAmount ==null || BloodType == null ) throw new Exception("Wrong data");
        }
    }
}
