using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Core.Service.Interfaces;
using IntegrationLibrary.Core.Service;
using IntegrationAPI.Mapper;
using IntegrationLibrary.Core.Model.ValueObject;

namespace IntegrationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenderController : ControllerBase
    {

        private readonly ITenderService _service;

        public TenderController(ITenderService service)
        {
            _service = service;
        }

        // POST: TenderController/Create
        [HttpPost]
        public String Create(Tender tender)
        {
            if (!ModelState.IsValid)
            {
                Console.WriteLine(ModelState);
            }

            try
            {
                _service.Create(tender);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return "Error in creation";
            }

            return "Success";
        }

        // POST: TenderController/getAllForOffers
        [HttpGet]
        [Route("getAllBloodAmountsBetweenDates")]
        public ActionResult GetAllBloodAmountsBetweenDates(DateTime from, DateTime to)
        {
            
            return Ok(_service.GetAllBloodAmountsBetweenDates(from, to));
        }

        [Route("/api/[controller]/generatePdf")]
        [HttpGet]
        public async Task<IActionResult> GeneratePdf()
        {
            DateTime fromDate = new DateTime(2022, 12, 09);
            DateTime toDate = new DateTime(2022, 12, 22);
            //return File(await _service.GeneratePdf(_urgentRequestService.GetSummarizedUrgentRequests(fromDate, toDate), fromDate, toDate), "application/pdf", "urgentrequestreport.pdf");
            return Ok();
        }


    }
}
