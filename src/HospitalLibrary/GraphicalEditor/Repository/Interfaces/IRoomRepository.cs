using HospitalLibrary.GraphicalEditor.Model;
using HospitalLibrary.GraphicalEditor.Model.DTO;

namespace HospitalLibrary.GraphicalEditor.Repository.Interfaces
{
    public interface IRoomRepository
    {
        IEnumerable<Room> GetAll();

        IEnumerable<Room> Search(string name);
        
        Room GetById(int id);

        IEnumerable<Room> GetRoomsByFloorId(int id);
        IEnumerable<Room> GetFreeRooms();

        IEnumerable<Room> GetTransferedEquipment(EquipmentTransferDTO dto);
    }
}
