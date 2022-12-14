using IntegrationAPI.ConnectionService.Interface;
using IntegrationAPI.Mapper;
using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Core.Model.DTO;
using IntegrationLibrary.Core.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using static IntegrationAPI.Mapper.IMapper;

namespace IntegrationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonthlySubscriptionController : ControllerBase
    {
        private readonly IMonthlySubscriptionService _service;
        private readonly IBloodBankService _bankService;
        private readonly IBloodBankConnectionService _bloodBankConnectionService;
        private readonly IMapper<MonthlySubscription, MonthlySubscriptionDTO> _monthlySubscriptionMapper;

        public MonthlySubscriptionController(IMonthlySubscriptionService service, IBloodBankService bankService, 
            IBloodBankConnectionService bloodBankConnectionService, IMapper<MonthlySubscription, MonthlySubscriptionDTO> mapper)
        {
            _service = service;
            _bankService = bankService;
            _bloodBankConnectionService = bloodBankConnectionService;
            _monthlySubscriptionMapper = mapper;
        }

        [HttpPost]
        public String Create([FromBody]MonthlySubscriptionDTO subscription)
        {
            subscription.Bank =_bankService.GetById(subscription.BankId); 
            if (!ModelState.IsValid)
            {
                Console.WriteLine(ModelState);
            }
            try
            {
                MonthlySubscription monthlySubscription = _monthlySubscriptionMapper.toModel(subscription);
                _service.Create(monthlySubscription);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return "error";
            }
            MonthlySubscription created = _service.GetLast();
            MonthlySubscriptionMessageDTO monthlySubscriptionDTO = MonthlySubscriptionMessageMapper.ToDTO(created);
            try
            {
                _bloodBankConnectionService.SendMonthlySubscriptionOffer(monthlySubscriptionDTO, subscription.Bank.MonthlySubscriptionRoutingKey);
            }catch (Exception e) { Console.WriteLine(e); }
            return "success";
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_service.GetAll());
        }
    }
}
