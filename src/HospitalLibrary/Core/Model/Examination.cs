using HospitalLibrary.Core.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using HospitalLibrary.Core.Model.ValueObjects;

namespace HospitalLibrary.Core.Model
{
    public class Examination
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        [Column(TypeName = "jsonb")]
        public DateRange DateRange { get; set; }
        public ExaminationStatus Status { get; set; }

        public Examination()
        {
        }

        public Examination(int id, int doctorId, int patientId, DateRange dateRange, ExaminationStatus status = ExaminationStatus.UPCOMING)
        {
            Id = id;
            DoctorId = doctorId;
            PatientId = patientId;
            DateRange = dateRange;
            Status = status;
        }

    }
}