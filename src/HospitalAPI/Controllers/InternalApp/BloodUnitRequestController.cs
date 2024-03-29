using System.Web.Http.Cors;
using HospitalAPI.Connections;
using HospitalAPI.DTO;
using HospitalAPI.Web.Mapper;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Controllers.InternalApp
{
    [Route("api/internal/[controller]")]
    [ApiController]
    public class BloodUnitRequestController : ControllerBase
    {
        private readonly IBloodUnitRequestService _bloodUnitRequestService;
        private readonly IMapper<BloodUnitRequest, BloodUnitRequestDTO> _bloodUnitRequestMapper;

        public BloodUnitRequestController(IBloodUnitRequestService bloodUnitRequestService, IMapper<BloodUnitRequest, BloodUnitRequestDTO> bloodUnitRequestMapper)
        {
            _bloodUnitRequestService = bloodUnitRequestService;
            _bloodUnitRequestMapper = bloodUnitRequestMapper;
        }


        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_bloodUnitRequestService.GetAll());
        }

        // GET api/rooms/2
        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var bloodUnitRequest = _bloodUnitRequestService.GetById(id);
            if (bloodUnitRequest == null)
            {
                return NotFound();
            }

            return Ok(_bloodUnitRequestMapper.toDTO(bloodUnitRequest));
        }



        [HttpPost]
        public ActionResult Create(BloodUnitRequestDTO bloodUnitRequestDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            BloodUnitRequest bloodUnitRequest = _bloodUnitRequestMapper.toModel(bloodUnitRequestDTO);


            bool succes = _bloodUnitRequestService.Create(bloodUnitRequest);
            if (!succes)
            {
                return BadRequest("Poruka .....");
            }
            return CreatedAtAction("GetById", new { id = bloodUnitRequest.Id }, bloodUnitRequest);
        }
        [Route("updateUnclearRequest")]
        [HttpPut]
        public ActionResult UpdateUnclearRequest(BloodUnitRequestDTO bloodUnitRequestDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            BloodUnitRequest bloodUnitRequest = _bloodUnitRequestMapper.toModel(bloodUnitRequestDTO);
            _bloodUnitRequestService.UpdateUnclearRequest(bloodUnitRequest);
            return Ok();


        }

        [HttpPut]
        [Route("{id}")]
        public ActionResult ChangeRequestStatus(BloodUnitRequestDTO bloodUnitRequestDto)
        {
            BloodUnitRequest bloodUnitRequest = _bloodUnitRequestMapper.toModel(bloodUnitRequestDto);
            _bloodUnitRequestService.Update(bloodUnitRequest);
            return Ok();
        }

        
    }
}
