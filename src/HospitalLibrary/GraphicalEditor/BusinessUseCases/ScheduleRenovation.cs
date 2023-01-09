using HospitalLibrary.Core.Model.Aggregates.RenovationScheduling;
using HospitalLibrary.GraphicalEditor.Repository.Interfaces;

namespace HospitalLibrary.GraphicalEditor.BusinessUseCases
{
    public class ScheduleRenovation
    {
        private readonly IRenovationSchedulingSessionRepository _sessionRepository;

        public ScheduleRenovation(IRenovationSchedulingSessionRepository sessionRepository)
        {
            _sessionRepository = sessionRepository;
        }

        public void Create(RenovationSchedulingSession session)
        {
            _sessionRepository.Add(session);
        }

    }
}
