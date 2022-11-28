using HospitalLibrary.Core.Enums;
using HospitalLibrary.Core.Model;
using HospitalLibrary.GraphicalEditor.Model.Map;
using System.ComponentModel.DataAnnotations;

namespace HospitalLibrary.GraphicalEditor.Model
{
    public class Room
    {
        public int Id { get; set; }
        [Required]
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string Color { get; set; }
        public string Name { get; set; }

        public int FloorId { get; set; }

        public virtual ICollection<Floor> Floors { get; set; }

        public ICollection<Bed> Beds { get; set; }
        public RoomType Type { get; set; }

        public Room(int id, int x, int y, int width, int height, string color, string name, int floorId, RoomType type)
        {
            Id = id;
            X = x;
            Y = y;
            Width = width;
            Height = height;
            Color = color;
            Name = name;
            FloorId = floorId;
            Type = type;
        }

        public Room() { }
    }
}