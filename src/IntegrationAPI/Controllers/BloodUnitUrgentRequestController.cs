using IntegrationAPI.ConnectionService.Interface;
using IntegrationAPI.ConnectionService;
using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Core.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace IntegrationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BloodUnitUrgentRequestController : Controller
    {
        private readonly IBloodService _bloodService;
        private readonly IHospitalHTTPConnectionService _hospitalHTTPConnectionService;
        private readonly IBloodBankService _bloodBankService;
        private IBloodBankConnectionService _connectionService;

        public BloodUnitUrgentRequestController(IBloodService bloodService, 
                                                IHospitalHTTPConnectionService hospitalHTTPConnectionService,
                                                IBloodBankService bloodBankService,
                                                IBloodBankConnectionService connectionService)
        {
            this._bloodService = bloodService;
            this._hospitalHTTPConnectionService = hospitalHTTPConnectionService;
            this._bloodBankService = bloodBankService;
            this._connectionService = connectionService;
        }

        [HttpGet]
        public ActionResult SendRequest(string apiKey)
        {
            
            _connectionService.SendUrgentRequest(_bloodService.GetMissingQuantities(_hospitalHTTPConnectionService.GetAllBlood()), apiKey);
           


            return Ok();
        }

    }
}
