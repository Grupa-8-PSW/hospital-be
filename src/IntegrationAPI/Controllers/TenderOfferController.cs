using IntegrationAPI.ExceptionHandler.Validators;
using IntegrationLibrary.Core.Model.DTO;
using IntegrationLibrary.Core.Model;
using Microsoft.AspNetCore.Mvc;
using IntegrationAPI.ConnectionService.Interface;
using IntegrationLibrary.Core.Service.Interfaces;
using Org.BouncyCastle.Asn1.X509;
using IntegrationLibrary.Core.Model.ValueObject;
using IntegrationAPI.Mapper;

namespace IntegrationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenderOfferController : ControllerBase
    {
        private readonly ITenderOfferService _tenderOfferService;


        public TenderOfferController(ITenderOfferService service)
        {
            _tenderOfferService = service;
        }


        [HttpPost]
        public IActionResult CreateTenderOffer([FromBody] TenderOfferDTO dto)
        {
            return Ok(_tenderOfferService.Create(TenderOfferMapper.ToModel(dto)));
        }


        [Route("/getOffersForTender")]
        [HttpGet]
        public IActionResult GetOffersForTender( int tenderID)
        {

            return Ok(TenderOfferMapper.ToDTOs(_tenderOfferService.getOffersForTender(tenderID)));
        }

    }
}
