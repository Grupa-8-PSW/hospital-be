﻿using HospitalLibrary.Core.Model.Aggregates.RenovationScheduling;
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

        [HttpPost("new")]
        public IActionResult CreateSessionStartedEvent()
        {
            return Ok(_scheduleRenovation.CreateNewSessionEvent());
        }

        [HttpGet("type/{id}")]
        public IActionResult CreateSessionStartedEvent(int id)
        {
            _scheduleRenovation.CreateSessionStartedEvent(id);
            return Ok();
        }

        [HttpGet("room/{id}")]
        public IActionResult CreateTypeSelectedEvent(int id)
        {
            _scheduleRenovation.CreateTypeSelectedEvent(id);
            return Ok();
        }

        [HttpGet("interval/{id}")]
        public IActionResult CreateRoomSelectedEvent(int id)
        {
            _scheduleRenovation.CreateRoomSelectedEvent(id);
            return Ok();
        }

        [HttpGet("duration/{id}")]
        public IActionResult CreateDateTimeSelectedEvent(int id)
        {
            _scheduleRenovation.CreateDateTimeSelectedEvent(id);
            return Ok();
        }

        [HttpGet("available/{id}")]
        public IActionResult CreateDurationSelectedvent(int id)
        {
            _scheduleRenovation.CreateDurationSelectedvent(id);
            return Ok();
        }

        [HttpGet("create/{id}")]
        public IActionResult CreateAvailableSlotSelectedEvent(int id)
        {
            _scheduleRenovation.CreateAvailableSlotSelectedEvent(id);
            return Ok();
        }

        [HttpGet("schedule/{id}")]
        public IActionResult CreateRenovationScheduledEvent(int id)
        {
            _scheduleRenovation.CreateRenovationScheduledEvent(id);
            return Ok();
        }

    }
}
