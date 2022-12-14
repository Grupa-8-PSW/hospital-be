using AutoMapper;
using HospitalAPI.Security;
using HospitalAPI.Web.Dto;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Service;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Controllers.PublicApp
{
    [Route("api/public/[controller]")]
    [ApiController]
    public class ExaminationController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAppointmentService _appointmentService;
        private readonly IDoctorService _doctorService;
        private readonly IExaminationService _examinationService;
        private readonly IPatientService _patientService;

        public ExaminationController(
            IMapper mapper,
            IExaminationService examinationService,
            IDoctorService doctorService,
            IPatientService patientService)
        {
            _mapper = mapper;
            _examinationService = examinationService;
            _doctorService = doctorService;
            _patientService = patientService;
        }

        [HttpPost]
        public ActionResult Create(ExaminationDTO examinationDTO)
        {
            var userId = User.UserId();
            var patient = _patientService.GetByUserId(userId);
            examinationDTO.PatientId = patient.Id;
            var examination = _mapper.Map<Examination>(examinationDTO);
            examination.RoomId = _doctorService.GetById(examinationDTO.DoctorId).RoomId;
            _examinationService.Create(examination);
            return Ok();
        }

    }
}
