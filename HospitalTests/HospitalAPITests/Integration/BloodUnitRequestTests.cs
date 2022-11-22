using HospitalAPI.Controllers;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Service;
using HospitalTests.HospitalAPITests.Setup;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalAPI;
using HospitalAPI.Controllers.InternalApp;
using AutoMapper;
using HospitalAPI.DTO;
using HospitalAPI.Web.Mapper;
using HospitalAPI.Connections;
using HospitalLibrary.Core.Enums;
using Shouldly;
using System.Collections;

namespace HospitalTests.HospitalAPITests.Integration
{
    public class BloodUnitRequestTests : BaseIntegrationTest
    {
        public BloodUnitRequestTests(TestDatabaseFactory<Startup> factory) : base(factory) { }
        private static BloodUnitRequestController SetupController(IServiceScope scope)
        {
            return new BloodUnitRequestController(scope.ServiceProvider.GetRequiredService<IBloodUnitRequestService>(), scope.ServiceProvider.GetRequiredService<IMapper<BloodUnitRequest, BloodUnitRequestDTO>>());
        }


        [Fact]
        public void Creates_blood_unit_request()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupController(scope);


            var resultBloodUnitRequestBefore = ((OkObjectResult)controller.GetAll())?.Value as IEnumerable<BloodUnitRequest>;
            int bloodUnitRequestBefore = resultBloodUnitRequestBefore.Count();

            BloodUnitRequestDTO bloodUnitRequestDTO = new BloodUnitRequestDTO() {Id = 1, Type = "ZERO_POSITIVE", AmountL = 5, Reason = "kbv", CreationDate = "23/11/2022", Status = BloodUnitRequestStatus.WAITING, DoctorId=1, ManagerComment=""};

            var result = ((CreatedAtActionResult)controller.Create(bloodUnitRequestDTO))?.Value as BloodUnitRequest;

            var resultBloodUnitRequestAfter = ((OkObjectResult)controller.GetAll())?.Value as IEnumerable<BloodUnitRequest>;
            int bloodUnitRequestAfter = resultBloodUnitRequestAfter.Count();

            Assert.NotNull(result);
            Assert.True(result.Id == bloodUnitRequestDTO.Id);
            Assert.True(bloodUnitRequestBefore + 1 == bloodUnitRequestAfter);
        }

        [Theory]
        [ClassData(typeof(BloodUnitRequestTestData))]
        public void Doctor_updates_blood_unit_request(BloodUnitRequestDTO bloodUnitRequest, bool expectedDataBasechange)
        {
            //ARANGE
            using var scope = Factory.Services.CreateScope();
            var controller = SetupController(scope);
            BloodUnitRequest? createdRequest;
            BloodUnitRequestDTO createdForUpdate = ArrangeRequestForUpdate(out createdRequest, bloodUnitRequest);
            
            //ACT
            controller.UpdateUnclearRequest(createdForUpdate);
            BloodUnitRequestDTO updated = ((OkObjectResult)controller.GetById(createdRequest.Id))?.Value as BloodUnitRequestDTO;

            //ASSERT
            ChangedInDataBase(updated, createdForUpdate).ShouldBe(expectedDataBasechange);
        }

        private BloodUnitRequestDTO ArrangeRequestForUpdate(out BloodUnitRequest result, BloodUnitRequestDTO bloodUnitRequestDTO)
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupController(scope);
            result = ((CreatedAtActionResult)controller.Create(bloodUnitRequestDTO))?.Value as BloodUnitRequest;
            BloodUnitRequestDTO createdForUpdate = ((OkObjectResult)controller.GetById(result.Id))?.Value as BloodUnitRequestDTO;
            createdForUpdate.CreationDate = new DateTime(2022, 5, 5).ToString("dd/MM/yyyy");
            createdForUpdate.AmountL = 600;
            createdForUpdate.Reason = "changed_reason";
            createdForUpdate.Type = "ZERO_NEGATIVE";
            return createdForUpdate;
        }

        private bool ChangedInDataBase(BloodUnitRequestDTO createdForUpdate, BloodUnitRequestDTO updated)
        {
            return(updated.Id == createdForUpdate.Id
                     && updated.AmountL == createdForUpdate.AmountL
                     && updated.Type == createdForUpdate.Type
                     && updated.Reason == createdForUpdate.Reason
            );
        }
    }
    public class BloodUnitRequestTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            BloodUnitRequestDTO bloodUnitWaitingRequest = new() { Type = "ZERO_POSITIVE", AmountL = 5, Reason = "kbv", CreationDate = "23/11/2022", Status = BloodUnitRequestStatus.WAITING, DoctorId = 1, ManagerComment = "" };
            BloodUnitRequestDTO bloodUnitApprovedRequest = new() { Type = "ZERO_POSITIVE", AmountL = 5, Reason = "kbv", CreationDate = "23/11/2022", Status = BloodUnitRequestStatus.APPROVED, DoctorId = 1, ManagerComment = "" };
            BloodUnitRequestDTO bloodUnitRejectedRequest = new() { Type = "ZERO_POSITIVE", AmountL = 5, Reason = "kbv", CreationDate = "23/11/2022", Status = BloodUnitRequestStatus.REJECTED, DoctorId = 1, ManagerComment = "" };
            BloodUnitRequestDTO bloodUnitUnclearRequest = new() { Type = "ZERO_POSITIVE", AmountL = 5, Reason = "kbv", CreationDate = "23/11/2022", Status = BloodUnitRequestStatus.REVIEWAGAIN, DoctorId = 1, ManagerComment = "" };
            yield return new object[] { bloodUnitWaitingRequest, true };
            yield return new object[] { bloodUnitApprovedRequest, false };
            yield return new object[] { bloodUnitRejectedRequest, false };
            yield return new object[] { bloodUnitUnclearRequest, true };

        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
