using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.GraphicalEditor.Model.DTO
{
    public class ExaminationDTO
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public int Duration { get; set; }

        public ExaminationDTO(int id, DateTime startTime, int duration)
        {
            Id = id;
            StartTime = startTime;
            Duration = duration;    
        }
    }
}
