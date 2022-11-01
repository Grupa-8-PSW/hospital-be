using HospitalLibrary.GraphicalEditor.Model.Map;

namespace HospitalLibrary.GraphicalEditor.Service.Interfaces
{
    public interface IMapRoomService
    {
        IEnumerable<MapRoom> GetAll();
        MapRoom GetById(int id);
    }
}
