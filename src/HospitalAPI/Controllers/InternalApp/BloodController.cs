using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Controllers.InternalApp
{
    [Route("api/internal/[controller]")]
    [ApiController]
    public class BloodController : ControllerBase
    {
        private readonly IBloodService _bloodService;

        public BloodController(IBloodService bloodService)
        {
            _bloodService = bloodService;
        }

        // api/internal/Blood
        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_bloodService.GetAll());
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

            return Ok(blood);
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
            return CreatedAtAction("GetById", new { id = bl.Id }, bl);
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

            return Ok(blood);
        }

    }
}
