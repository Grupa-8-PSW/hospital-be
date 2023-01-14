using HospitalLibrary.GraphicalEditor.BusinessUseCases;
using HospitalLibrary.GraphicalEditor.Model.DTO;
using HospitalLibrary.GraphicalEditor.Service.Interfaces;
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

        [HttpGet("renovation/views")]
        public IActionResult GetRenovationStatistics()
        {
            return Ok(_scheduleRenovation.ViewsPerEachStep());
        }

        [HttpGet("renovation/views/sum")]
        public IActionResult GetRenovationStatisticsTotal()
        {
            return Ok(_scheduleRenovation.ViewsTotal());
        }

        [HttpGet("renovation/views/avg")]
        public IActionResult GetRenovationStatisticsAvg()
        {
            return Ok(_scheduleRenovation.ViewsAverage());
        }

    }
}
