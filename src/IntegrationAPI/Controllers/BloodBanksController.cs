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
        private readonly IEmailService _emailService;
        private readonly ICredentialGenerator _credentialGenerator;

        public BloodBanksController(IBloodBankService bloodBankService,  IEmailService emailService, ICredentialGenerator credentialGenerator)
        {
            _bloodBankService = bloodBankService;
            _emailService = emailService;
            _credentialGenerator = credentialGenerator;
        }

        // GET: api/bloodBanks
        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_bloodBankService.GetAll());
            return Ok();
        }

        // POST api/bloodBanks
        [HttpPost]
        public ActionResult Create(BloodBank bloodBank)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            bloodBank.APIKey = _credentialGenerator.GenerateAPI();
            bloodBank.Password = _credentialGenerator.GeneratePassword();


            _bloodBankService.Create(bloodBank);
            _emailService.SendEmail(bloodBank.Email, bloodBank.Password, bloodBank.APIKey);


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
