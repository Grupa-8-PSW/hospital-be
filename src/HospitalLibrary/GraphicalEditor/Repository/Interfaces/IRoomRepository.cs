using HospitalLibrary.GraphicalEditor.Model;
using HospitalLibrary.GraphicalEditor.Model.DTO;

namespace HospitalLibrary.GraphicalEditor.Repository.Interfaces
{
    public interface IRoomRepository
    {
        IEnumerable<Room> GetAll();
       
        Room GetById(int id);

        IEnumerable<Room> GetRoomsByFloorId(int id);

        IEnumerable<Room> GetTransferedEquipment(EquipmentTransferDTO dto);
    }
}
