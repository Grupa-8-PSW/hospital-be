﻿using HospitalLibrary.GraphicalEditor.Model.Map;
using System.ComponentModel.DataAnnotations;

namespace HospitalLibrary.GraphicalEditor.Model
{
    public class Building
    {
        public int Id { get; set; }
        [Required]
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string Color { get; set; }
        public string Name { get; set; }

        public virtual MapBuilding Map { get; set; }

        public virtual ICollection<Floor> Floors { get; set; }
    }
}
