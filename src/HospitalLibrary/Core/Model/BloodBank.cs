using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Model
{
    public class BloodBank
    {
        [Required]
        public string Name { get; set; }
        
        public String Email { get; set; }
       
        public String ServerAddress { get; set; }
    }
}
