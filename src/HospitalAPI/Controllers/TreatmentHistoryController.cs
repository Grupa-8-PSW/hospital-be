using HospitalAPI.Web.Dto;
using HospitalAPI.Web.Mapper;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TreatmentHistoryController : ControllerBase
    {
        private readonly ITreatmentHistoryService _treatmentHistoryService;
  //      private readonly IDoctorService _doctorService;
   //     private readonly IMapper<Examination, ExaminationDTO> _examinationMapper;

        public TreatmentHistoryController(ITreatmentHistoryService treatmentHistoryService)
        {
            _treatmentHistoryService = treatmentHistoryService;
        }

        // GET: api/rooms
        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_treatmentHistoryService.GetAll());
        }

        // GET api/rooms/2
        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var examination = _treatmentHistoryService.GetById(id);
            if (examination == null)
            {
                return NotFound();
            }

            return Ok(examination);
        }

        // POST api/rooms
        [HttpPost]
        public ActionResult Create(TreatmentHistory treatmentHistory)     //DTO!
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

        //    Doctor doctor = _doctorService.GetById(examinationDTO.DoctorId);

       //     Examination examination = _examinationMapper.toModel(examinationDTO);
        //    examination.RoomId = doctor.RoomId;

            bool succes = _treatmentHistoryService.Create(treatmentHistory);
            if (!succes)
            {
                return BadRequest("Poruka .....");
            }
            return CreatedAtAction("GetById", new { id = treatmentHistory.Id });//, _examinationMapper.toDTO(examination));
        }

        // PUT api/rooms/2
        [HttpPut("{id}")]
        public ActionResult Update(int id, TreatmentHistory treatmentHistory)   //DTO
        {
           /* Examination examination = _examinationMapper.toModel(examinationDTO);
            examination.RoomId = doctor.RoomId;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != examination.Id)
            {
                return BadRequest();
            }
            bool succes;
            try
            {
                succes = _treatmentHistoryService.Update(examination);
            }
            catch (Exception e1)
            {
                return BadRequest();
            }
            if (!succes)
            {
                return BadRequest("Poruka .....");
            }*/
            return Ok(treatmentHistory);
        }

        // DELETE api/rooms/2
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var examination = _treatmentHistoryService.GetById(id);
            if (examination == null)
            {
                return NotFound();
            }

            _treatmentHistoryService.Delete(examination);
            return NoContent();
        }
    }
}
