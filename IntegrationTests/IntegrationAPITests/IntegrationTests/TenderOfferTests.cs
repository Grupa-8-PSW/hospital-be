using HospitalAPI;
using IntegrationAPI.ConnectionService.Interface;
using IntegrationAPI.Controllers;
using IntegrationLibrary.Core.Model.DTO;
using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Core.Service.Interfaces;
using IntegrationTeamTests.Setup;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using IntegrationLibrary.Core.Model.ValueObject;

namespace IntegrationTests.IntegrationAPITests.IntegrationTests
{
    public class TenderOfferTests : BaseIntegrationTests
    {
        public TenderOfferTests(TestDatabaseFactory<IntegrationAPI.Startup> databaseFactory) : base(databaseFactory)
        {
        }

        private static TenderOfferController SetupController(IServiceScope scope)
        {
            return new TenderOfferController(scope.ServiceProvider.GetRequiredService<ITenderOfferService>());
        }

        [Fact]
        public void CreateTenderOffer()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = SetupController(scope);
            TenderOfferDTO dto = new TenderOfferDTO()
            {
                TenderID = 1,
                BloodAmounts = new List<BloodOfferDTO>()
                {
                    new BloodOfferDTO()
                    {
                        BloodAmount = 2,
                        BloodType = "A+",
                        PriceAmount = 12
                    }
                }
            };

            // Act
            var retVal = controller.CreateTenderOffer(dto) as OkObjectResult;

            //Assert
            TenderOffer createdTenderOffer = (TenderOffer)retVal.Value;
            Assert.IsType<OkObjectResult>(retVal);
            Assert.NotNull(retVal);
            Assert.True(ValidateObjectWritenInBase(dto, createdTenderOffer));

        }

        private bool ValidateObjectWritenInBase(TenderOfferDTO dto, TenderOffer retVal)
        {
            if(dto.TenderID.Equals(retVal.TenderID) &&
                compareLists(dto.BloodAmounts, retVal.Offers))
                return true;

            return false;
        }

        private bool compareLists(List<BloodOfferDTO> boDTO, List<BloodOffer> bo)
        {
            for (int i = 0; i < boDTO.Count; i++)
            {
                if (!boDTO[i].BloodType.Equals(bo[i].BloodType) ||
                    !boDTO[i].BloodAmount.Equals(bo[i].BloodAmount) ||
                    !boDTO[i].PriceAmount.Equals(bo[i].Price.Amount))
                    return false;
            }
            return true;
        }
    }
}
