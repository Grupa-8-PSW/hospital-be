using HospitalLibrary.Core.Enums;
using HospitalLibrary.Core.Model;

namespace HospitalAPI.DTO
{
    public class TherapyDTO
    {
        public int? Id { get; set; }
        public string? WhenPrescribed { get; set; }
        public int Amount { get; set; }
        public string Reason { get; set; }
        public string TherapyType { get; set; }
        public string TherapySubject { get; set; }      //medical drug name or blood type MedicalDrugs
        public int DoctorId { get; set;}
        public int TreatmentHistoryId { get; set; }

        public TherapyDTO()
        {
        }

        public TherapyDTO(int id, string whenPrescribed, int amount, string reason, string therapyType, string therapySubject, int doctorId, int treatmentHistoryId)
        {
            Id = id;
            WhenPrescribed = whenPrescribed;
            Amount = amount;
            Reason = reason;
            TherapyType = therapyType;
            TherapySubject = therapySubject;
            DoctorId = doctorId;
            TreatmentHistoryId = treatmentHistoryId;
        }
    }
}
