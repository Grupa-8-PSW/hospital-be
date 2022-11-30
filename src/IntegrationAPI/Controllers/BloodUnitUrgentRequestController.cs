﻿using HospitalAPI.Connections;
using IntegrationAPI.ConnectionService.Interface;
using IntegrationAPI.ConnectionService;
using IntegrationAPI.GrpcServices;
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
        public ActionResult SendRequest(BloodBank bloodBank)
        {
            _clientScheduletService.communicate(bloodBank.APIKey);
           // _hospitalHTTPConnectionService.RestockBlood(_bloodService.GetMissingQuantities(_hospitalHTTPConnectionService.GetAllBlood()));
            return Ok();
        }
    }
}
