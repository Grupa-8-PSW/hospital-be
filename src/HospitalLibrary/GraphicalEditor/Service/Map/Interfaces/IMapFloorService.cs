using HospitalLibrary.GraphicalEditor.Model.Map;

namespace HospitalLibrary.GraphicalEditor.Service.Interfaces
{
    public interface IMapFloorService
    {
        IEnumerable<MapFloor> GetAll();
        MapFloor GetById(int id);
    }
}
