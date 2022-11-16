using AutoMapper;
using HospitalAPI.DTO;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Service;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Controllers.InternalApp
{
    [Route("api/internal/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService, IMapper mapper)
        {
            _mapper = mapper;
            _patientService = patientService;
        }

        // GET: api/Patient
        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_mapper.Map<List<PatientDTO>>(_patientService.GetAll()));
        }


        [HttpGet("ageStatistic")]
        public ActionResult GetAgeStatistic()
        {
            return Ok(_mapper.Map<AgeStatisticDTO>(_patientService.GetAgeStatistic()));
        }
    }
}
