using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public string Name { get; set; }

        public int FloorId { get; set; }

        public RoomType Type { get; set; }

        public RoomDTO(Room room)
        {
            Id = room.Id;
            X = room.X;
            Y = room.Y;
            Width = room.Width;
            Height = room.Height;
            Color = room.Color;
            Name = room.Name;
            FloorId = room.FloorId;
            Type = room.Type;
        }
    }
}
