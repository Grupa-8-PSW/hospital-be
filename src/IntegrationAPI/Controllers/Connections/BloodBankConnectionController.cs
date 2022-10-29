using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Core.Service.Interface;
using Microsoft.AspNetCore.Mvc;

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
        public bool BloodQuantityExists(BloodBank bloodBank, string bloodType)
        {
            return connectionService.CheckForSpecificBloodType(bloodBank, bloodType);
        }

        //public ActionResult GetSpecificBloodTypeAmount([FromQuery(Name = "bank")] string bankName, [FromQuery(Name = "type")] string bloodType, [FromQuery(Name = "quantity")] double quant)
        //{
          //  var response = Ok(connectionService.CheckForSpecificBloodTypeAmount(bankName, bloodType, quant));
            //System.Console.WriteLine(response);
            //return response;
        //}
    }
}
