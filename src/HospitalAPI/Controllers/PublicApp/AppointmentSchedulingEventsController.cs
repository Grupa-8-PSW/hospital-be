using AutoMapper;
using HospitalAPI.DTO;
using HospitalLibrary.Core.Enums;
using HospitalLibrary.Core.Service;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Controllers.PublicApp
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentSchedulingEventsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAppointmentSchedulingEventsService _service;

        [HttpPost("sessionStarted")]
        public ActionResult SaveSessionStartedEvent()
        {
            _service.SaveSessionStartedEvent();
            return Ok();
        }

        [HttpPost("dateTime")]
        public ActionResult SaveDateTimeSelectedEvent(DateTime selectedDateTime)
        {
            _service.SaveDateTimeSelectedEvent(selectedDateTime);
            return Ok();
        }
    }
}
