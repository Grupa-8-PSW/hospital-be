using AutoMapper;
using HospitalAPI;
using HospitalAPI.Controllers;
using HospitalAPI.Controllers.InternalApp;
using HospitalAPI.DTO;
using HospitalAPI.Web.Dto;
using HospitalAPI.Web.Mapper;
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

namespace HospitalTests.HospitalAPITests.Integration
{
    public class ExaminationDoneTests : BaseIntegrationTest
    {
        public ExaminationDoneTests(TestDatabaseFactory<Startup> factory) : base(factory) { }

        private static ExaminationDoneController SetupController(IServiceScope scope)
        {
            return new ExaminationDoneController(scope.ServiceProvider.GetRequiredService<IExaminationDoneService>(), scope.ServiceProvider.GetRequiredService<IMapper<ExaminationDone, ExaminationDoneDTO>>());
        }

        [Fact]
        public void Do_examination()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupController(scope);

            ExaminationDoneDTO examinationDoneDTO = new ExaminationDoneDTO(0, 1, new ExaminationDTO(), new List<Symptom>(),
                "record", new List<Prescription>());

            var result = ((CreatedAtActionResult)controller.Create(examinationDoneDTO))?.Value as ExaminationDoneDTO;

            Assert.NotNull(result);
            Assert.IsType<ExaminationDoneDTO>(result);
        }

        [Fact]
        public void Get_all_symptoms_from_database()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupController(scope);

            var result = ((OkObjectResult)controller.GetAllSymptoms())?.Value as List<Symptom>;

            Assert.NotNull(result);
            Assert.IsType<List<Symptom>>(result);
            Assert.NotEmpty(result);
        }
    }
}
