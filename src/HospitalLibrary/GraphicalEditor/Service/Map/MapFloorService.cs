using HospitalLibrary.GraphicalEditor.Model.Map;
using HospitalLibrary.GraphicalEditor.Repository.Map.Interfaces;
using HospitalLibrary.GraphicalEditor.Service.Interfaces;

namespace HospitalLibrary.GraphicalEditor.Service
{
    public class MapFloorService : IMapFloorService
    {
        private readonly IMapFloorRepository _floorRepository;

        public MapFloorService(IMapFloorRepository floorRepository)
        {
            _floorRepository = floorRepository;
        }

        public IEnumerable<MapFloor> GetAll()
        {
            return _floorRepository.GetAll();
        }

        public MapFloor GetById(int id)
        {
            return _floorRepository.GetById(id);
        }
    }
}
