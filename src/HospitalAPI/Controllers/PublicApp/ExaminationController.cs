using AutoMapper;
using HospitalAPI.Web.Dto;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Service;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Controllers.PublicApp
{
    [Route("api/public/[controller]")]
    [ApiController]
    public class ExaminationController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAppointmentService _appointmentService;
        private readonly IDoctorService _doctorService;
        private readonly IExaminationService _examinationService;

        public ExaminationController(
            IMapper mapper,
            IExaminationService examinationService,
            IDoctorService doctorService)
        {
            _mapper = mapper;
            _examinationService = examinationService;
            _doctorService = doctorService;
        }

        [HttpPost]
        public ActionResult Create(ExaminationDTO examinationDTO)
        {
            var examination = _mapper.Map<Examination>(examinationDTO);
            examination.RoomId = _doctorService.GetById(examinationDTO.DoctorId).RoomId;
            _examinationService.Create(examination);
            return Ok();
        }

    }
}
