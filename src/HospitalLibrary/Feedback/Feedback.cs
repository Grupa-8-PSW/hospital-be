using HospitalLibrary.Shared;

namespace HospitalLibrary.Feedback
{
    public class Feedback : BaseEntityModel
    {
        public int PatientId { get; set; }
        public Patient.Patient Patient { get; set; }
        public string Text { get; set; }
        public int Rating { get; set; }
        public DateOnly CreationDate { get; set; }
        public bool IsAnonymous { get; set; }
        public bool IsPublic { get; set; }
        public FeedbackStatus Status { get; set; }

        public Feedback()
        {
            CreationDate = DateOnly.FromDateTime(DateTime.Now);
        }

        public Feedback(int id, int patientId, string text, int rating, bool isAnonymous, bool isPublic, FeedbackStatus status)
        {
            Id = id;
            PatientId = patientId;
            Text = text;
            Rating = rating;
            CreationDate = DateOnly.FromDateTime(DateTime.Now);
            IsAnonymous = isAnonymous;
            IsPublic = isPublic;
            Status = status;
        }

        public void SetAnonymous()
        {
            Patient.FirstName = "Anonymous";
            Patient.LastName = "";
        }

    }

    public enum FeedbackStatus { OnHold, Approved, Denied }

}
