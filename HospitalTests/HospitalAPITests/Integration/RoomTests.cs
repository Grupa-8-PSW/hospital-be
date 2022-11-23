using HospitalAPI;
using HospitalAPI.Controllers.Map;
using HospitalAPI.DTO;
using HospitalLibrary.Core.Model;
using HospitalLibrary.GraphicalEditor.Model;
using HospitalLibrary.GraphicalEditor.Model.DTO;
using HospitalLibrary.GraphicalEditor.Service;
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

        [Fact]
        public void Finds_rooms_with_free_beds() {
          var result = ((OkObjectResult)controller.GetFreeRooms())?.Value as List<RoomDTO>;

          Assert.NotNull(result);
          Assert.IsType<List<RoomDTO>>(result);
          Assert.NotEmpty(result);
        }

        
        public void Searches_rooms_with_same_name()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupController(scope);
            var result = ((OkObjectResult)controller.Search("Magacin"))?.Value as List<RoomDTO>;

            Assert.NotNull(result);
            Assert.IsType<List<RoomDTO>>(result);
            Assert.True(result.Count.Equals(2));
            Assert.True(result[0].Name.Equals("Magacin"));
        }

        [Fact]
        public void Searches_all_rooms_with_empty_string()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupController(scope);

            var result = ((OkObjectResult)controller.Search(""))?.Value as List<RoomDTO>;

            Assert.NotNull(result);
            Assert.IsType<List<RoomDTO>>(result);
            Assert.True(result.Count.Equals(19));
            Assert.True(result[0].Name.Equals("Pedijatrija"));
        }

        [Fact]
        public void Searches_room_trimmed()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupController(scope);

            var result = ((OkObjectResult)controller.Search(" Hirurgija "))?.Value as List<RoomDTO>;

            Assert.NotNull(result);
            Assert.IsType<List<RoomDTO>>(result);
            Assert.True(result.Count.Equals(1));
            Assert.True(result[0].Name.Equals("Hirurgija"));
        }

        [Fact]
        public void Searches_room_truncated()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupController(scope);

            var result = ((OkObjectResult)controller.Search("Kafe"))?.Value as List<RoomDTO>;

            Assert.NotNull(result);
            Assert.IsType<List<RoomDTO>>(result);
            Assert.True(result.Count.Equals(1));
            Assert.True(result[0].Name.Equals("Kafeterija"));
        }

        [Fact]
        public void Searches_room_lowercase()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupController(scope);

            var result = ((OkObjectResult)controller.Search("fizio"))?.Value as List<RoomDTO>;

            Assert.NotNull(result);
            Assert.IsType<List<RoomDTO>>(result);
            Assert.True(result.Count.Equals(1));
            Assert.True(result[0].Name.Equals("Fizioterapeut"));
        }
    }
}
