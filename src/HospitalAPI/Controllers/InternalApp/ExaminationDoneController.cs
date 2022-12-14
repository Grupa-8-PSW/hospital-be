using HospitalAPI.DTO;
using HospitalAPI.Requests;
using HospitalAPI.Web.Dto;
using HospitalAPI.Web.Mapper;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Controllers.InternalApp
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExaminationDoneController : ControllerBase
    {
        private readonly IExaminationDoneService _examinationDoneService;
        private readonly IMapper<ExaminationDone, ExaminationDoneDTO> _examinationDoneMapper;

        public ExaminationDoneController(IExaminationDoneService examinationDoneService,
            IMapper<ExaminationDone, ExaminationDoneDTO> mapper)
        {
            _examinationDoneService = examinationDoneService;
            _examinationDoneMapper = mapper;
        }

        // GET: api/rooms
        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_examinationDoneService.GetAll());
        }

        // GET api/rooms/2
        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var examination = _examinationDoneService.GetById(id);
            if (examination == null)
            {
                return NotFound();
            }

            return Ok(examination);
        }

        // POST api/rooms
        [HttpPost]
        public ActionResult Create(ExaminationDoneDTO examinationDoneDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            ExaminationDone examinationDone = _examinationDoneMapper.toModel(examinationDoneDTO);

            var success = _examinationDoneService.Create(examinationDone);
            if (!success)
            {
                return BadRequest("Poruka .....");
            }
            return CreatedAtAction("GetById", new
            {
                id = examinationDone.Id
            }, _examinationDoneMapper.toDTO(examinationDone));
        }

        // PUT api/rooms/2
        [HttpPut("{id}")]
        public ActionResult Update(int id, ExaminationDoneDTO examinationDoneDTO)
        {

            ExaminationDone examinationDone = _examinationDoneMapper.toModel(examinationDoneDTO);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != examinationDone.Id)
            {
                return BadRequest();
            }
            bool succes;
            try
            {
                succes = _examinationDoneService.Update(examinationDone);
            }
            catch (Exception e1)
            {
                return BadRequest();
            }
            if (!succes)
            {
                return BadRequest("Poruka .....");
            }
            return Ok(examinationDoneDTO);
        }

        // DELETE api/rooms/2
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var examinationDone = _examinationDoneService.GetById(id);
            if (examinationDone == null)
            {
                return NotFound();
            }

            _examinationDoneService.Delete(examinationDone);
            return NoContent();
        }

        [HttpGet("symptoms")]
        public ActionResult GetAllSymptoms()
        {
            return Ok(_examinationDoneService.GetAllSymptoms());
        }
    }
}
