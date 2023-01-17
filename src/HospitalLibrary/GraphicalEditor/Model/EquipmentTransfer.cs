using System.ComponentModel.DataAnnotations;

namespace HospitalLibrary.GraphicalEditor.Model
{
    public class EquipmentTransfer
    {
        public int Id { get; set; }
        [Required]

        public int Amount { get; set; }

        public int FromRoomId { get; set; }

        public int ToRoomId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int Duration { get; set; }

        public string EquipmentName { get; set; }

        public EquipmentTransfer(int id, int amount, int fromRoomId, int toRoomId, DateTime startDate, DateTime endDate, int duration, string equipmentName)
        {
            Id = id;
            Amount = amount;
            FromRoomId = fromRoomId;
            ToRoomId = toRoomId;
            StartDate = startDate;
            EndDate = endDate;
            Duration = duration;
            EquipmentName = equipmentName;
        }
    }
}
