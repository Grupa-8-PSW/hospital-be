using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Core.Model.DTO;
using IntegrationLibrary.Core.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IntegrationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BloodUnitRequestController : ControllerBase
    {
        private readonly IBloodUnitRequestService _bloodUnitRequestService;

        public BloodUnitRequestController(IBloodUnitRequestService bloodUnitRequestService)
        {
            _bloodUnitRequestService = bloodUnitRequestService;
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

            BloodUnitRequest bloodUnitRequest = bloodUnitRequestDTO.toModel();


            bool succes = _bloodUnitRequestService.Create(bloodUnitRequest);
            if (!succes)
            {
                return BadRequest("Error in creating new blood unit request");
            }
            return CreatedAtAction("GetById", new { id = bloodUnitRequest.Id }, bloodUnitRequest);
        }
    }
}
