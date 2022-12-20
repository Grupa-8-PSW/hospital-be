
using IntegrationLibrary.Core.Service;
using IntegrationLibrary.Core.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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

    }
}
