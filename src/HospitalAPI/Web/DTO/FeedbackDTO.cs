using HospitalLibrary.Feedback;

namespace HospitalAPI.Web.DTO
{
    public class FeedbackDTO
    {
        public int Id { get; set; }
        public string PatientFullName { get; set; }
        public string Text { get; set; }
        public int Rating { get; set; }
        public DateOnly CreationDate { get; set; }
        public bool IsPublic { get; set; }
        public FeedbackStatus Status { get; set; }
    }

}
