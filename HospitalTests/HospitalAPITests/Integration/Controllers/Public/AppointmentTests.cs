using HospitalAPI.Controllers.InternalApp;
using HospitalAPI.Controllers.PublicApp;
using HospitalAPI.DTO;
using HospitalLibrary.Core.Service;
using HospitalTests.HospitalAPITests.Setup;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using HospitalAPI;
using Shouldly;

namespace HospitalTests.HospitalAPITests.Integration.Controllers.Public
{
    public class AppointmentTests : BaseIntegrationTest
    {
        public AppointmentTests(TestDatabaseFactory<Startup> factory) : base(factory) { }

        private static AppointmentController SetupController(IServiceScope scope)
        {
            return new AppointmentController(scope.ServiceProvider.GetRequiredService<IExaminationService>(), scope.ServiceProvider.GetRequiredService<IMapper>());
        }

        [Fact]
        public void Retrieves_appointments()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupController(scope);

            var result = controller.GetAppointmentsForPatient();

            result.ShouldNotBeNull();
            result.ShouldBeOfType(typeof(OkObjectResult));
            ((OkObjectResult)result).Value.ShouldBeOfType(typeof(List<AppointmentDTO>));
        }
    }
}