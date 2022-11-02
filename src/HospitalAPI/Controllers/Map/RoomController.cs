using HospitalLibrary.GraphicalEditor.Model.DTO;
using HospitalLibrary.GraphicalEditor.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Controllers.Map
{
  
        [Route("api/map/floor/rooms/[controller]")]
        [ApiController]
        public class RoomController : ControllerBase
        {
            private readonly IRoomService _roomService;

            public RoomController(IRoomService roomService)
            {
                _roomService = roomService;
            }

            [HttpGet]
            public ActionResult GetAll()
            {
                List<RoomDTO> rooms = new();
                foreach (var room in _roomService.GetAll())
                {
                    rooms.Add(new RoomDTO(room));
                }
                return Ok(rooms);
            }

            [HttpGet("{id}")]
            public ActionResult GetById(int id)
            {
                var room = _roomService.GetById(id);
                if (room == null)
                {
                    return NotFound();
                }

                return Ok(room);
            }
        }
    
}
