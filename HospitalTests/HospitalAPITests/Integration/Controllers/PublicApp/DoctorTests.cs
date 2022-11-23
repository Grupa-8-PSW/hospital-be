using AutoMapper;
using HospitalAPI;
using HospitalAPI.Controllers.InternalApp;
using HospitalAPI.Controllers.PublicApp;
using HospitalAPI.DTO;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Service;
using HospitalTests.HospitalAPITests.Setup;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;

namespace HospitalTests.HospitalAPITests.Integration.Controller.InternalApp
{
    public class DoctorTests : BaseIntegrationTest
    {
        public DoctorTests(TestDatabaseFactory<Startup> factory) : base(factory) { }

        private static DoctorController SetupController(IServiceScope scope)
        {
            return new DoctorController(scope.ServiceProvider.GetRequiredService<IDoctorService>(),scope.ServiceProvider.GetRequiredService<IPatientService>(), scope.ServiceProvider.GetRequiredService<IMapper>());
        }

        [Fact]
        public void getsAllGeneralPracticioners()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupController(scope);

            var result = ((OkObjectResult)controller.GetAllGeneralPracticioners());

            result.ShouldNotBeNull();
        }
        [Fact]
        public void GetsAvailableGeneralPracticioners()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupController(scope);

            var result = ((OkObjectResult)controller.GetAllAvailableGeneralPracticioners());

            result.ShouldNotBeNull();
        }
    }
}
