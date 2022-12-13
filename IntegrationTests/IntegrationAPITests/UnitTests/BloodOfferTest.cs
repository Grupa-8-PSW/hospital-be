using HospitalAPI;
using IntegrationAPI.Connections;
using IntegrationAPI.ConnectionService.Interface;
using IntegrationAPI.Controllers;
using IntegrationLibrary.Core.Model.DTO;
using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Core.Service.Interfaces;
using IntegrationTeamTests.Setup;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using IntegrationLibrary.Core.Model.ValueObject;

namespace IntegrationTests.IntegrationAPITests.UnitTests
{
    public class BloodOfferTest
    {
        [Fact]
        public void CreateBloodOffer()
        {
            BloodOffer bloodOffer = new BloodOffer("A-", 12, new Money(421, Currency.USD));

            Assert.NotNull(bloodOffer);
            
        }

        [Fact]
        public void CreatBloodOfferWithWrongBloodAmount()
        {
  
            try
            {
                BloodOffer bloodOffer = new BloodOffer("A-", -12, new Money(421, Currency.USD));

            }
            catch(Exception ex)
            {
                Assert.Contains("Wrong data", ex.Message);
            }

        }

        [Fact]
        public void CreatBloodOfferWithWrongPriceAmount()
        {

            try
            {
                BloodOffer bloodOffer = new BloodOffer("A-", 12, new Money(-421, Currency.USD));

            }
            catch (Exception ex)
            {
                Assert.Contains("Wrong data", ex.Message);
            }

        }

        [Fact]
        public void CreatBloodOfferWithNullAtribute()
        {

            try
            {
                BloodOffer bloodOffer = new BloodOffer(null, 12, new Money(-421, Currency.USD));

            }
            catch (Exception ex)
            {
                Assert.Contains("Wrong data", ex.Message);
            }

        }

    }
}