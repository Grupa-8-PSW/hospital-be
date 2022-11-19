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

        // GET: api/rooms
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

            return Ok(bloodUnitRequest);
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

        
    }
}
