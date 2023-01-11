using AutoMapper;
using HospitalAPI.DTO;
using HospitalAPI.Security;
using HospitalLibrary.Core.Enums;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Model.ValueObjects;
using HospitalLibrary.Core.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Controllers.PublicApp
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentSchedulingEventsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAppointmentSchedulingEventsService _service;
        private readonly IPatientService _patientService;

        public AppointmentSchedulingEventsController(IMapper mapper, IAppointmentSchedulingEventsService service, IPatientService patientService)
        {
            _mapper = mapper;
            _service = service;
            _patientService = patientService;
        }


        [HttpPost("sessionStarted")]
        [Authorize(Roles = "Patient")]
        public ActionResult<int> SaveSessionStartedEvent()
        {
            var userId = User.UserId();
            var patient = _patientService.GetByUserId(userId);
            int aggregateId = _service.SaveSessionStartedEvent(patient.Id);
            return Ok(aggregateId);
        }

        [HttpPost("dateTime")]
        [Authorize(Roles = "Patient")]
        public ActionResult SaveDateTimeSelectedEvent(DateEventDTO dateEventDto)
        {
            var userId = User.UserId();
            var patient = _patientService.GetByUserId(userId);
            _service.SaveDateTimeSelectedEvent(dateEventDto.AggregateId, patient.Id, dateEventDto.SelectedDate);
            return Ok();
        }

        [HttpPost("doctorSpecialization")]
        [Authorize(Roles = "Patient")]
        public ActionResult SaveDoctorSpecializationSelectedEvent(SpecializationEventDTO specializationEventDTO)
        {
            var userId = User.UserId();
            var patient = _patientService.GetByUserId(userId);
            _service.SaveDoctorSpecializationSelectedEvent(specializationEventDTO.AggregateId, patient.Id, specializationEventDTO.SelectedSpecialization);
            return Ok();
        }

        [HttpPost("doctor")]
        [Authorize(Roles = "Patient")]
        public ActionResult SaveDoctorSelectedEvent(DoctorEventDTO doctorEventDTO)
        {
            var userId = User.UserId();
            var patient = _patientService.GetByUserId(userId);
            _service.SaveDoctorSelectedEvent(doctorEventDTO.AggregateId, patient.Id, doctorEventDTO.SelectedDoctor);
            return Ok();
        }

        [HttpPost("appointment")]
        [Authorize(Roles = "Patient")]
        public ActionResult SaveAppointmentSelectedEvent(AppointmentEventDTO appointmentEventDTO)
        {
            var userId = User.UserId();
            var patient = _patientService.GetByUserId(userId);
            _service.SaveAppointmentSelectedEvent(appointmentEventDTO.AggregateId, patient.Id, appointmentEventDTO.SelectedSlot);
            return Ok();
        }

        [HttpPost("sessionEnded")]
        [Authorize(Roles = "Patient")]
        public ActionResult SaveAppointmentScheduledEvent(SessionEndEventDTO sessionEndEventDTO)
        {
            var userId = User.UserId();
            var patient = _patientService.GetByUserId(userId);
            _service.SaveAppointmentScheduledEvent(sessionEndEventDTO.AggregateId, patient.Id);
            return Ok();
        }
    }
}
