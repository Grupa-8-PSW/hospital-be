using HospitalAPI;
using HospitalAPI.Controllers.InternalApp;
using HospitalAPI.DTO;
using HospitalAPI.Web.Mapper;
using HospitalLibrary.Core.Service;
using HospitalTests.HospitalAPITests.Setup;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using HospitalLibrary.Core.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.ObjectModel;
using HospitalLibrary.Core.Enums;
using Shouldly;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace HospitalTests.HospitalAPITests.Integration
{
    public class BloodControllerTests : BaseIntegrationTest
    {
        public BloodControllerTests(TestDatabaseFactory<Startup> factory) : base(factory)
        {
        }
        private static BloodController SetupController(IServiceScope scope)
        {
            return new BloodController(
                scope.ServiceProvider.GetRequiredService<IBloodService>(),
                scope.ServiceProvider.GetRequiredService<IMapper<Blood, BloodDTO>>()
                );
        }

        [Fact]
        public void BloodController_GetsAllBloodFromDatabase()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupController(scope);

            Collection<BloodDTO> bloodCol = new();
            bloodCol.Add(new BloodDTO() { Id = 1, Quantity = 1000, Type = "A_POSITIVE" });
            bloodCol.Add(new BloodDTO() { Id = 2, Quantity = 1500, Type = "AB_NEGATIVE" });
            bloodCol.Add(new BloodDTO() { Id = 3, Quantity = 500, Type = "ZERO_NEGATIVE" });

            var result = controller.GetAll();

            var okResult = result.ShouldBeOfType<OkObjectResult>();
            var bloods = okResult.Value.ShouldBeOfType<Collection<BloodDTO>>();
            bloods.ShouldNotBeNull();
            bloods.ShouldBeEquivalentTo(bloodCol);
        }

        [Fact]
        public void BloodController_GetsBloodById()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupController(scope);

            var result = controller.GetById(1);

            var okResult = result.ShouldBeOfType<OkObjectResult>();
            var blood = okResult.Value.ShouldBeOfType<BloodDTO>();
            blood.ShouldNotBeNull();
            blood.Id.ShouldBeEquivalentTo(1);
            blood.Quantity.ShouldBeEquivalentTo(1000);
            blood.Type.ShouldBeEquivalentTo("A_POSITIVE");
        }

        [Fact, AutoRollback]
        public void BloodController_CreatesBlood()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupController(scope);

            var result = controller.Create(new Blood()
            {
                Id = 4,
                Quantity = 2000,
                Type = BloodType.ZERO_POSITIVE
            });

            var createdResult = result.ShouldBeOfType<CreatedAtActionResult>();
            var blood = createdResult.Value.ShouldBeOfType<BloodDTO>();
            blood.ShouldNotBeNull();
            blood.Id.ShouldBeEquivalentTo(4);
            blood.Quantity.ShouldBeEquivalentTo(2000);
            blood.Type.ShouldBeEquivalentTo("ZERO_POSITIVE");
        }

        [Fact, AutoRollback]
        public void BloodController_UpdatesBlood()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupController(scope);

            var result = controller.Update(3, new Blood()
            {
                Id = 3,
                Quantity = 4500,
                Type = BloodType.AB_POSITIVE
            });

            var okResult = result.ShouldBeOfType<OkObjectResult>();
            var blood = okResult.Value.ShouldBeOfType<BloodDTO>();
            blood.ShouldNotBeNull();
            blood.Id.ShouldBeEquivalentTo(3);
            blood.Quantity.ShouldBeEquivalentTo(4500);
            blood.Type.ShouldBeEquivalentTo("AB_POSITIVE");
        }

        [Fact, AutoRollback]
        public void BloodController_DeletesBlood()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupController(scope);

            var result = controller.Delete(2);

            var noContentResult = result.ShouldBeOfType<NoContentResult>();
            noContentResult.StatusCode.ShouldBeEquivalentTo((int)HttpStatusCode.NoContent);
        }
    }
}
