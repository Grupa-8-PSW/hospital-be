using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Core.Service.Interfaces;
using IntegrationLibrary.Core.Service;
using IntegrationAPI.Mapper;

namespace IntegrationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenderController : ControllerBase
    {

        private readonly ITenderService _service;

        public TenderController(ITenderService service)
        {
            _service = service;
        }

        // POST: TenderController/Create
        [HttpPost]
        public void Create(Tender tender)
        {
            if (!ModelState.IsValid)
            {
                Console.WriteLine(ModelState);
            }
            _service.Create(tender);
        }

        // POST: TenderController/getAllForOffers
        [HttpGet]
        [Route("getAllBloodAmountsBetweenDates")]
        public ActionResult GetAllBloodAmountsBetweenDates(DateTime from, DateTime to)
        {
            
            return Ok(_service.GetAllBloodAmountsBetweenDates(from, to));
        }


       
    }
}
