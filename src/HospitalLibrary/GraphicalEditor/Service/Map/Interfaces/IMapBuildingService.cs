using HospitalLibrary.GraphicalEditor.Model.Map;

namespace HospitalLibrary.GraphicalEditor.Service.Interfaces
{
    public interface IMapBuildingService
    {
        IEnumerable<MapBuilding> GetAll();
        MapBuilding GetById(int id);
    }
}
