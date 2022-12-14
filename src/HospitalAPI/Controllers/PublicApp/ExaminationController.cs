using AutoMapper;
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
        private readonly IExaminationService _examinationService;

        public ExaminationController(
            IMapper mapper,
            IExaminationService examinationService)
        {
            _mapper = mapper;
            _examinationService = examinationService;
        }

        [HttpPost]
        public ActionResult Create(ExaminationDTO examinationDTO)
        {
            var examination = _mapper.Map<Examination>(examinationDTO);
            _examinationService.Create(examination);
            return Ok();
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
