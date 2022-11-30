using IntegrationAPI.ConnectionService.Interface;
using Microsoft.AspNetCore.Mvc;

namespace IntegrationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BloodController : Controller
    {
        private readonly IHospitalHTTPConnectionService hospitalHTTPConnectionService;

        public BloodController(IHospitalHTTPConnectionService hospitalHTTPConnectionService)
        {
            this.hospitalHTTPConnectionService = hospitalHTTPConnectionService;
        }

        // GET: api/rooms
        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(hospitalHTTPConnectionService.GetAllBlood());
        }

    }
}
