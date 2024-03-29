﻿using HospitalAPI.Requests;
using HospitalAPI.Web.Dto;
using HospitalAPI.Web.Mapper;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using System.Web.Http.Results;
using HospitalAPI.Extensions;
using HospitalLibrary.Core.Enums;
using HospitalLibrary.Core.Model.ValueObjects;
using HospitalLibrary.Core.Util;
using Microsoft.Net.Http.Headers;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ExaminationController : ControllerBase
    {
        private readonly IExaminationService _examinationService;
        private readonly IDoctorService _doctorService;
        private readonly IExaminationDoneService _examinationDoneService;
        private readonly IMapper<Examination, ExaminationDTO> _examinationMapper;

        public ExaminationController(IExaminationService examinationService,
            IDoctorService doctorService,
            IMapper<Examination, ExaminationDTO> mapper,
            IExaminationDoneService examinationDoneService)
        {
            _examinationService = examinationService;
            _doctorService = doctorService;
            _examinationMapper = mapper;
            _examinationDoneService = examinationDoneService;
        }

        // GET: api/rooms
        [HttpGet]
        public ActionResult GetAll()
        {
            var res = _examinationService.GetAll();
            return Ok(res);
        }

        // GET api/rooms/2
        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var examination = _examinationService.GetById(id);
            if (examination == null)
            {
                return NotFound();
            }

            return Ok(_examinationMapper.toDTO(examination));
        }

        [HttpGet("{day}/{month}/{year}")]
        public ActionResult GetByDate(int day, int month, int year)
        {
            DateTime selectedDate = new DateTime(year, month, day);
            var examinations = _examinationService.GetByDate(selectedDate);
            List<ExaminationDTO> examinationDTOs = new List<ExaminationDTO>();

            foreach (Examination examination in examinations)
            {
                examinationDTOs.Add(_examinationMapper.toDTO(examination));     //toDTO(lista)
            }

            return Ok(examinationDTOs);
        }

        // POST api/rooms
        [HttpPost]
        public ActionResult Create(PostExaminationRequest postExaminationRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var examination = CreateExaminationFromPostRequest(postExaminationRequest);

            var success = _examinationService.Create(examination);
            if (!success)
            {
                return BadRequest("Poruka .....");
            }
            return CreatedAtAction("GetById", new
            {
                id = examination.Id
            }, _examinationMapper.toDTO(_examinationService.GetById(examination.Id)));
        }

        // PUT api/rooms/2
        [HttpPut("{id}")]
        public ActionResult Update(int id, [FromBody] ExaminationDTO examinationDTO)
        {
            Doctor doctor = _doctorService.GetById(examinationDTO.DoctorId);

            Examination examination = _examinationMapper.toModel(examinationDTO);
            // examination.RoomId = doctor.RoomId;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != examination.Id)
            {
                return BadRequest();
            }
            bool succes;
            try
            {
                succes = _examinationService.Update(examination);
            }
            catch (Exception e1)
            {
                return BadRequest();
            }
            if (!succes)
            {
                return BadRequest("Poruka .....");
            }
            return Ok(_examinationService.GetById(examination.Id));
        }

        // DELETE api/rooms/2
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var examination = _examinationService.GetById(id);
            if (examination == null)
            {
                return NotFound();
            }

            _examinationService.Delete(examination);
            return NoContent();
        }


        [HttpGet("{id}/generateReport")]
        public async Task<ActionResult> DownloadReport(int id, [FromQuery] bool includeReport,
            [FromQuery] bool includeSymptoms, [FromQuery] bool includePrescriptions)
        {
            try
            {
                var examination = _examinationService.GetById(id);

                if (examination == null)
                {
                    return NotFound();
                }

                if (examination.DateRange.Start.ToUniversalTime() > DateTime.UtcNow)
                {
                    return BadRequest();
                }

                var examinationDone = _examinationDoneService.GetByExamination(id);

                if (examinationDone == null)
                {
                    return NotFound();
                }

                var reportGenerator = new ExaminationReportGenerator(examinationDone);

                const string dirName = @"C:\\Temp\";
                var fileName = $"ExaminationReport_{examinationDone.Id}.pdf";

                var fullPath = reportGenerator.GenerateReport(dirName, fileName,
                    includeReport, includeSymptoms, includePrescriptions);

                if (fullPath == null)
                {
                    return new JsonResult(new SimpleResponse
                    {
                        StatusCode = HttpStatusCode.InternalServerError,
                        Body = "Error generating examination report"
                    });
                }

                await using var fs = new FileStream(fullPath, FileMode.Open, FileAccess.Read);
                var buffer = new byte[fs.Length];
                var readBytes = await fs.ReadAsync(buffer, 0, (int)fs.Length);

                if (readBytes != fs.Length)
                {
                    return new JsonResult(new SimpleResponse
                    {
                        StatusCode = HttpStatusCode.InternalServerError,
                        Body = "Error reading file"
                    });
                }
                var cd = new ContentDispositionHeaderValue("attachment")
                {
                    FileName = fileName
                };
                Response.Headers.Add(HeaderNames.ContentDisposition, cd.ToString());
                return new FileContentResult(buffer, "application/pdf");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return new JsonResult(new SimpleResponse
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Body = "Error generating examination report"
                });
            }
        }

        private Examination CreateExaminationFromPostRequest(PostExaminationRequest postExaminationRequest)
        {
            try
            {
                //var doctorId = HttpContext.GetUserId();
                var doctorId = 1;
                var doctor = _doctorService.GetById(doctorId);
                var startTime = DateTime.ParseExact(postExaminationRequest.StartTime, "dd/MM/yyyy HH:mm", null);
                var examination = new Examination
                {
                    DoctorId = doctorId,
                    PatientId = postExaminationRequest.PatientId,
                    DateRange = new DateRange(startTime, startTime.AddMinutes(postExaminationRequest.Duration)),
                    RoomId = doctor.RoomId
                };
                examination.RoomId = doctor.RoomId;
                examination.Status = ExaminationStatus.UPCOMING;
                return examination;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        [HttpGet("room/{roomId}")]
        public ActionResult GetByRoomId(int roomId)
        {
            var examination = _examinationService.GetByRoomId(roomId);
            if (examination == null)
            {
                return NotFound();
            }

            return Ok(examination);
        }
    }
}