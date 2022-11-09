using IntegrationLibrary.Core.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace IntegrationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BloodBankNewsController : ControllerBase
    {
        private readonly IBloodBankNewsService _bloodBankNewsService;

        public BloodBankNewsController(IBloodBankNewsService bloodBankNewsService)
        {
            _bloodBankNewsService = bloodBankNewsService;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_bloodBankNewsService.GetAll());
        }
    }
}
