using HospitalLibrary.GraphicalEditor.Model.Map;
using System.ComponentModel.DataAnnotations;

namespace HospitalLibrary.GraphicalEditor.Model
{
    public class Floor
    {
        public int Id { get; set; }
        [Required]
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string Color { get; set; }
        public string Number { get; set; }
        public virtual MapFloor Map { get; set; }
        public int BuildingId { get; set; }
        public virtual Building Building { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }
    }
}
