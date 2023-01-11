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
        //[Authorize(Roles = "Patient")]
        public ActionResult<int> SaveSessionStartedEvent()
        {
            //var userId = User.UserId();
            //var patient = _patientService.GetByUserId(userId);
            //int aggregateId = _service.SaveSessionStartedEvent(patient.Id);
            int aggregateId = _service.SaveSessionStartedEvent(1);
            return Ok(aggregateId);
        }

        [HttpPost("dateTime")]
        //[Authorize(Roles = "Patient")]
        public ActionResult SaveDateTimeSelectedEvent(int aggregateId, DateTime selectedDateTime)
        {
            //var userId = User.UserId();
            //var patient = _patientService.GetByUserId(userId);
            //_service.SaveDateTimeSelectedEvent(aggregateId, patient.Id, selectedDateTime);
            _service.SaveDateTimeSelectedEvent(aggregateId, 1, selectedDateTime);
            return Ok();
        }

        [HttpPost("doctorSpecialization")]
        //[Authorize(Roles = "Patient")]
        public ActionResult SaveDoctorSpecializationSelectedEvent(int aggregateId, DoctorSpecialization doctorSpecialization)
        {
            //var userId = User.UserId();
            //var patient = _patientService.GetByUserId(userId);
            //_service.SaveDoctorSpecializationSelectedEvent(aggregateId, patient.Id, doctorSpecialization);
            _service.SaveDoctorSpecializationSelectedEvent(aggregateId, 1, doctorSpecialization);
            return Ok();
        }

        [HttpPost("doctor")]
        //[Authorize(Roles = "Patient")]
        public ActionResult SaveDoctorSelectedEvent(int aggregateId, int doctorId)
        {
            //var userId = User.UserId();
            //var patient = _patientService.GetByUserId(userId);
            //_service.SaveDoctorSelectedEvent(aggregateId, patient.Id, doctorId);
            _service.SaveDoctorSelectedEvent(aggregateId, 1, doctorId);
            return Ok();
        }

        [HttpPost("appointment")]
        //[Authorize(Roles = "Patient")]
        public ActionResult SaveAppointmentSelectedEvent(int aggregateId, int appointmentId)
        {
            //var userId = User.UserId();
            //var patient = _patientService.GetByUserId(userId);
            //_service.SaveAppointmentSelectedEvent(aggregateId, patient.Id, appointmentId);
            _service.SaveAppointmentSelectedEvent(aggregateId, 1, appointmentId);
            return Ok();
        }

        [HttpPost("sessionEnded")]
        //[Authorize(Roles = "Patient")]
        public ActionResult SaveAppointmentScheduledEvent(int aggregateId, int appointmentId)
        {
            //var userId = User.UserId();
            //var patient = _patientService.GetByUserId(userId);
            //_service.SaveAppointmentScheduledEvent(aggregateId, patient.Id, appointmentId);
            _service.SaveAppointmentScheduledEvent(aggregateId, 1, appointmentId);
            return Ok();
        }
    }
}
