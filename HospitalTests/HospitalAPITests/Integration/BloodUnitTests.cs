using HospitalTests.HospitalAPITests.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalAPI;
using HospitalAPI.Controllers.InternalApp;
using HospitalAPI.DTO;
using HospitalAPI.Web.Mapper;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Service;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Microsoft.AspNetCore.Mvc;
using HospitalLibrary.Core.Enums;
using System.Collections;

namespace HospitalTests.HospitalAPITests.Integration
{
    public class BloodUnitTests : BaseIntegrationTest
    {
        public BloodUnitTests(TestDatabaseFactory<Startup> factory) : base(factory)
        {
        }

        private static BloodUnitController SetupController(IServiceScope scope)
        {
            return new BloodUnitController(scope.ServiceProvider.GetRequiredService<IBloodUnitService>());
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
