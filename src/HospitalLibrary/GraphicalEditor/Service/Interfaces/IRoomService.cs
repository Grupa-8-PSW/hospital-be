using HospitalLibrary.GraphicalEditor.Model;

namespace HospitalLibrary.GraphicalEditor.Service.Interfaces
{
    public interface IRoomService
    {
        IEnumerable<Room> GetAll();

        IEnumerable<Room> Search(string name);

        Room GetById(int id);

        IEnumerable<Room> GetRoomsByFloorId(int id);
        public IEnumerable<Room> GetFreeRooms();
    }
}
