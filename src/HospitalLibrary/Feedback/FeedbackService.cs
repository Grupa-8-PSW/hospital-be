
namespace HospitalLibrary.Feedback
{
    public class FeedbackService : IFeedbackService
    {
        private readonly IFeedbackRepository _feedbackRepository;

        public FeedbackService(IFeedbackRepository feedbackRepository)
        {
            _feedbackRepository = feedbackRepository;
        }

        public List<Feedback> GetAll() => _feedbackRepository.GetAll();

        public Feedback GetById(int id) => _feedbackRepository.GetById(id);

        public Feedback Create(Feedback feedback) => _feedbackRepository.Create(feedback);

        public void Update(Feedback feedback) => _feedbackRepository.Update(feedback);
        
        public void Delete(int id) => _feedbackRepository.Delete(id);

    }
}
