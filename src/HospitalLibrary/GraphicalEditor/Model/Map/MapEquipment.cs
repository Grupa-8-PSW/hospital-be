using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.GraphicalEditor.Model.Map
{
    public class MapEquipment
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Amount { get; set; }

        public string RoomId { get; set; }
    }
}
