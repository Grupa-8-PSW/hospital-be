using HospitalLibrary.Core.Enums;
using HospitalLibrary.GraphicalEditor.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Model
{
    public class Doctor
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get => FirstName + " " + LastName; }
        public int RoomId { get; set; }
        public Room Room { get; set; }
        public DateTime StartWork { get; set; }
        public DateTime EndWork { get; set; }
        public virtual List<Consilium> Consiliums { get; set; }
        public DoctorSpecialization Specialization { get; set; }
        public Doctor()
        {
        }

        public Doctor(int id, string firstName, string lastName, int roomId, Room room, DateTime startWork, DateTime endWork, DoctorSpecialization specialization)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            RoomId = roomId;
            Room = room;
            StartWork = startWork;
            EndWork = endWork;
            Specialization = specialization;
        }
    }
}