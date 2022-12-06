using HospitalLibrary.GraphicalEditor.Model.DTO;
using HospitalLibrary.GraphicalEditor.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Controllers.Map
{
    [Route("api/map/[controller]")]
    [ApiController]
    //[Authorize(Roles = "Manager")]
    public class FloorController : ControllerBase
    {
        private readonly IFloorService _floorService;

        public FloorController(IFloorService floorService)
        {
            _floorService = floorService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<FloorDTO> floors = new();
            foreach (var floor in _floorService.GetAll())
            {
                floors.Add(new FloorDTO(floor));
            }
            return Ok(floors);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var floor = _floorService.GetById(id);
            if (floor == null)
            {
                return NotFound();
            }

            return Ok(floor);
        }

        [HttpGet("get/by/building/{id}")]
        public IActionResult GetFloorsByBuildingId(int id)
        {
            var floors = _floorService.GetFloorsByBuildingId(id);
            if (floors == null)
            {
                return NotFound();
            }

            return Ok(floors);
        }
    }
}
