using HospitalLibrary.GraphicalEditor.Model.Map;

namespace HospitalLibrary.GraphicalEditor.Repository.Map.Interfaces
{
    public interface IMapFloorRepository
    {
        IEnumerable<MapFloor> GetAll();
        MapFloor GetById(int id);
    }
}
