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


namespace HospitalTests.HospitalAPITests.Integration.Controllers.InternalApp
{
    public class AppointmentControllerIntegrationTests : BaseIntegrationTest
    {
        public AppointmentControllerIntegrationTests(TestDatabaseFactory<Startup> factory) : base(factory) { }

        private static AppointmentController SetupController(IServiceScope scope)
        {
            var appointmentService = scope.ServiceProvider.GetRequiredService<IAppointmentService>();
            var appointmentEventService = scope.ServiceProvider.GetRequiredService<IAppointmentSchedulingEventsService>();
            return new AppointmentController(appointmentService, appointmentEventService);
        }

        [Fact]
        public void Get_appointment_statistics()
        {
            // Arange
            using var scope = Factory.Services.CreateScope();
            var controller = SetupController(scope);


            // Act
            var result = controller.GetStatistic();

            // Assert
            result.Result.ShouldBeOfType(typeof(OkObjectResult));
            var value = ((OkObjectResult)result.Result).Value as AppointmentEventStatisticDTO;
            value.AverageNumberOfStep.ShouldNotBe(0);
            value.AverageSecondsOfScheduling.ShouldNotBe(0);
            value.StepViewCountStatistic.Check().ShouldBe(true);
        }
    }
}
