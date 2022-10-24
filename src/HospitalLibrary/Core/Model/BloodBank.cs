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
<<<<<<< HEAD
        public int Id { get; set; }
        
        public string Name { get; set; }

        public string Email { get; set; }

        public string ServerAddress { get; set; }
=======
        [Required]
        public string Name { get; set; }
        
        public String Email { get; set; }
       
        public String ServerAddress { get; set; }
>>>>>>> 7cd19fb14d5fce0b3579bc2d0c9d6275d0d71fb8
    }
}
