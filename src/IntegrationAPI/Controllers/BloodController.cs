using IntegrationAPI.ConnectionService.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace IntegrationAPI.Controllers
{
    [Authorize]
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
