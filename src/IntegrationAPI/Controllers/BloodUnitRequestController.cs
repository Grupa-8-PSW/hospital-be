using IntegrationAPI.ConnectionService.Interface;
using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Core.Model.DTO;
using IntegrationLibrary.Core.Service;
using IntegrationLibrary.Core.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace IntegrationAPI.Controllers
{

    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BloodUnitRequestController : ControllerBase
    {
        private readonly IHospitalHTTPConnectionService hospitalHTTPConnectionService;
        private readonly IUrgentRequestService _urgentRequestService;

        public BloodUnitRequestController(IHospitalHTTPConnectionService hospitalHTTPConnectionService, IUrgentRequestService urgentRequestService)
        {
            this.hospitalHTTPConnectionService = hospitalHTTPConnectionService;
            _urgentRequestService = urgentRequestService;
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

        [HttpGet("/findBetweenDate")]
        //resiti zakomentarisan authorize
        public ActionResult FindUrgentRequestsBetweenDates(DateTime fromDate, DateTime toDate)
        {
            //DateTime fromDate = new DateTime(2022, 12, 09);
            //DateTime toDate = new DateTime(2022, 12, 22);
            return Ok(_urgentRequestService.FindUrgentRequestsBetweenDates(fromDate, toDate));
        }

    }
}
