using AutoMapper;
using HospitalAPI.DTO;
using HospitalAPI.Web.Dto;
using HospitalLibrary.Core.Model;
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
        private readonly IDoctorService _doctorService;
        private readonly IExaminationService _examinationService;

        public ExaminationController(
            IMapper mapper,
            IExaminationService examinationService,
            IDoctorService doctorService)
        {
            _mapper = mapper;
            _examinationService = examinationService;
            _doctorService = doctorService;
        }

        [HttpPost]
        public ActionResult Create(ExaminationDTO examinationDTO)
        {
            var examination = _mapper.Map<Examination>(examinationDTO);
            examination.RoomId = _doctorService.GetById(examinationDTO.DoctorId).RoomId;
            _examinationService.Create(examination);
            return Ok();
        }

        [HttpGet("patient")]
        [Authorize(Roles = "Patient")]
        public ActionResult GetExaminationsForPatient()
        {
            return Ok(_mapper.Map<List<ViewExaminationDTO>>(_examinationService.GetByPatientId(1)));
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Patient")]
        public ActionResult CancelExamination(int id)
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
