using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HospitalAPI.Web.Dto;
using HospitalAPI.Web.Mapper;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalAPI.DTO;
using HospitalAPI.Mapper;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TherapyController : ControllerBase
    {
        private readonly ITherapyService _therapyService;
        private readonly IMapper<Therapy, TherapyDTO> _therapyMapper;

        public TherapyController(ITherapyService therapyService, IMapper<Therapy, TherapyDTO> therapyMapper)
        {
            _therapyService = therapyService;
            _therapyMapper = therapyMapper;
        }

        // GET: api/rooms
        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_therapyService.GetAll());
        }

        // GET api/rooms/2
        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var therapy = _therapyService.GetById(id);
            if (therapy == null)
            {
                return NotFound();
            }

            return Ok(therapy);
        }

       

        // POST api/rooms
        [HttpPost]
        public ActionResult Create(TherapyDTO therapyDTo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Therapy therapy = _therapyMapper.toModel(therapyDTo);
            if(therapy == null)
            {
                return BadRequest("Poruka .....");
            }


            bool succes = _therapyService.Create(therapy);
            if (!succes)
            {
                return BadRequest("Poruka .....");
            }
            return CreatedAtAction("GetById", new { id = therapy.Id }, therapy);
        }

        // PUT api/rooms/2
        [HttpPut("{id}")]
        public ActionResult Update(int id, Therapy therapy)
        {
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != therapy.Id)
            {
                return BadRequest();
            }
            bool succes;
            try
            {
                succes = _therapyService.Update(therapy);
            }
            catch (Exception e1)
            {
                return BadRequest();
            }
            if (!succes)
            {
                return BadRequest("Poruka .....");
            }
            return Ok(therapy);
        }

       
    }
}
