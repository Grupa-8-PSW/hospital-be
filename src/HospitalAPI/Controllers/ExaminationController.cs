using HospitalAPI.Web.Dto;
using HospitalAPI.Web.Mapper;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExaminationController : ControllerBase
    {
        private readonly IExaminationService _examinationService;
        private readonly IDoctorService _doctorService;
        private readonly IMapper<Examination, ExaminationDTO> _examinationMapper;

        public ExaminationController(IExaminationService examinationService,
            IDoctorService doctorService,
            IMapper<Examination, ExaminationDTO> mapper)
        {
            _examinationService = examinationService;
            _doctorService = doctorService;
            _examinationMapper = mapper;
        }

        // GET: api/rooms
        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_examinationService.GetAll());
        }

        // GET api/rooms/2
        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var examination = _examinationService.GetById(id);
            if (examination == null)
            {
                return NotFound();
            }

            return Ok(examination);
        }

        [HttpGet("{day}/{month}/{year}")]
        public ActionResult GetByDate(int day, int month, int year)
        {
            DateTime selectedDate = new DateTime(year, month, day);
            var examinations = _examinationService.GetByDate(selectedDate);
            List<ExaminationDTO> examinationDTOs = new List<ExaminationDTO>();

            foreach (Examination examination in examinations)
            {
                examinationDTOs.Add(_examinationMapper.toDTO(examination));     //toDTO(lista)
            }

            return Ok(examinationDTOs);
        }

        // POST api/rooms
        [HttpPost]
        public ActionResult Create(ExaminationDTO examinationDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Doctor doctor = _doctorService.GetById(examinationDTO.DoctorId);

            Examination examination = _examinationMapper.toModel(examinationDTO);
            examination.RoomId = doctor.RoomId;

            bool succes = _examinationService.Create(examination);
            if (!succes)
            {
                return BadRequest("Poruka .....");
            }
            return CreatedAtAction("GetById", new { id = examination.Id }, _examinationMapper.toDTO(examination));
        }

        // PUT api/rooms/2
        [HttpPut("{id}")]
        public ActionResult Update(int id, ExaminationDTO examinationDTO)
        {
            Doctor doctor = _doctorService.GetById(examinationDTO.DoctorId);

            Examination examination = _examinationMapper.toModel(examinationDTO);
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
                succes = _examinationService.Update(examination);
            }
            catch (Exception e1)
            {
                return BadRequest();
            }
            if (!succes)
            {
                return BadRequest("Poruka .....");
            }
            return Ok(examination);
        }

        // DELETE api/rooms/2
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var examination = _examinationService.GetById(id);
            if (examination == null)
            {
                return NotFound();
            }

            _examinationService.Delete(examination);
            return NoContent();
        }


    }
}