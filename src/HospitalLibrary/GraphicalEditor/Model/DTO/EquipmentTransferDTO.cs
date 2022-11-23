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

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int Duration { get; set; }

        public string EquipmentName { get; set; }
    }
}
