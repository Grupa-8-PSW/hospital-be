using HospitalAPI.Web.Mapper;
using HospitalLibrary.Core.Model;
using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Core.Model.DTO;
using IntegrationLibrary.Core.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.ObjectModel;
using System.Data;

namespace IntegrationAPI.Controllers
{
    [Authorize]
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

        [AllowAnonymous]
        [HttpGet("published")]
        public ActionResult GetAllPublished()
        {
            return Ok(_bloodBankNewsService.GetAllPublished());
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
