using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.GraphicalEditor.Model.DTO
{
    public class RoomForSeparateDTO
    {
        public Room OldRoom { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public int Hours { get; set; }
        public FreeSpaceDTO Termins { get; set; }
        public string NewRoomName { get; set; }
        public string NewRoomType { get; set; }

        public RoomForSeparateDTO (Room oldRoom, DateTime startDate, DateTime endDate, int hours, FreeSpaceDTO termins, string newRoomName, string newRoomType)
        {
            OldRoom = oldRoom;
            this.startDate = startDate;
            this.endDate = endDate;
            Hours = hours;
            Termins = termins;
            NewRoomName = newRoomName;
            NewRoomType = newRoomType;
        }
        public RoomForSeparateDTO() { }
    }
}
