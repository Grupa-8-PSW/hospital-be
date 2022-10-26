namespace HospitalAPI.Web.DTO
{
    public class PublicFeedbackDTO
    {
        public string PatientFullName { get; set; }
        public string Text { get; set; }
        public int Rating { get; set; }
        public DateOnly CreationDate { get; set; }
    }
}
