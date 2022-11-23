using HospitalLibrary.GraphicalEditor.Model;
using HospitalLibrary.GraphicalEditor.Model.DTO;
using HospitalLibrary.GraphicalEditor.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Controllers.Map
{

    [Route("api/map/floor/rooms/[controller]")]
    [ApiController]
    [Authorize(Roles = "Manager")]
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

        [HttpGet("get/by/floor/{id}")]
        public IActionResult GetRoomsByFloorId(int id)
        {
            var rooms = _roomService.GetRoomsByFloorId(id);
            if (rooms == null)
            {
                return NotFound();
            }

            return Ok(rooms);
        }

        [HttpGet("search")]
        public IActionResult Search(string? name)
        {
            List<RoomDTO> rooms = new();
            foreach (var room in _roomService.Search(name))
            {
                rooms.Add(new RoomDTO(room));
            }
            return Ok(rooms);
        }

        [HttpGet("free")]
        public IActionResult GetFreeRooms()
        {
            List<RoomDTO> rooms = new();
            foreach (var room in _roomService.GetFreeRooms())
            {
                rooms.Add(new RoomDTO(room));
            }
            return Ok(rooms);
        }

    }

}
