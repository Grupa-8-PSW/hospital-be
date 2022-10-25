
namespace HospitalLibrary.Feedback
{
    public interface IFeedbackService
    {
        public List<Feedback> GetAll();
        public Feedback GetById(int id);
        public List<Feedback> GetAllPublic();
        public Feedback Create(Feedback feedback);
        public void Update(Feedback feedback);
        public void Delete(int id);
        public void ChangeStatus(int id, FeedbackStatus feedbackStatus);
    }
}
