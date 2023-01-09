using HospitalLibrary.GraphicalEditor.BusinessUseCases;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Controllers.Map
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly ScheduleRenovation _scheduleRenovation;

        public StatisticsController(ScheduleRenovation scheduleRenovation)
        {
            _scheduleRenovation = scheduleRenovation;
        }

        [HttpGet("renovation")]
        public IActionResult GetRenovationStatistics()
        {


            return Ok();
        }
    }
}
