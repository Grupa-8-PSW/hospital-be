using HospitalAPI;
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

namespace HospitalTests.HospitalAPITests.Integration
{
    public class RoomTests : BaseIntegrationTest
    {
        public RoomTests(TestDatabaseFactory<Startup> factory) : base(factory) { }
        private static RoomController SetupController(IServiceScope scope)
        {
            return new RoomController(scope.ServiceProvider.GetRequiredService<IRoomService>());
        }


        [Fact]
        public void Retrieves_single_room()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupController(scope);

            var result = ((OkObjectResult)controller.GetById(1))?.Value as Room;

            Assert.NotNull(result);
        }
    }
}
