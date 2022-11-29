using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1.X509.Qualified;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Core.Model.ValueObject
{
    public class Money : ValueObject
    {
        decimal  Amount { get; }
        Currency Currency { get; }


        Money(decimal amount, Currency currency )
        {
            this.Amount = amount;
            this.Currency = currency;
        }

        Money Add(Money money)
        {
            //if(!IsSameCurrency(money)) throw new ...
            return new Money(Amount + money.Amount, Currency);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Amount;
            yield return Currency;
        }
    }
}
