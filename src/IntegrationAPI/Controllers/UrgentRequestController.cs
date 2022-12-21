
using IntegrationLibrary.Core.Service;
using IntegrationLibrary.Core.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace IntegrationAPI.Controllers
{
   // [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UrgentRequestController : ControllerBase
    {
        private readonly IUrgentRequestService _urgentRequestService;
        public UrgentRequestController(IUrgentRequestService urgentRequestService)
        {
            _urgentRequestService = urgentRequestService;
        }

        [HttpGet]
        public ActionResult FindUrgentRequestsBetweenDates()
        {
            DateTime fromDate = new DateTime(2022, 12, 09);
            DateTime toDate = new DateTime(2022, 12, 22);
            return Ok(_urgentRequestService.FindUrgentRequestsBetweenDates(fromDate, toDate));
        }

        [Route("/api/[controller]/generatePdf")]
        [HttpGet]
        public IActionResult GeneratePdf()
        {
            DateTime fromDate = new DateTime(2022, 12, 09);
            DateTime toDate = new DateTime(2022, 12, 22);
            var validList = _urgentRequestService.FindUrgentRequestsBetweenDates(fromDate, toDate);
            return File(_urgentRequestService.GeneratePdf(validList, fromDate, toDate), "application/pdf", "urgentrequestreport.pdf");

        }

    }
}
