using HospitalLibrary.Core.Model;

namespace HospitalLibrary.GraphicalEditor.Model
{
    public class Equipment : BaseEntityModel
    {
        public string Name { get; set; }
        public int Amount { get; set; }
        public int RoomId { get; set; }
        public virtual Room Room { get; set; }

        public Equipment(int id, string name, int amount, int roomId)
        {
            Id = id;
            Name = name;
            Amount = amount;
            RoomId = roomId;
        }

        public Equipment()
        {
        }
    }
}
