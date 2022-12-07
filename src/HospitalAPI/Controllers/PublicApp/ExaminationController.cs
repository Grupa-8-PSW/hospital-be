﻿using AutoMapper;
using HospitalAPI.DTO;
using HospitalLibrary.Core.Enums;
using HospitalLibrary.Core.Service;
using HospitalLibrary.Core.Util;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Controllers.PublicApp
{
    [Route("api/public/[controller]")]
    [ApiController]
    public class ExaminationController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAppointmentService _appointmentService;

        public ExaminationController(
            IMapper mapper,
            IAppointmentService appointmentService)
        {
            _mapper = mapper;
            _appointmentService = appointmentService;
        }

        [HttpGet("/recommend")]
        public ActionResult<List<AvailableAppointmentsDTO>> GetRecommendedExaminationTime(
            [FromQuery] DateTime start,
            [FromQuery] DateTime end,
            [FromQuery] int doctorId, 
            [FromQuery] AppointmentPriority priority)
        {
            if (start >= end)
                return BadRequest();
            var dateRange = new DateRange(start, end);
            var availableAppointments = _appointmentService.GetRecommendedAvailableAppointments(dateRange, doctorId, priority);
            return Ok(_mapper.Map<List<AvailableAppointmentsDTO>>(availableAppointments));
        }

    }
}