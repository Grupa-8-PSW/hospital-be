using HospitalLibrary.Core.Enums;

namespace HospitalLibrary.GraphicalEditor.Model.DTO
{
    public class RoomDTO
    {
        public int Id { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string Color { get; set; }
        public RoomType Type { get; set; }
        public string Number { get; set; }
        public string Name { get; set; }
        public int FloorId { get; set; }

        public RoomDTO(Room room)
        {
            Id = room.Id;
            X = room.Map.X;
            Y = room.Map.Y;
            Width = room.Map.Width;
            Height = room.Map.Height;
            Color = room.Map.Color;
            Type = room.Type;
            Number = room.Number;
            Name = room.Name;
            FloorId = room.FloorId;
        }
    }
}
