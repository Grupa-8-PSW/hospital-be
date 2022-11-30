using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1.X509.Qualified;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IntegrationLibrary.Core.Model.ValueObject
{
    public class Money 
    {
        public decimal  Amount { get; }
        public Currency Currency { get; }


        public Money(decimal amount, Currency currency )
        {
            this.Amount = amount;
            this.Currency = currency;
            Validate();
        }

        Money Add(Money money)
        {
            if (!IsSameCurrency(money) || Amount <0) throw new Exception("Wrong data");
            return new Money(Amount + money.Amount, Currency);
        }

        private Boolean IsSameCurrency(Money money)
        {
            if (money.Currency.Equals(Currency))
            {
                return true;
            }
            else
                return false;
        }

        private void Validate()
        {
            if (Amount < 0 || Amount == null || Currency == null)
                throw new Exception("Wrong data");
        }
    }
}
