using HospitalLibrary.Core.Enums;
using HospitalLibrary.Core.Model;
using HospitalLibrary.GraphicalEditor.Model.Map;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalLibrary.GraphicalEditor.Model
{
    public class Room : BaseEntityModel
    {
        private List<Bed> _beds = new();
        private List<Equipment> _equipment = new();

        public RoomType Type { get; private set; }
        public string Number { get; private set; }
        public string Name { get; private set; }

        [Column(TypeName = "jsonb")]
        public MapRoom Map { get; private set; }
        public int FloorId { get; private set; }
        public virtual Floor Floor { get; private set; }

        public virtual List<Bed> Beds
        {
            get => new(_beds);
            private set => _beds = value;
        }

        public virtual List<Equipment> Equipment
        {
            get => new(_equipment);
            private set => _equipment = value;
        }

        public Room(RoomType type, string number, string name, MapRoom map, int floorId, Floor floor,
            List<Bed> beds, List<Equipment> equipment)
        {
            Type = type;
            Number = number;
            Name = name;
            Map = map;
            FloorId = floorId;
            Floor = floor;
            _beds = beds;
            _equipment = equipment;
            Validate();
        }

        public Room(int id, RoomType type, string number, string name, MapRoom map, int floorId, Floor floor)
        {
            Id = id;
            Type = type;
            Number = number;
            Name = name;
            Map = map;
            FloorId = floorId;
            Floor = floor;
            _beds = new();
            _equipment = new();
            Validate();
        }

        public Room()
        {
        }

        private void Validate()
        {
            //throw new ArgumentException("Not Implemented");
        }
    }
}