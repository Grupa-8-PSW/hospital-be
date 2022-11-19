using HospitalAPI.Controllers.Map;
using HospitalLibrary.GraphicalEditor.Model;
using HospitalLibrary.GraphicalEditor.Service.Interfaces;
using HospitalTests.HospitalAPITests.Setup;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalAPI;
using HospitalAPI.Controllers;
using HospitalLibrary.Core.Service;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Enums;

namespace HospitalTests.HospitalAPITests.Integration
{
    public class TherapyTests : BaseIntegrationTest
    {
        public TherapyTests(TestDatabaseFactory<Startup> factory) : base(factory) { }
        private static TherapyController SetupController(IServiceScope scope)
        {
            return new TherapyController(scope.ServiceProvider.GetRequiredService<ITherapyService>());
        }


        [Fact]
        public void Creates_therapy()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupController(scope);

            var resultAllTherapiesBefore = ((OkObjectResult)controller.GetAll())?.Value as IEnumerable<Therapy>;
            int therapiesBefore = resultAllTherapiesBefore.Count();

            Therapy therapy = new Therapy() { Id = 4, WhenPrescribed = DateTime.UtcNow, Amount = 50, Reason = "reason2",  DoctorId = 1 };


            var result = ((CreatedAtActionResult)controller.Create(therapy))?.Value as Therapy;

            var resultAllTherapiesAfter = ((OkObjectResult)controller.GetAll())?.Value as IEnumerable<Therapy>;
            int therapiesAfter = resultAllTherapiesAfter.Count();

            Assert.NotNull(result);
            Assert.True(result.Id == therapy.Id);
            Assert.True(therapiesBefore + 1 == therapiesAfter);

        }
    }
}
