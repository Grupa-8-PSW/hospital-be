using HospitalLibrary.GraphicalEditor.Model;
using HospitalLibrary.GraphicalEditor.Model.DTO;
using HospitalLibrary.GraphicalEditor.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Controllers.Map
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipmentController : ControllerBase
    {
        private readonly IRoomService _roomService;
        private readonly IEquipmentService _equipmentService;

        public EquipmentController(IEquipmentService equipmentService)
        {
            _equipmentService = equipmentService;
        }

        public EquipmentController(IRoomService roomService, IEquipmentService equipmentService)
        {
            _roomService = roomService;
            _equipmentService = equipmentService;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            List<EquipmentDTO> equipments = new();
            foreach (var equ in _equipmentService.GetAll())
            {
                equipments.Add(new EquipmentDTO(equ));
            }
            return Ok(equipments);
        }

        [HttpGet("{id}")]
        public ActionResult GetEquipmentByRoomId(int id)
        {
            List<EquipmentDTO> equipments = new();
            foreach (var equ in _equipmentService.GetEquipmentByRoomId(id))
            {
                equipments.Add(new EquipmentDTO(equ));
            }
            return Ok(equipments);
        }

        [HttpPost]
        public IActionResult CreateTransferEquipment(EquipmentTransferDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _equipmentService.MoveEquipmentThread(dto);

            //EquipmentTransfer equipTrans = new EquipmentTransfer();
            //equipTrans.Amount = dto.Amount;
            //equipTrans.ToRoomId = dto.ToRoomId;
            //equipTrans.EquipmentName = dto.EquipmentName;
            //equipTrans.StartDate = dto.StartDate;
            //equipTrans.EndDate = dto.EndDate;
            //equipTrans.Duration = dto.Duration;
            //equipTrans.FromRoomId = dto.FromRoomId;


            //_equipmentService.CreateEquipTransfer(equipTrans);
            //return CreatedAtAction("GetById", new { id = equipTrans.Id }, equipTrans);
            return null;
        [HttpGet("search")]
        public IActionResult Search(string? name, int? amount)
        {
            List<RoomDTO> rooms = new();

            foreach (var item in _equipmentService.Search(name, amount))
            {
                rooms.Add(new RoomDTO(_roomService.GetById(item.RoomId)));
            }
            return Ok(rooms);
        }
    }
    
}
