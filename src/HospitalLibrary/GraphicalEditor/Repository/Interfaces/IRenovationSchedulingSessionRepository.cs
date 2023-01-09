using HospitalLibrary.Core.Model.Aggregates.RenovationScheduling;

namespace HospitalLibrary.GraphicalEditor.Repository.Interfaces
{
    public interface IRenovationSchedulingSessionRepository
    {
        List<RenovationSchedulingSession> GetAll();

        RenovationSchedulingSession FindBy(int id);

        void Add(RenovationSchedulingSession renovationSchedulingSession);

        void Save(RenovationSchedulingSession renovationSchedulingSession);
    }
}
