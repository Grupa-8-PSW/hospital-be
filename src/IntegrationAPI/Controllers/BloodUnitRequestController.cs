using IntegrationAPI.ConnectionService.Interface;
using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Core.Model.DTO;
using IntegrationLibrary.Core.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace IntegrationAPI.Controllers
{

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BloodUnitRequestController : ControllerBase
    {
        private readonly IHospitalHTTPConnectionService hospitalHTTPConnectionService;

        public BloodUnitRequestController(IHospitalHTTPConnectionService hospitalHTTPConnectionService)
        {
            this.hospitalHTTPConnectionService = hospitalHTTPConnectionService;
        }

        // GET: api/rooms
        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(hospitalHTTPConnectionService.GetAllBloodUnitRequests());
        }

        [HttpPut]
        public ActionResult ChangeRequestStatus([FromBody] BloodUnitRequestDTO bloodUnitRequestDto)
        {
            hospitalHTTPConnectionService.ChangeRequestStatus(bloodUnitRequestDto);
            return Ok();
        }

        [HttpGet("{id}")]
        public ActionResult GetDoctorById(int id)
        {
            return Ok(hospitalHTTPConnectionService.GetDoctorById(id));
        }
        [HttpGet("/getAllDoctors")]
        public ActionResult GetAllDoctors()
        {
            return Ok(hospitalHTTPConnectionService.GetAllDoctors());
        }

    }
}
