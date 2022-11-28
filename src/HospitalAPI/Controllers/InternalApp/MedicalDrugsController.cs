using HospitalAPI.Connections;
using HospitalAPI.Web.Mapper;
using HospitalLibrary.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Controllers.InternalApp
{
    [Route("api/internal/[controller]")]
    [ApiController]
    public class MedicalDrugsController : ControllerBase
    {
        private readonly IMedicalDrugsService _medicalDrugsService;

        public MedicalDrugsController(IMedicalDrugsService medicalDrugsService)
        {
            _medicalDrugsService = medicalDrugsService;
        }

        // GET: api/rooms
        [HttpGet]
        public ActionResult GetAll()
        {

            return Ok(_medicalDrugsService.GetAll());
        }
    }
}
