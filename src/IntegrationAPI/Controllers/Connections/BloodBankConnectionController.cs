using IntegrationAPI.ConnectionService.Interface;
using IntegrationLibrary.Core.Model;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace IntegrationAPI.Controllers.Connections
{
    [Route("api/[controller]")]
    [ApiController]
    public class BloodBankConnectionController : ControllerBase
    {
        private IBloodBankConnectionService connectionService;


        public BloodBankConnectionController(IBloodBankConnectionService connectionService)
        {
            this.connectionService = connectionService;
        }


        [HttpGet]
        public ActionResult CheckForSpecificBloodType([FromQuery(Name = "bloodBankId")] int id, [FromQuery(Name = "bloodType")] string bloodType)
        {
            bool hasblood = true;
            try
            {
                hasblood = connectionService.CheckForSpecificBloodType(id, bloodType);
            }catch(HttpRequestException ex)
            {
                if(ex.StatusCode == HttpStatusCode.Unauthorized)
                {
                    return Unauthorized();
                }
            }
            return Ok(hasblood);
        }

        //public bool GetSpecificBloodTypeAmount([FromQuery(Name = "bank")] string bankName, [FromQuery(Name = "type")] string bloodType, [FromQuery(Name = "quantity")] double quant)
        //{
        //  var response = Ok(connectionService.CheckForSpecificBloodTypeAmount(bankName, bloodType, quant));
        //System.Console.WriteLine(response);
        //return response;
        //}

        [HttpGet]
        [Route("/CheckBloodAmount")]
        public bool CheckBloodAmount([FromQuery(Name = "api")] string api, [FromQuery(Name = "bloodType")] string bloodType, [FromQuery(Name = "quantity")] double quant)
        {
            return connectionService.CheckBloodAmount(api, bloodType, quant);
        }
    }
}
