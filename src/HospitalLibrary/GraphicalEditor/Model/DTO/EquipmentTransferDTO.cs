using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.GraphicalEditor.Model.DTO
{
    public class EquipmentTransferDTO
    {
        public int Id { get; set; }
        public int Amount { get; set; }

        public int FromRoomId { get; set; }

        public int ToRoomId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int Duration { get; set; }

        public string EquipmentName { get; set; }


        public EquipmentTransferDTO() { }
        public EquipmentTransferDTO(int amount, int fromRoomId, int toRoomId, DateTime startDate, DateTime endDate, int duration, string equipmentName)
        {
            Amount = amount;
            FromRoomId = fromRoomId;
            ToRoomId = toRoomId;
            StartDate = startDate;
            EndDate = endDate;
            Duration = duration;
            EquipmentName = equipmentName;
        }

        public EquipmentTransferDTO(int id, DateTime startDate, DateTime endDate,int fromRoomId, int toRoomId)
        {
            Id = id;
            StartDate = startDate;
            EndDate = endDate;
            FromRoomId= fromRoomId;
            ToRoomId = toRoomId;  
        }
    }
}
