using HospitalAPI;
using HospitalAPI.Controllers.Map;
using HospitalLibrary.GraphicalEditor.Model.DTO;
using HospitalLibrary.GraphicalEditor.Service.Interfaces;
using HospitalTests.HospitalAPITests.Setup;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace HospitalTests.HospitalAPITests.Integration
{
    public class RoomSearchTests : BaseIntegrationTest
    {
        public RoomSearchTests(TestDatabaseFactory<Startup> factory) : base(factory) { }
        private static EquipmentController SetupController(IServiceScope scope)
        {
            return new EquipmentController(
                scope.ServiceProvider.GetRequiredService<IRoomService>(),
                scope.ServiceProvider.GetRequiredService<IEquipmentService>());
        }


        [Fact]
        public void Searches_all_rooms_with_empty_string()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupController(scope);

            var result = ((OkObjectResult)controller.Search(""))?.Value as List<RoomDTO>;

            Assert.NotNull(result);
            Assert.IsType<List<RoomDTO>>(result);
            Assert.True(result.Count.Equals(26));
            Assert.True(result[0].Name.Equals("Pedijatrija"));
        }

        [Fact]
        public void Searches_equipment_formtated()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupController(scope);

            var result = ((OkObjectResult)controller.Search(" krevet "))?.Value as List<RoomDTO>;

            Assert.NotNull(result);
            Assert.IsType<List<RoomDTO>>(result);
            Assert.True(result.Count.Equals(4));
            Assert.True(result[0].Name.Equals("Pedijatrija"));
        }

    }
}
