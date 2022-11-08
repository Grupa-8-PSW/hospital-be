using HospitalLibrary.GraphicalEditor.Model.Map;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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
        X = 100;
        Y = 100;
        Width = 450;
        Height = 150;
        Color = "gray";
        Name = building.Name;
    }
}
}
