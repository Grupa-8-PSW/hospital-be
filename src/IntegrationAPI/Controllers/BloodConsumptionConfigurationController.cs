using System.Collections.ObjectModel;
using IntegrationAPI.ExceptionHandler.Validators;
using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Core.Model.DTO;
using IntegrationLibrary.Core.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using HospitalLibrary.Core.Enums;
using HospitalLibrary.Core.Model;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1.Cms;
using IntegrationAPI.ConnectionService.Interface;

namespace IntegrationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BloodConsumptionConfigurationController : ControllerBase
    {
        private readonly IBloodConsumptionConfigurationService _service;
        private readonly IHospitalHTTPConnectionService _hospitalHTTPConnectionService;

        public BloodConsumptionConfigurationController(IBloodConsumptionConfigurationService service, IHospitalHTTPConnectionService hospitalHTTPConnectionService)
        {
            _hospitalHTTPConnectionService = hospitalHTTPConnectionService;
            _service = service;
        }


        [HttpPost]
        public IActionResult CreateConfiguration([FromBody] BloodConsumptionReportDTO dto)
        {
            return Ok(_service.Create(new BloodConsumptionConfiguration(dto)));
        }

        [Route("/api/[controller]/generatePdf")]
        [HttpGet]
        public IActionResult GenerateSeveralPdf()
        {
            FileContentResult pdf = null;

            var validList =  _service.FindValidBloodUnits(_hospitalHTTPConnectionService.GetAllBloodUnits(), out var configuration);
            return File(_service.GeneratePdf(configuration.Last(), validList), "application/pdf", "bloodconsumptionreport.pdf");
        }
    }
}
