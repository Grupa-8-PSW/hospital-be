using HospitalLibrary.Core.Model.Aggregates.RenovationScheduling;
using HospitalLibrary.GraphicalEditor.BusinessUseCases;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Controllers.Map
{
    [Route("api/[controller]/session")]
    [ApiController]
    public class RenovationController : ControllerBase
    {
        private ScheduleRenovation _scheduleRenovation;

        public RenovationController(ScheduleRenovation scheduleRenovation)
        {
            _scheduleRenovation = scheduleRenovation;
        }

        [HttpGet("type")]
        public IActionResult CreateSessionStartedEvent()
        {
            _scheduleRenovation.Create(new RenovationSchedulingSession());
            return Ok();
        }

        [HttpGet("room")]
        public IActionResult CreateTypeSelectedEvent(string type)
        {
            //.SelectRenovationType();
            return Ok();
        }

        [HttpGet("interval")]
        public IActionResult CreateRoomSelectedEvent()
        {
            //.SelectRoom();
            return Ok();
        }

        [HttpGet("duration")]
        public IActionResult CreateDateTimeSelectedEvent()
        {
            //.SelectDateTime();
            return Ok();
        }

        [HttpGet("available")]
        public IActionResult CreateDurationSelectedvent()
        {
            //.SelectDuration();
            return Ok();
        }

        [HttpGet("create")]
        public IActionResult CreateAvailableSlotSelectedEvent()
        {
            //.SelectAvailableSlot();
            return Ok();
        }

        [HttpGet("schedule")]
        public IActionResult CreateRenovationScheduledEvent()
        {
            //.ScheduleRenovation();
            return Ok();
        }

    }
}
