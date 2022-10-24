using HospitalLibrary.Shared;

namespace HospitalLibrary.Feedback
{
    public class Feedback : BaseEntityModel
    {
        public int PatientId { get; private set; }
        public Patient.Patient Patient { get; private set; }
        public string Text { get; private set; }
        public int Rating { get; private set; }
        public DateOnly CreationDate { get; private set; }
        public bool IsAnonymous { get; private set; }
        public bool IsPublic { get; private set; }
        public FeedbackStatus Status { get; private set; }

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
    }

    public enum FeedbackStatus { OnHold, Approved, Denied }

}
