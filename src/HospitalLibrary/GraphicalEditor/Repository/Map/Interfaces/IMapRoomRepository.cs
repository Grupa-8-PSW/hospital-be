using HospitalLibrary.GraphicalEditor.Model.Map;

namespace HospitalLibrary.GraphicalEditor.Repository.Map.Interfaces
{
    public interface IMapRoomRepository
    {
        IEnumerable<MapRoom> GetAll();
        MapRoom GetById(int id);
    }
}
