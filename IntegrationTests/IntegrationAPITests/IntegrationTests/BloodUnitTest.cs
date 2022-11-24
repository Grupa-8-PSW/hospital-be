using HospitalLibrary.Core.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalAPI.Connections;
using IntegrationAPI;
using IntegrationAPI.ConnectionService.Interface;
using IntegrationAPI.Controllers;
using IntegrationLibrary.Core.Model;
using IntegrationTeamTests.Setup;
using Xunit;

namespace IntegrationTests.IntegrationAPITests.IntegrationTests
{
    public class BloodUnitTest
    {

        public class BloodUnitTests : BaseIntegrationTests
        {
            public BloodUnitTests(TestDatabaseFactory<Startup> databaseFactory) : base(databaseFactory)
            {
            }

            private static BloodUnitController SetupController(IServiceScope scope)
            {
                return new BloodUnitController(scope.ServiceProvider.GetRequiredService<IHospitalHTTPConnectionService>());
            }

            private IEnumerable<BloodUnit> GetAllBloodUnits()
            {
                using var scope = Factory.Services.CreateScope();
                BloodUnitController controller = SetupController(scope);

                return ((OkObjectResult)controller.GetAll())?.Value as IEnumerable<BloodUnit>;
            }


            [Fact]
            public void Retrieves_All_Blood_Units()
            {
                IEnumerable<BloodUnit> allNews = GetAllBloodUnits();

                allNews.ShouldNotBeNull();
            }

        }
    }
}
