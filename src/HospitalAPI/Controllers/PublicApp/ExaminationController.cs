using AutoMapper;
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

    }
}
