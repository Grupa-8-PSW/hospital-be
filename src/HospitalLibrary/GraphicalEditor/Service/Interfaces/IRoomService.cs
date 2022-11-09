using HospitalLibrary.GraphicalEditor.Model;

namespace HospitalLibrary.GraphicalEditor.Service.Interfaces
{
    public interface IRoomService
    {
        IEnumerable<Room> GetAll();
        Room GetById(int id);

        IEnumerable<Room> GetRoomsByFloorId(int id);
    }
}
