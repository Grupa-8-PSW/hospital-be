using HospitalLibrary.Core.Enums;
using IntegrationLibrary.Core.Model.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace IntegrationTests.IntegrationAPITests.UnitTests
{
    public class BloodValueObjectTest
    {
        [Fact]
        public void CreateBlood()
        {

            IntegrationLibrary.Core.Model.ValueObject.Blood blood = new IntegrationLibrary.Core.Model.ValueObject.Blood(BloodType.A_POSITIVE, 12);
            Assert.NotNull(blood);

        }

        [Fact]
        public void CreatBloodWithWrongBloodAmount()
        {

            try
            {
                IntegrationLibrary.Core.Model.ValueObject.Blood bloodOffer = new IntegrationLibrary.Core.Model.ValueObject.Blood(BloodType.A_POSITIVE, -12);

            }
            catch (Exception ex)
            {
                Assert.Contains("Wrong Data", ex.Message);
            }

        }
    }
}
