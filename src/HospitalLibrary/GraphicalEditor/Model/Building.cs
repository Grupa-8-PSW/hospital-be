using HospitalLibrary.GraphicalEditor.Model.Map;
using System.ComponentModel.DataAnnotations;

namespace HospitalLibrary.GraphicalEditor.Model
{
    public class Building
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public virtual MapBuilding Map { get; set; }

        public virtual ICollection<Floor> Floors { get; set; }
    }
}
