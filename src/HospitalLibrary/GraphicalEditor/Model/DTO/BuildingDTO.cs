using HospitalLibrary.GraphicalEditor.Model.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.GraphicalEditor.Model.DTO
{
    public class BuildingDTO
    {
        public int Id { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string Color { get; set; }
        public string Name { get; set; }

        public BuildingDTO(Building building)
        {
            Id = building.Id;
            X = building.X;
            Y = building.Y;
            Width = building.Width;
            Height = building.Height;
            Color = building.Color;
            Name = building.Name;
        }
    }
}
