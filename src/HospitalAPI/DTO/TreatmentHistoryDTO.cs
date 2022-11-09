using HospitalLibrary.Core.Model;

namespace HospitalAPI.DTO
{
    public class TreatmentHistoryDTO    //ispravi
    {
        public int? Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Active { get; set; }
        public string DischargeReason { get; set; }
        public IEnumerable<Therapy> Therapies { get; set; }
        public int PatientId { get; set; }
        public int BedId { get; set; }
    }
}
 