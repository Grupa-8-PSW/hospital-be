using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.GraphicalEditor.Model.DTO
{
    public class EquipmentTransferDTO
    {
        public int Amount { get; set; }

        public int FromRoomId { get; set; }

        public int ToRoomId { get; set; }
    }
}
