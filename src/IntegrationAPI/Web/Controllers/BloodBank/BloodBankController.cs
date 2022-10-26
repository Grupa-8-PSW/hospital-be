using IntegrationAPI.Web.ConnectionService.Interface;
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


    }
}
