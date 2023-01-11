using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using HospitalLibrary.Core.Service;
using HospitalLibrary.Core.Model;
using HospitalAPI.DTO;

namespace HospitalAPI.Controllers.InternalApp
{
    [EnableCors("InternAllow")]
    [Route("api/internal/[controller]")]
    [Authorize(Roles = "Manager")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IAppointmentSchedulingEventsService _appointmentSchedulingEventsService;

        public AppointmentController(IAppointmentService appointmentService, IAppointmentSchedulingEventsService appointmentSchedulingEventsService)
        {
            _appointmentService = appointmentService;
            _appointmentSchedulingEventsService = appointmentSchedulingEventsService;
        }

        [HttpGet("statistic")]
        public ActionResult<AppointmentEventStatisticDTO> GetStatistic()
        {
            var dto = new AppointmentEventStatisticDTO()
            {
                AverageNumberOfStep = _appointmentSchedulingEventsService.GetAverageNumberOfSteps(),
                AverageSecondsOfScheduling = _appointmentSchedulingEventsService.GetAverageDurationInMins(),
                StepViewCountStatistic = _appointmentSchedulingEventsService.NumberOfViewsForStep()
            };
            
            return Ok(dto);
        }
    }
}
