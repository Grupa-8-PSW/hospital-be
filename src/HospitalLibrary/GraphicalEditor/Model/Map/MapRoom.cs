using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.GraphicalEditor.Model.Map
{
    public class MapRoom
    {
        public int Id { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public string color { get; set; }

        public int RoomId { get; set; }

        public virtual Room Room { get; set; }
    }
}
