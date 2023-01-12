﻿using Microsoft.AspNetCore.Http;
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
        private readonly ITenderRoot tenderRoot;
        public TenderController(ITenderService service, ITenderRoot tenderRoot)
        {
            this._service = service;
            this.tenderRoot = tenderRoot;
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
        [Route("getAllBloodAmountsBetweenDates")]
        public List<Dictionary<string, int>> GetAllBloodAmountsBetweenDates(DateTime from, DateTime to)
        {
            return tenderRoot.GetBloodAmountsBetweenDates(from, to);
        }

        [Route("getTenderStatisticPDF")]
        [HttpGet]
        public async Task<IActionResult> GeneratePdf(DateTime from, DateTime to)
        {
            return File(await _service.GeneratePdf(_service.GetBloodAmountsBetweenDates(from, to), from, to), "application/pdf", "tenders_report.pdf");
        
        }
    }
}
