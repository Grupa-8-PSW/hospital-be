﻿using IntegrationAPI.ConnectionService.Interface;
using IntegrationAPI.Mapper;
using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Core.Model.DTO;
using IntegrationLibrary.Core.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace IntegrationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonthlySubscriptionController : ControllerBase
    {
        private readonly IMonthlySubscriptionService _service;
        private readonly IBloodBankService _bankService;
        private readonly IBloodBankConnectionService _bloodBankConnectionService;

        public MonthlySubscriptionController(IMonthlySubscriptionService service, IBloodBankService bankService, IBloodBankConnectionService bloodBankConnectionService)
        {
            _service = service;
            _bankService = bankService;
            _bloodBankConnectionService = bloodBankConnectionService;
        }

        [HttpPost]
        public void Create(MonthlySubscription subscription)
        {
            subscription.AddBank(_bankService.GetById(subscription.BankId)); 
            if (!ModelState.IsValid)
            {
                Console.WriteLine(ModelState);
            }
            _service.Create(subscription);
            MonthlySubscription created = _service.GetLast();
            MonthlySubscriptionDTO monthlySubscriptionDTO = MonthlySubscriptionMapper.ToDTO(created);
            _bloodBankConnectionService.SendMonthlySubscriptionOffer(monthlySubscriptionDTO, subscription.Bank.MonthlySubscriptionRoutingKey);
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_service.GetAll());
        }
    }
}
