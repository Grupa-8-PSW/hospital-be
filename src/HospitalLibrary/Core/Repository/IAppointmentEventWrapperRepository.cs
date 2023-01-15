using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Model.Aggregates.AppointmentScheduling;

namespace HospitalLibrary.Core.Repository
{
    public interface IAppointmentEventWrapperRepository : IEntityRepository<AppointmentEventWrapper>
    {
        public List<int> GetScheduledAggregates();
        public int getNumOfAllAggregates();

    }
}