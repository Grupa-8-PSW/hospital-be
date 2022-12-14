using HospitalLibrary.Core.Enums;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Model.ValueObjects;
using HospitalLibrary.GraphicalEditor.Model.Map;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalLibrary.GraphicalEditor.Model
{
    public class Room
    {
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
        public ICollection<Examination> Examinations { get; set; }
        public ICollection<EquipmentTransfer> Transfers { get; set; }

        //public ICollection<Renovation> Renovations { get; set; }

        public Room(int id, RoomType type, string number, string name, MapRoom map, int floorId, Floor floor)
        {
            Id = id;
            Type = type;
            Number = number;
            Name = name;
            Map = map;
            FloorId = floorId;
            Floor = floor;
        }

        public Room() { }

        public List<DateRange> GetAvailableIntervals(DateTime from, DateTime to, int duration)
        {
            List<DateRange> intervals = CreateIntervals(from, to, duration);

            foreach (DateRange i in intervals)
            {
                foreach (Examination examination in Examinations)
                {
                    DateRange interval = new(examination.StartTime,
                        examination.StartTime.AddMinutes(examination.Duration));

                    if (interval.OverlapsWith(i))
                        intervals.Remove(i);
                }
                foreach (EquipmentTransfer transfer in Transfers)
                {
                    DateRange interval = new(transfer.StartDate, transfer.EndDate);

                    if (interval.OverlapsWith(i))
                        intervals.Remove(i);
                }
                /*
                foreach (Renovation renovation in Renovations)
                {
                    DateRange interval = new(renovation.StartDate, renovation.EndDate);

                    if (interval.OverlapsWith(i))
                        intervals.Remove(i);
                }
                */
            }
            return intervals;
        }

        private List<DateRange> CreateIntervals(DateTime from, DateTime to, int minutes)
        {
            DateRange searchedInterval = new(from.AddHours(1), to.AddHours(1));
            List<DateRange> intervals = new();

            DateRange interval = new(from, from.AddMinutes(minutes));
            while (searchedInterval.IncludesRange(interval))
            {
                intervals.Add(interval);
                interval = new(from.AddMinutes(30), from.AddMinutes(minutes + 30));
            }
            return intervals;
        }

    }
}