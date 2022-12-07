using HospitalLibrary.Core.Enums;
using HospitalLibrary.Core.Model.ValueObjects;
using HospitalLibrary.GraphicalEditor.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalLibrary.Core.Model
{
    public class Doctor
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get => FirstName + " " + LastName; }
        public DoctorSpecialization Specialization { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }
        [Column(TypeName = "jsonb")]
        public DateRange WorkHour { get; set; }
        public List<Consilium> Consiliums { get; set; }

        public Doctor()
        {

        }

        public Doctor(int id, string firstName, string lastName, DoctorSpecialization specialization, int roomId, DateRange workHour)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Specialization = specialization;
            RoomId = roomId;
            WorkHour = workHour;
        }

    }
}