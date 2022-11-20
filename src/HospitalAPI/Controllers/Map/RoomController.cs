using HospitalLibrary.Core.Service;
using HospitalLibrary.GraphicalEditor.Model.DTO;
using HospitalLibrary.GraphicalEditor.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Controllers.Map
{
    [Route("api/map/floor/rooms/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;

        private readonly IExaminationService _examinationService;

        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_roomService.GetAll());
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
        public IActionResult GetByQuery(string name)
        {
            List<RoomDTO> rooms = new();
            foreach (var room in _roomService.GetAll())
            {
                if (room.Name == name)
                {
                    rooms.Add(new RoomDTO(room));
                }
            }
            return Ok(rooms);
        }

        [HttpGet("get/transferedEquipment")]
        public IActionResult GetAvailableTerminsForTransfer(EquipmentTransferDTO dto)
        {
            var rooms = _roomService.GetTransferedEquipment(dto);
            var examinations = _examinationService.GetAll();
            if (rooms == null)
            {
                return NotFound();
            } 
            return Ok(rooms);
        }
    }

}
