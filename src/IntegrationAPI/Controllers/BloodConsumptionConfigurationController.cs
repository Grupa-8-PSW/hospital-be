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
using Org.BouncyCastle.Asn1.Cms;

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
            return Ok(_service.Create(new BloodConsumptionConfiguration(dto)));
        }

        [Route("/api/[controller]/generatePdf")]
        [HttpPost]
        public IActionResult GenerateSeveralPdf()
        {
            FileContentResult pdf = null;
            var bloodUnits = InitializateBloodUnit();
            List<BloodUnit2> validList = new List<BloodUnit2>();

            foreach (BloodConsumptionConfiguration bcc in _service.GetAll())
            {
                foreach (BloodUnit2 unit in bloodUnits)
                {
                    if ((bcc.StartDateTime.Subtract(bcc.ConsumptionPeriodHours) < unit.consumptionDate) && (unit.consumptionDate < bcc.StartDateTime))
                    {
                        validList.Add(unit);
                        pdf = File(_service.GeneratePdf(bcc, validList), "application/vnd", "bloodconsumptionreport.pdf");
                    }
                }
            }

            return pdf;
    }

        private static List<BloodUnit2> InitializateBloodUnit()
        {
            BloodUnit2 bu1 = new BloodUnit2(1, BloodType.AB_NEGATIVE, 20, DateTime.Now.AddHours(17));
            BloodUnit2 bu2 = new BloodUnit2(2, BloodType.A_NEGATIVE, 150, DateTime.Now.AddDays(12));
            BloodUnit2 bu3 = new BloodUnit2(3, BloodType.B_NEGATIVE, 200, DateTime.Today);
            BloodUnit2 bu4 = new BloodUnit2(4, BloodType.ZERO_NEGATIVE, 450, DateTime.Now.AddHours(20));
            BloodUnit2 bu5 = new BloodUnit2(5, BloodType.A_POSITIVE, 30, DateTime.Now.AddDays(40));
            List<BloodUnit2> buList = new List<BloodUnit2>();
            buList.Add(bu1);
            buList.Add(bu2);
            buList.Add(bu3);
            buList.Add(bu4);
            buList.Add(bu5);
            return buList;
        }
    }
}
