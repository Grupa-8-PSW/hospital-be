using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.GraphicalEditor.Model
{
    public class Floor
    {
        public int Id { get; set; }
        [Required]
        public string Number { get; set; }
        public string Building { get; set; }
    }
}
