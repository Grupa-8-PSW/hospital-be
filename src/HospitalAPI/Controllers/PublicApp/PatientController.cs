using AutoMapper;
using HospitalAPI.DTO;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Service;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Controllers.PublicApp
{
    [Route("api/[controller]")]
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
        

        [HttpGet]
        [Route ("{id}")]
        public ActionResult Get(int id)
        {
            var patient = _patientService.GetById(id);
            if(patient is not null)
            {
                return Ok(_mapper.Map<PatientDTO>(patient));
            }
            else
            {
                return NotFound();
            }
        }

    }
}
