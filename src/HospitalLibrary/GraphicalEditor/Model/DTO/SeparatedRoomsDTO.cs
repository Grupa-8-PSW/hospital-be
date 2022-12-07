using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.GraphicalEditor.Model.DTO
{
    public class SeparatedRoomsDTO
    {
        public Room FirstRoom { get; set; }
        public Room SecondRoom { get; set; }

        public SeparatedRoomsDTO (Room firstRoom, Room secondRoom)
        {
            FirstRoom = firstRoom;
            SecondRoom = secondRoom;
        }
        public SeparatedRoomsDTO() { }
    }
}
