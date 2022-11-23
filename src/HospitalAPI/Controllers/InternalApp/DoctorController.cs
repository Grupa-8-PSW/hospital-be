using AutoMapper;
using HospitalAPI.DTO;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Service;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Controllers.InternalApp
{
    [EnableCors("InternAllow")]
    [Route("api/internal/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IDoctorService _doctorService;

        public DoctorController(IDoctorService doctorService, IMapper mapper)
        {
            _doctorService = doctorService;
            _mapper = mapper;
        }

        // GET: api/Doctor
        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_mapper.Map<List<DoctorDTO>>(_doctorService.GetAll()));
        }

    }
}
