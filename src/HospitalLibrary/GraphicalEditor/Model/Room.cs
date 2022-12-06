using HospitalLibrary.Core.Enums;
using HospitalLibrary.Core.Model;
using HospitalLibrary.GraphicalEditor.Model.Map;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalLibrary.GraphicalEditor.Model
{
    public class Room
    {
        public Room() { }

        public int Id { get; set; }
        [Required]

        public RoomType Type { get; set; }
        public string Number { get; set; }
        public string Name { get; set; }

        [Column(TypeName = "jsonb")]
        public MapRoom Map { get; set; }
        public int FloorId { get; set; }
        public virtual Floor Floor { get; set; }

        //[Column(TypeName = "jsonb")]
        //public ICollection<Equipment> Equipment { get; set; }
        public ICollection<Bed> Beds { get; set; }

        public Room(int id, RoomType type, string number, string name, MapRoom map, int floorId, Floor floor, ICollection<Bed> beds)
        {
            Id = id;
            Type = type;
            Number = number;
            Name = name;
            Map = map;
            FloorId = floorId;
            Floor = floor;
            Beds = beds;
        }
    }
}