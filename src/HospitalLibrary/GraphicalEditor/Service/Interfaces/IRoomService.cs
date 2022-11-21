using HospitalLibrary.Core.Model;
using HospitalLibrary.GraphicalEditor.Model;
using HospitalLibrary.GraphicalEditor.Model.DTO;

namespace HospitalLibrary.GraphicalEditor.Service.Interfaces
{
    public interface IRoomService
    {
        IEnumerable<Room> GetAll();
        Room GetById(int id);

        IEnumerable<Room> GetRoomsByFloorId(int id);

        List<FreeSpaceDTO> GetTransferedEquipment(EquipmentTransferDTO dto);
    }
}
