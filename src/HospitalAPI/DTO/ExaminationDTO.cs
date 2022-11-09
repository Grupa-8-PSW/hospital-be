namespace HospitalAPI.Web.Dto
{
    public class ExaminationDTO
    {
        public int? Id { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public string StartTime { get; set; }
        public int Duration { get; set; }
        public string PatientFirstName { get; set; }
        public string PatientLastName { get; set; }
    }
}