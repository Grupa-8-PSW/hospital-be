using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using HospitalLibrary.Core.Service;
using HospitalLibrary.Core.Model;

namespace HospitalAPI.Controllers.InternalApp
{
    [EnableCors("InternAllow")]
    [Route("api/internal/[controller]")]
    [Authorize(Roles = "Manager")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpGet("statistic")]
        public ActionResult<AppointmentStatistic> GetStatistic()
        {
            return Ok(_appointmentService.GetStatistic());
        }
    }
}
