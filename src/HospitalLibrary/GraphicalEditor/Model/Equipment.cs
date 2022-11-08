using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.GraphicalEditor.Model
{
    public class Equipment
    {
        public int EquipmentId { get; set; }
        [Required]
        public string Name { get; set; }

        public int Amount { get; set; }

        public int RoomId { get; set; }
    }
}
