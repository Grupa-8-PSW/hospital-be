using AutoMapper;
using HospitalAPI.DTO;
using HospitalLibrary.Core.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Controllers.PublicApp
{

    [Route("api/[controller]")]
    [ApiController]

    public class AppointmentController : ControllerBase
    {
        private readonly IExaminationService _examinationService;
        private readonly IMapper _mapper;

        public AppointmentController(IExaminationService examinationService, IMapper mapper)
        {
            _examinationService = examinationService;
            _mapper = mapper;
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
            } else
            {
                return Ok(isCancellable);
            }
        }
    }
}
