using HospitalLibrary.GraphicalEditor.Model;
using HospitalLibrary.GraphicalEditor.Service;

namespace HospitalLibrary.GraphicalEditor.Repository.Interfaces
{
    public interface IRoomRepository
    {
        IEnumerable<Room> GetAll();
        Room GetById(int id);

        IEnumerable<Room> GetRoomsByFloorId(int id);
        IEnumerable<Room> GetFreeRooms();
    }
}
