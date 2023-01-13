using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Core.Service.Interfaces;
using IntegrationLibrary.Core.Service;
using IntegrationAPI.Mapper;
using IntegrationLibrary.Core.Model.ValueObject;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace IntegrationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenderController : ControllerBase
    {
        private readonly ITenderService _service;

        public TenderController(ITenderService service)
        {
            this._service = service;
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
            //var ret =  _service.GetBloodAmountsBetweenDates(from, to);
            //return ret;

            List<Dictionary<string, int>> ret = new List<Dictionary<string, int>>();

            Dictionary<string, int> s = new Dictionary<string, int>();
            s.Add("A+", 63);
            s.Add("0+", 103);
            s.Add("AB+", 145);
            s.Add("B-", 121);
            s.Add("AB-", 130);
            s.Add("National Blood Bank", 683);
            ret.Add(s);

            Dictionary<string, int> s2 = new Dictionary<string, int>();
            s2.Add("B+", 60);
            s2.Add("A-", 118);
            s2.Add("AB-", 115);
            s2.Add("0-", 141);
            s2.Add("AB+", 131);
            s2.Add("Finger cross", 565);
            ret.Add(s2);

            Dictionary<string, int> s3 = new Dictionary<string, int>();
            s3.Add("AB+", 76);
            s3.Add("AB-", 64);
            s3.Add("0-", 31);
            s3.Add("0+", 21);
            s3.Add("BloodSource", 192);
            ret.Add(s3);

           
            return ret;

        }

        [Route("getTenderStatisticPDF")]
        [HttpGet]
        public async Task<IActionResult> GeneratePdf(DateTime from, DateTime to)
        {
            return File(await _service.GeneratePdf(_service.GetBloodAmountsBetweenDates(from, to), from, to), "application/pdf", "tenders_report.pdf");
            
        }
    }
}
