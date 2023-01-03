using HospitalLibrary.Core.Model.ValueObjects;
using HospitalLibrary.GraphicalEditor.Enums;

namespace HospitalLibrary.GraphicalEditor.Model
{
    public class Renovation
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }
        public DateRange DateRange { get; set; }
        public RenovationType Type { get; set; }
        public Status Status { get; set; }

        public Renovation(int id, int roomId, Room room, DateRange dateRange, RenovationType type)
        {
            Id = id;
            RoomId = roomId;
            Room = room;
            DateRange = dateRange;
            Type = type;
            Status = Status.UPCOMING;
        }
    }
}
