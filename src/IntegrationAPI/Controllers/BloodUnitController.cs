using IntegrationAPI.ConnectionService.Interface;
using IntegrationLibrary.Core.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace IntegrationAPI.Controllers
{
    [Authorize]
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
