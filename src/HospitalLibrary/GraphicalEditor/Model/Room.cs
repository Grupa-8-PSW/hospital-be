using HospitalLibrary.GraphicalEditor.Model.Map;
using System.ComponentModel.DataAnnotations;

namespace HospitalLibrary.GraphicalEditor.Model
{
    public class Room
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Number { get; set; }

        public virtual MapRoom Map { get; set; }

        public int FloorId { get; set; }
        public virtual Floor Floor { get; set; }
    }
}
