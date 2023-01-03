using HospitalLibrary.GraphicalEditor.Model.DTO;
using HospitalLibrary.GraphicalEditor.Service;
using HospitalLibrary.GraphicalEditor.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Controllers.Map
{
    [Route("api/map/floor/rooms/[controller]")]
    [ApiController]
    //[Authorize(Roles = "Manager")]
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

            return Ok(new RoomDTO(room));
        }

        [HttpGet("get/by/floor/{id}")]
        public IActionResult GetRoomsByFloorId(int id)
        {
            List<RoomDTO> rooms = new();
            foreach (var room in _roomService.GetRoomsByFloorId(id))
            {
                rooms.Add(new RoomDTO(room));
            }
            return Ok(rooms);
        }

        [HttpGet("get/schedules/{id}")]
        public IActionResult getSchedulesDTO(int id)
        {
            var shedulesDto = _roomService.GetSchedules(id);
            return Ok(shedulesDto);
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

        [HttpPost("get/transferedEquipment")]
        public IActionResult GetAvailableTerminsForTransfer(EquipmentTransferDTO dto)
        {
            List<FreeSpaceDTO> freeSpace = _roomService.GetTransferedEquipment(dto);
            return Ok(freeSpace);
        }

        [HttpPost("get/separatedRooms")]
        public IActionResult GetSeparatedRooms(RoomForSeparateDTO dto)
        {
            SeparatedRoomsDTO separatedRooms = _roomService.GetSeparatedRooms(dto);
            return Ok(separatedRooms);
        }

        [HttpPost("get/mergedRoom")]
        public IActionResult GetMergedRoom(RoomsForMergeDTO dto)
        {
            MergedRoomDTO mergedRoom = _roomService.GetMergedRoom(dto);
            return Ok(mergedRoom);
        }
    }

}
