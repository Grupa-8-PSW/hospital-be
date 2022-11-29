using IntegrationAPI.ConnectionService.Interface;
using IntegrationLibrary.Core.Model;
using Microsoft.AspNetCore.Mvc;

namespace IntegrationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BloodUnitController : Controller
    {
        private readonly IHospitalHTTPConnectionService hospitalHTTPConnectionService;

        public BloodUnitController(IHospitalHTTPConnectionService hospitalHTTPConnectionService)
        {
            this.hospitalHTTPConnectionService = hospitalHTTPConnectionService;
        }

        // GET: api/rooms
        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(hospitalHTTPConnectionService.GetAllBloodUnits());
        }


    }
}
