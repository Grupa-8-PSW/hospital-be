using HospitalAPI.DTO;using HospitalAPI.Mapper;using HospitalAPI.Web.Dto;using HospitalAPI.Web.Mapper;using HospitalLibrary.Core.Model;using HospitalLibrary.Core.Service;using HospitalLibrary.Core.Util;
using HospitalLibrary.GraphicalEditor.Model.DTO;using Microsoft.AspNetCore.Http;using Microsoft.AspNetCore.Mvc;using System.Collections.ObjectModel;
using System.Net;

namespace HospitalAPI.Controllers{    [Route("api/[controller]")]    [ApiController]    public class TreatmentHistoryController : ControllerBase    {        private readonly ITreatmentHistoryService _treatmentHistoryService;        //      private readonly IDoctorService _doctorService;        private readonly IMapper<TreatmentHistory, TreatmentHistoryDTO> _treatmentHistoryMapper;        public TreatmentHistoryController(ITreatmentHistoryService treatmentHistoryService, IMapper<TreatmentHistory, TreatmentHistoryDTO> mapper)        {            _treatmentHistoryService = treatmentHistoryService;            _treatmentHistoryMapper = mapper;        }        // GET: api/rooms        [HttpGet]        public ActionResult GetAll()        {            return Ok(_treatmentHistoryMapper.toDTO(new Collection<TreatmentHistory>(_treatmentHistoryService.GetAll().ToList())));        }        // GET api/rooms/2        [HttpGet("{id}")]        public ActionResult GetById(int id)        {            var examination = _treatmentHistoryService.GetById(id);            if (examination == null)            {                return NotFound();            }            return Ok(examination);        }        // POST api/rooms        [HttpPost]        public ActionResult Create(TreatmentHistoryDTO treatmentHistoryDTO)        {            if (!ModelState.IsValid)            {                return BadRequest(ModelState);            }            TreatmentHistory treatmentHistory = _treatmentHistoryMapper.toModel(treatmentHistoryDTO);            int roomId = treatmentHistoryDTO.RoomId;            bool succes = _treatmentHistoryService.Create(treatmentHistory, roomId);            if (!succes)            {                return BadRequest("Poruka .....");            }            return CreatedAtAction("GetById", new { id = treatmentHistory.Id }, treatmentHistory);        }        // PUT api/rooms/2        [HttpPut("{id}")]        public ActionResult Update(int id, TreatmentHistory treatmentHistory)   //DTO        {            /* Examination examination = _examinationMapper.toModel(examinationDTO);             examination.RoomId = doctor.RoomId;             if (!ModelState.IsValid)             {                 return BadRequest(ModelState);             }             if (id != examination.Id)             {                 return BadRequest();             }             bool succes;             try             {                 succes = _treatmentHistoryService.Update(examination);             }             catch (Exception e1)             {                 return BadRequest();             }             if (!succes)             {                 return BadRequest("Poruka .....");             }*/            return Ok(treatmentHistory);        }        // DELETE api/rooms/2        [HttpDelete("{id}")]        public ActionResult Delete(int id)        {            var examination = _treatmentHistoryService.GetById(id);            if (examination == null)            {                return NotFound();            }            _treatmentHistoryService.Delete(examination);            return NoContent();        }        [HttpGet("generateReport/{id}")]        public ActionResult DownloadTreatmentReport(int id)
        {
            try
            {
                TreatmentHistory treatmentHistory = _treatmentHistoryService.GetByIdEager(id);
                if (treatmentHistory == null)
                {
                    return NotFound();
                }
                if (treatmentHistory.EndDate == null)
                {
                    return BadRequest(new { Error = "Treatment is still active." });
                }

                string fileName = treatmentHistory.Patient.Id 
                    + "_"
                    + treatmentHistory.Patient.FirstName
                    + treatmentHistory.Patient.LastName
                    + "_report.pdf";
                string dirName = @"C:\\Temp\";

                ITreatmentReportGenerator treatmentReportGenerator = 
                    new TreatmentReportGenerator(treatmentHistory);
                string? pdfPath = treatmentReportGenerator.GenerateSummarizingReport(treatmentHistory,
                    dirName, fileName);

                if (pdfPath == null)
                {
                    return new JsonResult(new SimpleResponse(HttpStatusCode.InternalServerError,
                        new { Message = "Failed to generate report." }));
                }

                var content = new FileStream(pdfPath, FileMode.Open, FileAccess.Read, FileShare.Read);
                var response = File(content, "application/octet-stream");
                return response;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return new JsonResult(new SimpleResponse(HttpStatusCode.InternalServerError,
                        new { Message = "Unknown error occured while generating treatment report." }));
            }
           
        }    }}