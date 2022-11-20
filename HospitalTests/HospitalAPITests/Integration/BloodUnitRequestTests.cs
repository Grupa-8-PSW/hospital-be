using HospitalAPI.Controllers;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Service;
using HospitalTests.HospitalAPITests.Setup;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalAPI;
using HospitalAPI.Controllers.InternalApp;
using AutoMapper;
using HospitalAPI.DTO;
using HospitalAPI.Web.Mapper;

namespace HospitalTests.HospitalAPITests.Integration
{
    public class BloodUnitRequestTests : BaseIntegrationTest
    {
        public BloodUnitRequestTests(TestDatabaseFactory<Startup> factory) : base(factory) { }
        private static BloodUnitRequestController SetupController(IServiceScope scope)
        {
            return new BloodUnitRequestController(scope.ServiceProvider.GetRequiredService<IBloodUnitRequestService>(), scope.ServiceProvider.GetRequiredService<IMapper<BloodUnitRequest, BloodUnitRequestDTO>>());
        }


        [Fact]
        public void Creates_blood_unit_request()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupController(scope);


            var resultBloodUnitRequestBefore = ((OkObjectResult)controller.GetAll())?.Value as IEnumerable<BloodUnitRequest>;
            int bloodUnitRequestBefore = resultBloodUnitRequestBefore.Count();

            BloodUnitRequestDTO bloodUnitRequestDTO = new BloodUnitRequestDTO() {Id = 1, Type = "ZERO_POSITIVE", Amount = 5, Reason = "kbv", CreationDate = "23/11/2022"};

            var result = ((CreatedAtActionResult)controller.Create(bloodUnitRequestDTO))?.Value as BloodUnitRequest;

            var resultBloodUnitRequestAfter = ((OkObjectResult)controller.GetAll())?.Value as IEnumerable<BloodUnitRequest>;
            int bloodUnitRequestAfter = resultBloodUnitRequestAfter.Count();

            Assert.NotNull(result);
            Assert.True(result.Id == bloodUnitRequestDTO.Id);
            Assert.True(bloodUnitRequestBefore + 1 == bloodUnitRequestAfter);
        }
    }
}
