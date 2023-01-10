using HospitalLibrary.GraphicalEditor.Model.DTO;
using HospitalLibrary.GraphicalEditor.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Controllers.Map
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IRenovationService _renovationService;

        public StatisticsController(IRenovationService renovationService)
        {
            _renovationService = renovationService;
        }

        [HttpGet("renovation/views")]
        public IActionResult GetRenovationStatistics()
        {
            List<RenovationSessionDTO> sessions = new();
            foreach (var session in _renovationService.GetAll())
            {
                sessions.Add(new RenovationSessionDTO(session));
            }
            return Ok(sessions);
        }

        [HttpGet("renovation/views/avg")]
        public IActionResult GetRenovationStatisticsAvg()
        {
            List<RenovationSessionDTO> sessions = new();
            List<int> types = new();
            List<int> rooms = new();
            List<int> intervals = new();
            List<int> durations = new();
            List<int> availability = new();
            List<int> changes = new();
            List<int> schedules = new();

            foreach (var session in _renovationService.GetAll())
            {
                sessions.Add(new RenovationSessionDTO(session));
                types.Add(session.Type);
                rooms.Add(session.RoomId);
                intervals.Add(session.Interval);
                durations.Add(session.Duration);
                availability.Add(session.Available);
                changes.Add(session.Changes);
                schedules.Add(session.Schedule);
            }
            List<double> ret = new()
            {
                types.Average(),
                rooms.Average(),
                intervals.Average(),
                durations.Average(),
                availability.Average(),
                changes.Average(),
                schedules.Average()
            };
            return Ok(ret);
        }

    }
}
