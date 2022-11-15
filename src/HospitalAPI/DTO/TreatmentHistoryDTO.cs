using HospitalLibrary.Core.Model;

namespace HospitalAPI.DTO
{
    public class TreatmentHistoryDTO    //ispravi
    {
        public int? Id { get; set; }
        public String StartDate { get; set; }
        public String EndDate { get; set; }
        public bool Active { get; set; }
        public string DischargeReason { get; set; }
//        public IEnumerable<Therapy> Therapies { get; set; }
        public int PatientId { get; set; }
        public int BedId { get; set; }
        public string Reason { get; set; }

        public TreatmentHistoryDTO(int? id, String startDate, String endDate, bool active, string dischargeReason, int patientId, int bedId, string reason)
        {
            Id = id;
            StartDate = startDate;
            EndDate = endDate;
            Active = active;
            DischargeReason = dischargeReason;
            PatientId = patientId;
            BedId = bedId;
            Reason = reason;
        }

        public TreatmentHistoryDTO(int patientId, string reason)
        {
            PatientId = patientId;
            Reason = reason;
        }

        public TreatmentHistoryDTO()
        {
        }
    }
}
 