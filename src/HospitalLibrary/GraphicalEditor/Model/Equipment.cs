using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using HospitalLibrary.Core.Enums;

namespace HospitalLibrary.GraphicalEditor.Model
{
    public class Equipment
    {
        public int EquipmentId { get; set; }
        [Required]
        public string Name { get; set; }

        public int Amount { get; set; }

        public int RoomId { get; set; }

        public Equipment(int equipmentId, string name, int amount, int roomId)
        {
            EquipmentId = equipmentId;
            Name = name;
            Amount = amount;
            RoomId = roomId;
        }

        public Equipment()
        {
        }
    }
}
