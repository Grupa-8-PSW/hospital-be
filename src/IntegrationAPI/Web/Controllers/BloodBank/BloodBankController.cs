using IntegrationAPI.Web.ConnectionService.Interface;
using IntegrationLibrary.Services;
using Microsoft.AspNetCore.Mvc;

namespace IntegrationAPI.Web.Controllers.BloodBank
{
    [Route("api/[controller]")]
    [Controller]
    public class BloodBankController : ControllerBase
    {
        private IBloodBankConnectionService connectionService;


        public BloodBankController(IBloodBankConnectionService connectionService)
        {
            this.connectionService = connectionService;
        }

        [HttpGet]
        public bool BloodQuantityExists(double quantity)
        {
            return connectionService.BloodQuantityExists(quantity);
        }

        [HttpGet]
        public ActionResult GetSpecificBloodTypeAmount([FromQuery(Name = "bank")] string bankName, [FromQuery(Name = "type")] string bloodType, [FromQuery(Name = "quantity")] double quant)
        {
            var response = Ok(connectionService.CheckForSpecificBloodTypeAmount(bankName, bloodType, quant));
            System.Console.WriteLine(response);
            return response;
        }


    }
}
