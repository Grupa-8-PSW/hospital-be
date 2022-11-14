﻿using IntegrationAPI.ExceptionHandler.Validators;
using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Core.Model.DTO;
using IntegrationLibrary.Core.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http.Description;

namespace IntegrationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BloodConsumptionConfigurationController : ControllerBase
    {
        private readonly IBloodConsumptionConfigurationService _service;

        public BloodConsumptionConfigurationController(IBloodConsumptionConfigurationService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult CreateConfiguration([FromBody] BloodConsumptionReportDTO dto)
        {

            return Ok(_service.Create(new BloodConsumptionConfiguration()
            {
                ConsumptionPeriodHours = dto.ConsumptionPeriodHours,
                FrequencyPeriodInHours = dto.FrequencyPeriodInHours,
                StartDate = dto.StartDate,
                StartTime = dto.StartTime
            }));

        }
    }
}
