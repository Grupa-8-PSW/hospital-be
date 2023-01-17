using IntegrationLibrary.Core.Model.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace IntegrationTests.IntegrationAPITests.UnitTests
{
    public class MoneyTests
    {
        [Fact]
        public void CreateMoney()
        {
            Money money = new Money(150, Currency.EUR);

            Assert.NotNull(money);
        }

        [Fact]
        public void CreatMoneyWithWrongPriceAmount()
        {

            try
            {
                Money money = new Money(-213, Currency.EUR);
            }
            catch (Exception ex)
            {
                Assert.Contains("Wrong data", ex.Message);
            }

        }

    }
}
