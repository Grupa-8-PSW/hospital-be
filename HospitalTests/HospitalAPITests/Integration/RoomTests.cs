using HospitalAPI;
using HospitalAPI.Controllers.Map;
using HospitalLibrary.GraphicalEditor.Model;
using HospitalLibrary.GraphicalEditor.Model.DTO;
using HospitalLibrary.GraphicalEditor.Service.Interfaces;
using HospitalTests.HospitalAPITests.Setup;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

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

        //[Fact]
        //public void Finds_rooms_with_free_beds() {
        //  var result = ((OkObjectResult)controller.GetFreeRooms())?.Value as List<RoomDTO>;

        //  Assert.NotNull(result);
        //  Assert.IsType<List<RoomDTO>>(result);
        //  Assert.NotEmpty(result);
        //}

        [Fact]
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
        }

        [Fact]
        public void Finds_rooms_with_free_beds()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupController(scope);

            var result = ((OkObjectResult)controller.GetFreeRooms())?.Value as List<RoomDTO>;

            Assert.NotNull(result);
            Assert.IsType<List<RoomDTO>>(result);
            Assert.NotEmpty(result);
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

        [Fact]
        public void Dates_for_trainsfering_equipments()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupController(scope);
            EquipmentTransferDTO dto = new EquipmentTransferDTO(1, 1, 2, new DateTime(2022, 11, 22, 00, 00, 00, DateTimeKind.Utc), new DateTime(2022, 11, 23, 00, 00, 00, DateTimeKind.Utc), 120, "Zavoji");
            var freeSpace = ((OkObjectResult)controller.GetAvailableTerminsForTransfer(dto))?.Value as List<FreeSpaceDTO>;

            Assert.NotNull(freeSpace);
        }

    }
}
