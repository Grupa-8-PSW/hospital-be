using AutoMapper;
using HospitalAPI.DTO;
using HospitalLibrary.Core.Enums;
using HospitalLibrary.Core.Model.ValueObjects;
using HospitalLibrary.Core.Service;
using HospitalLibrary.Core.Util;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Controllers.PublicApp
{
    [Route("api/public/[controller]")]
    [ApiController]
    public class ExaminationController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAppointmentService _appointmentService;
        private readonly IExaminationService _examinationService;

        public ExaminationController(
            IMapper mapper,
            IAppointmentService appointmentService,
            IExaminationService examinationService)
        {
            _mapper = mapper;
            _appointmentService = appointmentService;
            _examinationService = examinationService;
        }

        [HttpGet("/recommend")]
        public ActionResult<List<AvailableAppointmentsDTO>> GetRecommendedExaminationTime(
            [FromQuery] DateTime start,
            [FromQuery] DateTime end,
            [FromQuery] int doctorId, 
            [FromQuery] AppointmentPriority priority)
        {
            if (start >= end)
                return BadRequest();
            var dateRange = new DateRange(start, end);
            var availableAppointments = _appointmentService.GetRecommendedAvailableAppointments(dateRange, doctorId, priority);
            return Ok(_mapper.Map<List<AvailableAppointmentsDTO>>(availableAppointments));
        }
        [HttpGet("/available/doctor-date")]
        public ActionResult<AvailableAppointmentsDTO> GetAvailableAppointmentsByDateDoctor(
            [FromQuery] DateTime date,
            [FromQuery] int doctorId)
        {
            var availableAppointments = _appointmentService.GetAvailableAppointments(date, doctorId);
            return Ok(_mapper.Map<AvailableAppointmentsDTO>(availableAppointments));
        }

        [HttpGet("patient")]
        [Authorize(Roles = "Patient")]
        public ActionResult GetAppointmentsForPatient()
        {
            return Ok(_mapper.Map<List<AppointmentDTO>>(_examinationService.GetByPatientId(1)));
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Patient")]
        public ActionResult CancelAppointment(int id)
        {
            bool isCancellable = _examinationService.CheckIfCancellable(id);
            if (!isCancellable)
            {
                return Ok(isCancellable);
            }
            else
            {
                return Ok(isCancellable);
            }
        }
    }
}
