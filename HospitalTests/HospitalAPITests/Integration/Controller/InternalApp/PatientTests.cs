using AutoMapper;
using HospitalAPI;
using HospitalAPI.Controllers.InternalApp;
using HospitalAPI.DTO;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Service;
using HospitalTests.HospitalAPITests.Setup;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;

namespace HospitalTests.HospitalAPITests.Integration.Controller.InternalApp
{
    public class PatientTests : BaseIntegrationTest
    {
        public PatientTests(TestDatabaseFactory<Startup> factory) : base(factory) { }

        private static PatientController SetupController(IServiceScope scope)
        {
            return new PatientController(scope.ServiceProvider.GetRequiredService<IPatientService>(), scope.ServiceProvider.GetRequiredService<IMapper>());
        }

        [Fact]
        public void Retrieves_age_statistic()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupController(scope);

            var result = ((OkObjectResult)controller.GetAgeStatistic())?.Value as AgeStatisticDTO;

            result.ShouldNotBeNull();
        }
    }
}
