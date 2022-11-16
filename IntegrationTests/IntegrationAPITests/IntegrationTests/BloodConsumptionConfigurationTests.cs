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
using System.Net.Http;
using Shouldly;

namespace IntegrationTeamTests.Integration
{

    public class BloodConsumptionConfigurationTests: BaseIntegrationTests
    {
        private readonly HttpClient _httpClient = new() { BaseAddress = new Uri("https://localhost:7133") };
        
        public BloodConsumptionConfigurationTests(TestDatabaseFactory<Startup> factory) : base(factory) { }

        private static BloodConsumptionConfigurationController SetupController(IServiceScope scope)
        {
            return new BloodConsumptionConfigurationController(scope.ServiceProvider.GetRequiredService<IBloodConsumptionConfigurationService>());
        }


        [Fact]
        public async void BloodConsumptionConfiguration()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = SetupController(scope);

            BloodConsumptionReportDTO dto = new BloodConsumptionReportDTO
            {
                ConsumptionPeriodHours = 12,
                StartDate = "11/Nov/2022",
                StartTime = "11:11:00",
                FrequencyPeriodInHours = 12

            };

            // Act
            var retVal = controller.CreateConfiguration(dto) as OkObjectResult;

            
            // Assert
            BloodConsumptionConfiguration createdBloodConsumptionConfiguration = (BloodConsumptionConfiguration)retVal.Value;
            
            Assert.IsType<OkObjectResult>(retVal);
            Assert.True(ValidateObjectWritenInBase(dto, createdBloodConsumptionConfiguration));
            
            
        }


        private bool ValidateObjectWritenInBase(BloodConsumptionReportDTO dto, BloodConsumptionConfiguration retVal)
        {
            BloodConsumptionConfiguration bloodConsumptionConfiguration = new BloodConsumptionConfiguration(dto);

            if (retVal.StartDateTime.Equals(bloodConsumptionConfiguration.StartDateTime)
                && retVal.ConsumptionPeriodHours.Equals(bloodConsumptionConfiguration.ConsumptionPeriodHours)
                && retVal.FrequencyPeriodInHours.Equals(bloodConsumptionConfiguration.FrequencyPeriodInHours))
                return true;
            else
                return false;

        } 
    }
}