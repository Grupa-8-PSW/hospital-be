using HospitalLibrary.Core.Model.Aggregates.RenovationScheduling;
using HospitalLibrary.Core.Repository;

namespace HospitalLibrary.GraphicalEditor.Repository.Interfaces
{
    public interface IRenovationSchedulingSessionRepository : IEntityRepository<RenovationEventWrapper>
    {
        List<int> GetScheduledRenovations();

    }
}
