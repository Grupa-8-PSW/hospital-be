using HospitalLibrary.GraphicalEditor.Model;
using HospitalLibrary.GraphicalEditor.Repository.Interfaces;
using HospitalLibrary.GraphicalEditor.Service.Interfaces;

namespace HospitalLibrary.GraphicalEditor.Service
{
    public class RenovationService : IRenovationService
    {
        private readonly IRenovationRepository _renovationRepository;

        public RenovationService(IRenovationRepository renovationRepository)
        {
            _renovationRepository = renovationRepository;
        }

        public IEnumerable<Renovation> GetAll()
        {
            return _renovationRepository.GetAll();
        }

        public Renovation GetById(int id)
        {
            return _renovationRepository.GetById(id);
        }
    }
}
