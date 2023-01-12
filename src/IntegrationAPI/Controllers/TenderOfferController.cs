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
        private readonly IBloodBankConnectionService _connectionService;

        public TenderOfferController(ITenderOfferService service, IBloodBankConnectionService connectionService)
        {
            _tenderOfferService = service;
            _connectionService = connectionService; 
        }


        [HttpPost]
        public IActionResult CreateTenderOffer(TenderOfferDTO dto, int tenderId)
        {
            return Ok(_tenderOfferService.Create(TenderOfferMapper.ToModel(dto), tenderId));

        }


        [Route("/acceptOffer")]
        [HttpPost]
        public IActionResult AcceptTenderOffer(TenderOfferDTO dto, int tenderId)
        {
            return Ok(_tenderOfferService.AcceptTenderOffer(TenderOfferMapper.ToModel(dto), tenderId));
        }


        [Route("/getOffersForTender")]
        [HttpGet]
        public IActionResult GetOffersForTender( int tenderID)
        {
            return Ok(TenderOfferMapper.ToDTOs(_tenderOfferService.GetOffersForTender(tenderID)));
        }

        [HttpGet("sendTenderOffer")]
        public ActionResult SendTenderOffer(int tenderId, string APIKey)
        {
            _connectionService.SendTenderOffer(APIKey, tenderId);
            return Ok();
        }

    }
}
