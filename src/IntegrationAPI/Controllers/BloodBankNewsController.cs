using IntegrationLibrary.Core.Model;
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

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            return Ok(_bloodBankNewsService.GetById(id));
        }


        [HttpPut]
        [Route("archiveNews")]
        public ActionResult ArchiveNews([FromBody] BloodBankNews bloodBankNews)
        {
            _bloodBankNewsService.ArchiveNews(bloodBankNews);
            return Ok();
        }

        [HttpPut]
        [Route("publishNews")]
        public ActionResult PublishNews([FromBody] BloodBankNews bloodBankNews)
        {
            _bloodBankNewsService.PublishNews(bloodBankNews);
            return Ok();
        }
    }
}
