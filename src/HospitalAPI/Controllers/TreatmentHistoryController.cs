using AutoMapper;
using HospitalAPI.DTO;
using HospitalAPI.Mapper;
using HospitalAPI.Web.Dto;
using HospitalAPI.Web.Mapper;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Service;
using HospitalLibrary.GraphicalEditor.Model.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.ObjectModel;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TreatmentHistoryController : ControllerBase
    {
        private readonly ITreatmentHistoryService _treatmentHistoryService;
        //      private readonly IDoctorService _doctorService;
        private readonly IMapper<TreatmentHistory, TreatmentHistoryDTO> _treatmentHistoryMapper;
        private readonly IMapper _patientMapper;

        public TreatmentHistoryController(ITreatmentHistoryService treatmentHistoryService, 
            IMapper<TreatmentHistory, TreatmentHistoryDTO> mapper,
            IMapper patientMapper)
        {
            _treatmentHistoryService = treatmentHistoryService;
            _treatmentHistoryMapper = mapper;
            _patientMapper = patientMapper;
        }

        // GET: api/rooms
        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_treatmentHistoryMapper.toDTO(new Collection<TreatmentHistory>(_treatmentHistoryService.GetAll().ToList())));
        }

        // GET api/rooms/2
        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var treatmentHistory = _treatmentHistoryService.GetById(id);
            if (treatmentHistory == null)
            {
                return NotFound();
            }
            TreatmentHistoryDTO treatmentHistoryDTO = _treatmentHistoryMapper.toDTO(treatmentHistory);

            return Ok(treatmentHistoryDTO);
        }

        // POST api/rooms
        [HttpPost]
        public ActionResult Create(TreatmentHistoryDTO treatmentHistoryDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            TreatmentHistory treatmentHistory = _treatmentHistoryMapper.toModel(treatmentHistoryDTO);
          //  int roomId = treatmentHistoryDTO.RoomId;

            bool succes = _treatmentHistoryService.Create(treatmentHistory);
            if (!succes)
            {
                return BadRequest("Poruka .....");
            }
            return CreatedAtAction("GetById", new { id = treatmentHistory.Id }, treatmentHistory);
        }

        // PUT api/rooms/2
        [HttpPut("{id}")]
        public ActionResult Update(int id, TreatmentHistoryDTO treatmentHistoryDTO)   //DTO
        {
             TreatmentHistory treatmentHistory = _treatmentHistoryMapper.toModel(treatmentHistoryDTO);
            // examination.RoomId = doctor.RoomId;
             if (!ModelState.IsValid)
             {
                 return BadRequest(ModelState);
             }

             if (id != treatmentHistory.Id)
             {
                 return BadRequest();
             }
             bool succes;
             try
             {
                 succes = _treatmentHistoryService.Update(treatmentHistory);
             }
             catch (Exception e1)
             {
                 return BadRequest();
             }
             if (!succes)
             {
                 return BadRequest("Poruka .....");
             }
            return Ok(treatmentHistory);
        }

        // PUT api/rooms/2
        [HttpPut("finish/{id}")]
        public ActionResult FinishTreatmentHistory(int id, TreatmentHistoryDTO treatmentHistoryDTO)   //DTO
        {
            TreatmentHistory treatmentHistory = _treatmentHistoryMapper.toModel(treatmentHistoryDTO);
            // examination.RoomId = doctor.RoomId;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != treatmentHistory.Id)
            {
                return BadRequest();
            }
            bool succes;
            try
            {
                succes = _treatmentHistoryService.FinishTreatmentHistory(treatmentHistory);
            }
            catch (Exception e1)
            {
                return BadRequest();
            }
            if (!succes)
            {
                return BadRequest("Poruka .....");
            }
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

        [HttpGet("withoutActiveTreatment")]
        public ActionResult GetPatientsWithoutActiveTreatmentHistory()
        {
            List<Patient> patients = _treatmentHistoryService.GetPatientsWithoutActiveTreatmentHistory().ToList();
            var patientsDTO = _patientMapper.Map<List<PatientDTO>>(patients);
            return Ok(patientsDTO);
        }

      /*  [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_mapper.Map<List<PatientDTO>>(_patientService.GetAll()));
        }*/
    }
}
