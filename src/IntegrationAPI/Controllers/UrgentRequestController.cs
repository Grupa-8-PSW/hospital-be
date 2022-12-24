﻿
using IntegrationLibrary.Core.Service;
using IntegrationLibrary.Core.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace IntegrationAPI.Controllers
{
   // [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UrgentRequestController : ControllerBase
    {
        private readonly IUrgentRequestService _urgentRequestService;
        public UrgentRequestController(IUrgentRequestService urgentRequestService)
        {
            _urgentRequestService = urgentRequestService;
        }


        [Route("/api/[controller]/generatePdf")]
        [HttpGet]
        public async Task<IActionResult> GeneratePdf()
        {
            DateTime fromDate = new DateTime(2022, 12, 09);
            DateTime toDate = new DateTime(2022, 12, 22);
            return File(await _urgentRequestService.GeneratePdf(_urgentRequestService.GetUniqueUrgentRequests(fromDate, toDate), fromDate, toDate), "application/pdf", "urgentrequestreport.pdf");

        }

    }
}
