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
    public class BuildingController : ControllerBase
    {
        private readonly IBuildingService _buildingService;

        public BuildingController(IBuildingService buildingService)
        {
            _buildingService = buildingService;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            List<BuildingDTO> buildings = new();
            foreach (var building in _buildingService.GetAll())
            {
                buildings.Add(new BuildingDTO(building));
            }
            return Ok(buildings);
        }

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var building = _buildingService.GetById(id);
            if (building == null)
            {
                return NotFound();
            }

            return Ok(building);
        }

    }
}
