using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.GraphicalEditor.Model.Map
{
    public class MapForm
    {
        public int Id { get; set; }
     
        public string Name { get; set; }

        public string Description { get; set; }

        public string StartHourWorkDay { get; set; }

        public string EndHourWorkDay { get; set; }

        public string StartHourSaturday { get; set; }
        public string EndHourSaturday { get; set; }

        public string StartHourSunday { get; set; }

        public string EndHourSunday { get; set; }

       
    }
}
