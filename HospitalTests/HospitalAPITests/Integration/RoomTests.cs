using HospitalAPI;
using HospitalAPI.Controllers.Map;
using HospitalLibrary.GraphicalEditor.Model;
using HospitalLibrary.GraphicalEditor.Model.DTO;
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
