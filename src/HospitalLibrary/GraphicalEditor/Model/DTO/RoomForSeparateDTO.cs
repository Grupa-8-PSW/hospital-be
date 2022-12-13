using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.GraphicalEditor.Model.DTO
{
    public class RoomForSeparateDTO
    {
        public int OldRoomId { get; set; }
        public DateTime StartDateRenovate { get; set; }
        public DateTime EndDateRenovate { get; set; }
        public int Hours { get; set; }
      //  public FreeSpaceDTO Termins { get; set; }
        public string NewRoom1Name { get; set; }
        public string NewRoom1Type { get; set; }
        public string NewRoom2Name { get; set; }
        public string NewRoom2Type { get; set; }

        public RoomForSeparateDTO(int oldRoomId, DateTime startDateRenovate, DateTime endDateRenovate, int hours, string newRoom1Name, string newRoom1Type, string newRoom2Name, string newRoom2Type)
        {
            OldRoomId = oldRoomId;
            StartDateRenovate = startDateRenovate;
            EndDateRenovate = endDateRenovate;
            Hours = hours;
         //   Termins = termins;
            NewRoom1Name = newRoom1Name;
            NewRoom1Type = newRoom1Type;
            NewRoom2Name = newRoom2Name;
            NewRoom2Type = newRoom2Type;
        }

        public RoomForSeparateDTO() { }
    }
}
