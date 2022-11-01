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
            
            bool hasblood = connectionService.CheckForSpecificBloodType(id, bloodType);
            return Ok(hasblood);

        }


        [HttpGet]
        [Route("/CheckBloodAmount")]
        public ActionResult CheckBloodAmount([FromQuery(Name = "bloodBankId")] int id, [FromQuery(Name = "bloodType")] string bloodType, [FromQuery(Name = "quantity")] double quant)
        {
            bool hasblood = true;
            try
            {
                hasblood = connectionService.CheckBloodAmount(id, bloodType, quant);
            }
            catch (HttpRequestException ex)
            {
                if (ex.StatusCode == HttpStatusCode.Unauthorized)
                {
                    return Unauthorized();
                }
            }
            return Ok(hasblood);
        }
    }
}
