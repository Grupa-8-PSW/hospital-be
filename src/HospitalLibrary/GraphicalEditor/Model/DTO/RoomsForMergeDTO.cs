using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.GraphicalEditor.Model.DTO
{
    public class RoomsForMergeDTO
    {
        public int OldRoom1Id { get; set; }
        public int OldRoom2Id { get; set; }
        public string NewRoomName { get; set; }
        public string NewRoomType { get; set; }

        public RoomsForMergeDTO (int oldRoom1Id, int oldRoom2Id, string newRoomName, string newRoomType)
        {
            OldRoom1Id = oldRoom1Id;
            OldRoom2Id = oldRoom2Id;
            NewRoomName = newRoomName;
            NewRoomType = newRoomType;
        }

        public RoomsForMergeDTO() { }
    }
}
