using IntegrationAPI.ExceptionHandler.Validators;
using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Core.Model.DTO;
using IntegrationLibrary.Core.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace IntegrationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BloodConsumptionConfigurationController : ControllerBase
    {
        private readonly IBloodConsumptionConfigurationService _service;

        public BloodConsumptionConfigurationController(IBloodConsumptionConfigurationService service)
        {
            _service = service;
        }

        [Route("daily")]
        [HttpPost]
        public BloodConsumptionConfiguration CreateDaily([FromBody] BloodConsumptionReportDTO dto)
        {
            String startDate = DateTime.Now.ToString("MM/dd/yyyy");
            BloodConsumptionConfiguration bcs = new BloodConsumptionConfiguration((int)Period.DAILY, dto.StartTime, startDate);
            
            return _service.Create(bcs);
            
        }
    }
}
