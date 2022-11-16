using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.GraphicalEditor.Model.DTO
{
    public class FormDTO
    {
        public int RoomId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string StartHourWorkDay { get; set; }

        public string EndHourWorkDay { get; set; }

        public string StartHourSaturday { get; set; }
        public string EndHourSaturday { get; set; }

        public string StartHourSunday { get; set; }

        public string EndHourSunday { get; set; }

        public FormDTO(Form form)
        {
            RoomId = form.RoomId;
            Name = form.Name;
            Description = form.Description;
            StartHourWorkDay = form.StartHourWorkDay;
            EndHourWorkDay = form.EndHourWorkDay;
            StartHourSaturday = form.StartHourSaturday;
            EndHourSaturday = form.EndHourSaturday;
            StartHourSunday = form.StartHourSunday;
            EndHourSunday = form.EndHourSunday;
        }
    }
}
