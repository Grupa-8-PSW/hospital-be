using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Core.Service.Interfaces;
using IntegrationLibrary.Core.Service;
using IntegrationAPI.Mapper;
using IntegrationLibrary.Core.Model.ValueObject;

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
        public String Create(Tender tender)
        {
            if (!ModelState.IsValid)
            {
                Console.WriteLine(ModelState);
            }

            try
            {
                _service.Create(tender);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return "Error in creation";
            }

            return "Success";
        }

        // POST: TenderController/getAllForOffers
        [HttpGet]
        [Route("getAllForOffers")]
        public ActionResult GetAllForOffers()
        {
            return Ok(TenderOfferMapper.convertTenderTOBloodOffersDTO(_service.GetActiveTenders()));
        }

        [HttpGet]
        [Route("getBloodForDates")]
        public void GetBloodForDates()
        {
            foreach (BloodOffer offer in _service.GetBloodFromTenders(new DateTime(2022, 12, 21),
                         new DateTime(2022, 12, 28)))
            {
                Console.WriteLine(offer.BloodType);
            }
        }

    }
}
