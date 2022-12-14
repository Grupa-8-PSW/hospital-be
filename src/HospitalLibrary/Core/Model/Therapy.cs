using HospitalLibrary.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Model
{
    public class Therapy
    {
        public int Id { get; set; }
        public DateTime WhenPrescribed { get; set; }
        public int Amount { get; set; }
        public string Reason { get; set; }
        public TherapyType TherapyType { get; set; }
        public string TherapySubject { get; set; }      //medical drug code or blood type MedicalDrugs
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public int TreatmentHistoryId { get; set; }
        public TreatmentHistory TreatmentHistory { get; set; }

        public Therapy()
        {
        }

        public Therapy(int id, DateTime whenPrescribed, int amount, string reason, TherapyType therapyType, string therapySubject, int doctorId, Doctor doctor, int treatmentHistoryId, TreatmentHistory treatmentHistory)
        {
            Id = id;
            WhenPrescribed = whenPrescribed;
            Amount = amount;
            Reason = reason;
            TherapyType = therapyType;
            TherapySubject = therapySubject;
            DoctorId = doctorId;
            Doctor = doctor;
            TreatmentHistoryId = treatmentHistoryId;
            TreatmentHistory = treatmentHistory;
        }
    }
}
