using HospitalLibrary.GraphicalEditor.Model.Map;

namespace HospitalLibrary.GraphicalEditor.Repository.Map.Interfaces
{
    public interface IMapBuildingRepository
    {
        IEnumerable<MapBuilding> GetAll();
        MapBuilding GetById(int id);
    }
}
