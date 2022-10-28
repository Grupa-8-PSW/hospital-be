using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IntegrationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BloodBanksController : ControllerBase
    {
        private readonly IBloodBankService _bloodBankService;

        public BloodBanksController(IBloodBankService bloodBankService)
        {
            _bloodBankService = bloodBankService;
        }

        // GET: api/bloodBanks
        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_bloodBankService.GetAll());
        }

        // POST api/bloodBanks
        [HttpPost]
        public ActionResult Create(BloodBank bloodBank)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _bloodBankService.Create(bloodBank);

            return Ok();
        }

        // DELETE api/rooms/2
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var bloodBank = _bloodBankService.GetById(id);
            if (bloodBank == null)
            {
                return NotFound();
            }

            _bloodBankService.Delete(bloodBank);
            return NoContent();
        }

    }
}
