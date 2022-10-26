using HospitalLibrary.Shared;
namespace HospitalLibrary.Feedback
{
    public interface IFeedbackRepository : IEntityRepository<Feedback>
    {
        public List<Feedback> GetAllPublic();
    }
}
