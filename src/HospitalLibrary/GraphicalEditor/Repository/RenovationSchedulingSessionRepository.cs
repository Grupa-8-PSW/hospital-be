using HospitalLibrary.Core.Model.Aggregates.RenovationScheduling;
using HospitalLibrary.Core.Repository;
using HospitalLibrary.GraphicalEditor.BusinessUseCases;
using HospitalLibrary.GraphicalEditor.Enums;
using HospitalLibrary.GraphicalEditor.Repository.Interfaces;
using HospitalLibrary.Settings;

namespace HospitalLibrary.GraphicalEditor.Repository
{
    public class RenovationSchedulingSessionRepository : BaseEntityModelRepository<RenovationEventWrapper>, IRenovationSchedulingSessionRepository
    {
        public RenovationSchedulingSessionRepository(HospitalDbContext dbContext) : base(dbContext)
        {
        }

        public List<int> GetAll()
        {
            return _dbContext.RenovationEventWrappers.Where(e => e.EventType == RenovationEventType.SESSION_ENDED).Select(ev => ev.AggregateId).ToList();
        }

    }
}
