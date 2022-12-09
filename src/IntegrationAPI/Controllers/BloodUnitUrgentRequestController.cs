using HospitalAPI.Connections;
using IntegrationAPI.ConnectionService.Interface;
using IntegrationAPI.ConnectionService;
using IntegrationAPI.GrpcServices;
using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Core.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;


namespace IntegrationAPI.Controllers
{

    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BloodUnitUrgentRequestController : Controller
    {
        private readonly IBloodService _bloodService;
        private readonly IHospitalHTTPConnectionService _hospitalHTTPConnectionService;
        private readonly IBloodBankService _bloodBankService;
        private readonly IClientScheduledService _clientScheduletService;
        private IBloodBankConnectionService _connectionService;

        public BloodUnitUrgentRequestController(IBloodService bloodService, 
                                                IHospitalHTTPConnectionService hospitalHTTPConnectionService,
                                                IBloodBankService bloodBankService,
                                                IBloodBankConnectionService connectionService,
                                                IClientScheduledService clientScheduletService)
        {
            this._bloodService = bloodService;
            this._hospitalHTTPConnectionService = hospitalHTTPConnectionService;
            this._bloodBankService = bloodBankService;
            this._connectionService = connectionService;
            this._clientScheduletService = clientScheduletService;

        }

        [HttpPost]
        public ActionResult SendRequestGRPC(BloodBank bloodBank)
        {
            _clientScheduletService.communicate(bloodBank.APIKey);
            return Ok();
        }

        [HttpPost]
        [Route("sendRequestHttp")]
        public ActionResult SendRequestHTTP(BloodBank bloodBank)
        {
            _connectionService.SendUrgentRequest(bloodBank.APIKey);
            return Ok();
        }
        
        //ovo se gadja klikom na link, treba nekako resiti authorize, za sad je gore zakomentarisan 
        [HttpGet("sendTenderOffer")]
        public ActionResult SendTenderOffer()
        {
            _connectionService.SendUrgentRequest("123");
            return Ok();
        }
    }
}
