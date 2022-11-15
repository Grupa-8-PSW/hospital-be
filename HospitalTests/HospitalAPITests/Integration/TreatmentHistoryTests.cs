﻿using HospitalAPI;
using HospitalAPI.Controllers;
using HospitalAPI.Controllers.Map;
using HospitalAPI.DTO;
using HospitalAPI.Web.Mapper;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Service;
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
    public class TreatmentHistoryTests : BaseIntegrationTest
    {
        public TreatmentHistoryTests(TestDatabaseFactory<Startup> factory) : base(factory) { }

        private static TreatmentHistoryController SetupController(IServiceScope scope)
        {
            return new TreatmentHistoryController(scope.ServiceProvider.GetRequiredService<ITreatmentHistoryService>(), scope.ServiceProvider.GetRequiredService<IMapper<TreatmentHistory, TreatmentHistoryDTO>>());
        }

        [Fact]
        public void Create_history_of_treatment()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupController(scope);

            TreatmentHistoryDTO treatmentHistoryDTO = new TreatmentHistoryDTO(1, "reason");

            var result = ((CreatedAtActionResult)controller.Create(treatmentHistoryDTO, 1))?.Value as TreatmentHistory;

            Assert.NotNull(result);
            Assert.IsType<TreatmentHistory>(result);
        }

    }
}
