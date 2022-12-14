using IntegrationLibrary.Core.Model;
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

        public MonthlySubscriptionController(IMonthlySubscriptionService service, IBloodBankService bankService)
        {
            _service = service;
            _bankService = bankService;
        }

        [HttpPost]
        public String Create(MonthlySubscription subscription)
        {
            subscription.Bank = _bankService.GetById(subscription.BankId); 
            if (!ModelState.IsValid)
            {
                Console.WriteLine(ModelState);
            }

            try
            {
                _service.Create(subscription);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return "error";
            }
            return "success";
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_service.GetAll());
        }
    }
}
