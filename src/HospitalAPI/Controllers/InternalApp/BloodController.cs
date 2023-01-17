using System.Collections.Immutable;
using HospitalAPI.DTO;
using HospitalAPI.Mapper;
using HospitalAPI.Web.Mapper;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.ObjectModel;

namespace HospitalAPI.Controllers.InternalApp
{
    [Route("api/internal/[controller]")]
    [ApiController]
    public class BloodController : ControllerBase
    {
        private readonly IBloodService _bloodService;
        private readonly IMapper<Blood, BloodDTO> _bloodMapper;  

        public BloodController(IBloodService bloodService, IMapper<Blood, BloodDTO> bloodMapper)
        {
            _bloodService = bloodService;
            _bloodMapper = bloodMapper;
        }

        // api/internal/Blood
        [HttpGet]
        public ActionResult GetAll()
        {
            var bloods = new Collection<Blood>(_bloodService.GetAll());
            return Ok(_bloodMapper.toDTO(bloods));
        }

        // api/internal/Blood/1
        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var blood = _bloodService.GetById(id);
            if (blood == null)
            {
                return NotFound();
            }

            return Ok(_bloodMapper.toDTO(blood));
        }

        // api/internal/Blood
        [HttpPost]
        public ActionResult Create(Blood blood)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var bl = _bloodService.Create(blood);
            return CreatedAtAction("GetById", new { id = bl.Id }, _bloodMapper.toDTO(bl));
        }

        // api/internal/Blood/1
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var blood = _bloodService.GetById(id);
            if (blood == null)
            {
                return NotFound();
            }

            _bloodService.Delete(id);
            return NoContent();
        }

        // api/internal/Blood/1
        [HttpPut("{id}")]
        public ActionResult Update(int id, Blood blood)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (blood.Id != id)
            {
                return BadRequest();
            }
            try
            {
                _bloodService.Update(id, blood);
            } 
            catch(Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return BadRequest(ex.Message);
            }

            return Ok(_bloodMapper.toDTO(blood));
        }

        [Route("restockBlood")]
        [HttpPut]
        public ActionResult UpdateBlood([FromBody]List<BloodDTO> bloodList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            foreach (BloodDTO blood in bloodList)
            {
                Blood newBlood = _bloodMapper.toModel(blood);
                try
                {
                    _bloodService.RestockBlood(newBlood.Id, newBlood);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.StackTrace);
                    return BadRequest(ex.Message);
                }
            }

            /*if (blood.Id != id)
            {
                return BadRequest();
            }*/


            return Ok(bloodList);
        }

    }
}
