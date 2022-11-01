using HospitalLibrary.GraphicalEditor.Model.Map;
using System.ComponentModel.DataAnnotations;

namespace HospitalLibrary.GraphicalEditor.Model
{
    public class Floor
    {
        public int Id { get; set; }
        [Required]
        public string Number { get; set; }

        public virtual MapFloor Map { get; set; }

        public int BuildingId { get; set; }
        public virtual Building Building { get; set; }

        public virtual ICollection<Room> Rooms { get; set; }
    }
}
