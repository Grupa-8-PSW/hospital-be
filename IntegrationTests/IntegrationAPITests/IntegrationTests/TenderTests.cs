using IntegrationAPI.ConnectionService.Interface;
using IntegrationAPI.Controllers;
using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Core.Model.DTO;
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

namespace IntegrationTests.IntegrationAPITests.IntegrationTests
{
    public class TenderTests : BaseIntegrationTests
    {
        public TenderTests(TestDatabaseFactory<IntegrationAPI.Startup> databaseFactory) : base(databaseFactory)
        {

        }
        private static TenderController SetupController(IServiceScope scope)
        {
            return new TenderController(scope.ServiceProvider.GetRequiredService<ITenderService>());
        }

        [Fact]
        public void GetActiveTenders()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = SetupController(scope);
            PrepareBase();

            // Act
            var retVal = controller.GetAllForOffers() as OkObjectResult;

            //Assert
            IEnumerable<TenderOfferDTO> activeTenders = (IEnumerable<TenderOfferDTO>)retVal.Value;
            Assert.IsType<OkObjectResult>(retVal);
            Assert.NotNull(retVal);
            Assert.True(activeTenders.Count().Equals(2));
        }


        private void PrepareBase()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupController(scope);
            List<IntegrationLibrary.Core.Model.Blood> bs = new List<IntegrationLibrary.Core.Model.Blood>();
            bs.Add(new IntegrationLibrary.Core.Model.Blood(HospitalLibrary.Core.Enums.BloodType.A_POSITIVE, 1));

            controller.Create(new Tender(TenderStatus.Active, new DateRange(new DateTime(2022, 12, 3), new DateTime(2022, 12, 15)), bs));
            controller.Create(new Tender(TenderStatus.Active, new DateRange(new DateTime(2022, 12, 3), new DateTime(2022, 12, 15)), bs));
            controller.Create(new Tender(TenderStatus.Inactive, new DateRange(new DateTime(2022, 12, 3), new DateTime(2022, 12, 15)), bs));

        }
    }
}
