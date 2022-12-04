using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.GraphicalEditor.Model.DTO
{
    public class FreeSpaceDTO
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public FreeSpaceDTO(DateTime startTime, DateTime endTime)
        {
            StartTime = startTime;
            EndTime = endTime;
        }

        public FreeSpaceDTO() { }
    }
}
