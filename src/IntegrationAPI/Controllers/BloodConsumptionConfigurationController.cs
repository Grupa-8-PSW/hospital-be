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
        public BloodConsumptionConfiguration CreateConfiguration([FromBody] BloodConsumptionReportDTO dto)
        {
            return _service.Create(new BloodConsumptionConfiguration()
            {
                ConsumptionPeriodHours = dto.ConsumptionPeriodHours,
                FrequencyPeriodInHours = dto.FrequencyPeriodInHours,
                StartDateTime = dto.StartDate,
            });

        }

        [Route("/api/[controller]/generateSeveral")]
        [HttpPost]
        public IActionResult GenerateSeveralPdfs()
        {
            FileContentResult pdf = null;
            BloodUnit2 bu1 = new BloodUnit2(1, BloodType.AB_NEGATIVE, 20, DateTime.Now.AddHours(17));
            BloodUnit2 bu2 = new BloodUnit2(2, BloodType.A_NEGATIVE, 150, DateTime.Now.AddDays(7));
            BloodUnit2 bu3 = new BloodUnit2(3, BloodType.B_NEGATIVE, 200, DateTime.Today);
            BloodUnit2 bu4 = new BloodUnit2(4, BloodType.ZERO_NEGATIVE, 450, DateTime.Now.AddHours(20));
            BloodUnit2 bu5 = new BloodUnit2(5, BloodType.A_POSITIVE, 30, DateTime.Now.AddDays(15));
            List<BloodUnit2> buList = new List<BloodUnit2>();
            buList.Add(bu1);
            buList.Add(bu2);
            buList.Add(bu3);
            buList.Add(bu4);
            buList.Add(bu5);
            List<BloodUnit2> list = new List<BloodUnit2>();

            TimeSpan duration = new TimeSpan(250, 0, 0);
            DateTime startDateTime = new DateTime(2022, 11, 30, 20, 0, 0);

            BloodConsumptionConfiguration bcc = new BloodConsumptionConfiguration(1, 10, duration, startDateTime);


            DateTime sumTime = bcc.StartDateTime.Subtract(duration);

            foreach (BloodUnit2 unit in buList)
            {
                if ((sumTime < unit.consumptionDate) && (unit.consumptionDate < startDateTime))
                {

                    list.Add(unit);
                    var consta = _service.GeneratePdf(bcc, list);
                    pdf = File(consta, "application/vnd", "bloodconsumptionreport.pdf");
                }

            }

            return pdf;
    }

}
}
