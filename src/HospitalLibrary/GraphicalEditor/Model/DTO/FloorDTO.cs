using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.GraphicalEditor.Model.DTO
{
    public class FloorDTO
    {
        public int Id { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string Color { get; set; }
        public string Number { get; set; }

        public FloorDTO(Floor floor)
        {
            Id = floor.Id;
            X = floor.X;
            Y = floor.Y;
            Width = floor.Width;
            Height = floor.Height;
            Color = floor.Color;
            Number = floor.Number;
        }
    }
}
