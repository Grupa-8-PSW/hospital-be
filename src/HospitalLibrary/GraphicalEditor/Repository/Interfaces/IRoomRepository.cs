using HospitalLibrary.GraphicalEditor.Model;

namespace HospitalLibrary.GraphicalEditor.Repository.Interfaces
{
    public interface IRoomRepository
    {
        IEnumerable<Room> GetAll();

        IEnumerable<Room> Search(string name);
        
        Room GetById(int id);

        IEnumerable<Room> GetRoomsByFloorId(int id);
    }
}
