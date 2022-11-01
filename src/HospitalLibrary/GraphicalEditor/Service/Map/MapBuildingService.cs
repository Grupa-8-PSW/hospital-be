using HospitalLibrary.GraphicalEditor.Model.Map;
using HospitalLibrary.GraphicalEditor.Repository.Map.Interfaces;
using HospitalLibrary.GraphicalEditor.Service.Interfaces;

namespace HospitalLibrary.GraphicalEditor.Service
{
    public class MapBuildingService : IMapBuildingService
    {
        private readonly IMapBuildingRepository _buildingRepository;

        public MapBuildingService(IMapBuildingRepository buildingRepository)
        {
            _buildingRepository = buildingRepository;
        }

        public IEnumerable<MapBuilding> GetAll()
        {
            return _buildingRepository.GetAll();
        }

        public MapBuilding GetById(int id)
        {
            return _buildingRepository.GetById(id);
        }
    }
}
