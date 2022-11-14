using IntegrationTeamTests.Setup;
using System;
using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using IntegrationAPI.Controllers;
using HospitalLibrary.GraphicalEditor.Service.Interfaces;
using IntegrationAPI;
using IntegrationLibrary.Core.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Core.Model.DTO;

namespace IntegrationTeamTests.Integration
{
    public class BloodConsumptionConfigurationTests: BaseIntegrationTests
    {
        public BloodConsumptionConfigurationTests(TestDatabaseFactory<Startup> factory) : base(factory) { }

        private static BloodConsumptionConfigurationController SetupController(IServiceScope scope)
        {
            return new BloodConsumptionConfigurationController(scope.ServiceProvider.GetRequiredService<IBloodConsumptionConfigurationService>());
        }

        [Fact]
        public void CreateDaily()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupController(scope);

            BloodConsumptionReportDTO dto = new BloodConsumptionReportDTO
            {

            };

            BloodConsumptionConfiguration retVal = controller.CreateConfiguration(dto);
            Assert.NotNull(retVal);

        }
    }
}