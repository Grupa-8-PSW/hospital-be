using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.GraphicalEditor.Model.DTO
{
    public class EquipmentDTO
    {
        public int EquipmentId { get; set; }

        public string Name { get; set; }

        public int Amount { get; set; }

        public int RoomId { get; set; }

        public EquipmentDTO(Equipment equipment)
        {
            EquipmentId = equipment.EquipmentId;
            Name = equipment.Name;
            Amount = equipment.Amount;
            RoomId = equipment.RoomId;
     
        }
    }
}
