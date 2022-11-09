using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalLibrary.GraphicalEditor.Model;

namespace HospitalLibrary.Core.Model
{
    public class Examination
    {
        public int Id { get; set; }

        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        public int PatientId { get; set; }
        public Patient Patient { get; set; }

        public int RoomId { get; set; }
        public Room Room { get; set; }

        public DateTime StartTime { get; set; }
        public int Duration { get; set; }

        public Examination()
        {
        }

        public Examination(int id, int doctorId, Doctor doctor, int patientId, Patient patient, int roomId, Room room, DateTime startTime, int duration)
        {
            Id = id;
            DoctorId = doctorId;
            Doctor = doctor;
            PatientId = patientId;
            Patient = patient;
            RoomId = roomId;
            Room = room;
            StartTime = startTime;
            Duration = duration;
        }
    }
}