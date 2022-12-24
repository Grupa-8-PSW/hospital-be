using IntegrationTeamTests.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalLibrary.Core.Service;
using IntegrationAPI;
using IntegrationAPI.ConnectionService.Interface;
using IntegrationAPI.Controllers;
using IntegrationLibrary.Core.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using IntegrationLibrary.Core.Service.Interfaces;
using Shouldly;
using Xunit;
using IntegrationAPI.Connections;
using IntegrationLibrary.Core.Model.DTO;
using Moq;

namespace IntegrationTests.IntegrationAPITests.IntegrationTests
{
    public class HospitalHTTPConnectionTests : BaseIntegrationTests
    {
        public HospitalHTTPConnectionTests(TestDatabaseFactory<Startup> databaseFactory) : base(databaseFactory) { }

        private IEnumerable<BloodUnit> GetAllBloodUnits()
        {
            using var scope = Factory.Services.CreateScope();
            BloodUnitController controller = SetupController(scope);
            return ((OkObjectResult)controller.GetAll())?.Value as IEnumerable<BloodUnit>;
        }

        private static BloodUnitController SetupController(IServiceScope scope)
        {
            return new BloodUnitController(scope.ServiceProvider.GetRequiredService<IHospitalHTTPConnectionService>());
        }


        [Fact]
        public void Retrieves_All_BloodUnits()
        {
            IEnumerable<BloodUnit> allBloodUnits = GetAllBloodUnits();

            allBloodUnits.ShouldNotBeNull();
        }

        [Fact]
        public void Response()
        {
            /*var mock = new Mock<HospitalHTTPConnection>();
            HospitalHTTPConnection hospitalHTTPConnection = new HospitalHTTPConnection();
            List<BloodDTO> bloodDTOs = new List<BloodDTO>();
            BloodDTO blood = new BloodDTO(1,"ZERO_POSITIVE", 100);
            bloodDTOs.Add(blood);
            mock.Verify(n => n.RestockBlood(bloodDTOs));*/
            
        }
    }
}
