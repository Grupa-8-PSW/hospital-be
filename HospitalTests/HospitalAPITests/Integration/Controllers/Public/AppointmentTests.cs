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
using Castle.Core.Resource;
using Newtonsoft.Json;
using HospitalLibrary.Core.Model;

namespace HospitalTests.HospitalAPITests.Integration.Controllers.Public
{
    public class AppointmentTests : BaseIntegrationTest
    {
        public AppointmentTests(TestDatabaseFactory<Startup> factory) : base(factory) { }

        private static ExaminationController SetupController(IServiceScope scope)
        {
            return new ExaminationController(scope.ServiceProvider.GetRequiredService<IMapper>(), scope.ServiceProvider.GetRequiredService<IAppointmentService>(), scope.ServiceProvider.GetRequiredService<IExaminationService>());
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

        [Fact]
        public void Cancels_appointment()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupController(scope);

            var result = controller.CancelAppointment(6);

            result.ShouldNotBeNull();
            result.ShouldBeOfType(typeof(OkObjectResult));
            ((OkObjectResult)result).Value.ShouldBeOfType(typeof(bool));
            ((OkObjectResult)result).Value.ShouldBe(true);
        }

        [Fact]
        public void Fails_to_cancel_appointment()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupController(scope);

            var result = controller.CancelAppointment(1);

            result.ShouldNotBeNull();
            result.ShouldBeOfType(typeof(OkObjectResult));
            ((OkObjectResult)result).Value.ShouldBeOfType(typeof(bool));
            ((OkObjectResult)result).Value.ShouldBe(false);
        }
    }
}