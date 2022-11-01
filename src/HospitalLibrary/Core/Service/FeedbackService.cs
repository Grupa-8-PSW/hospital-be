using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Repository;

namespace HospitalLibrary.Core.Service
{
    public class FeedbackService : IFeedbackService
    {
        private readonly IFeedbackRepository _feedbackRepository;
        private readonly IPatientRepository _petientRepository;

        public FeedbackService(IFeedbackRepository feedbackRepository, IPatientRepository patientRepository)
        {
            _feedbackRepository = feedbackRepository;
            _petientRepository = patientRepository;
        }

        public List<Feedback> GetAll() => HandleAnonymous(_feedbackRepository.GetAll());

        public Feedback GetById(int id) => HandleAnonymous(_feedbackRepository.GetById(id));

        public List<Feedback> GetAllPublic() => HandleAnonymous(_feedbackRepository.GetAllPublic());

        public Feedback Create(Feedback feedback)
        {
            feedback.Status = FeedbackStatus.OnHold;
            feedback.PatientId = 1;
            feedback.CreationDate = DateOnly.FromDateTime(DateTime.Now);
            feedback.Patient = _petientRepository.GetById(1);
            return HandleAnonymous(_feedbackRepository.Create(feedback));
        }

        public void Update(Feedback feedback) => _feedbackRepository.Update(feedback);

        public void Delete(int id) => _feedbackRepository.Delete(id);

        public void ChangeStatus(int id, FeedbackStatus feedbackStatus)
        {
            var feedback = _feedbackRepository.GetById(id);
            if (feedback == null)
                return;
            feedback.Status = feedbackStatus;
            _feedbackRepository.Update(feedback);
        }

        private Feedback HandleAnonymous(Feedback feedback)
        {
            if (feedback.IsAnonymous)
                feedback.SetAnonymous();
            return feedback;
        }

        private List<Feedback> HandleAnonymous(List<Feedback> feedbacks)
        {
            foreach (var feedback in feedbacks)
                HandleAnonymous(feedback);
            return feedbacks;
        }

    }
}
