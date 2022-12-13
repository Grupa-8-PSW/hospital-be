using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.GraphicalEditor.Model.DTO
{
    public class MergedRoomDTO
    {
        public Room Room { get; set; }

        public MergedRoomDTO (Room room)
        {
            Room = room;
        }
        
        public MergedRoomDTO () { }
    }
}
