using HospitalLibrary.Core.Model;
using HospitalLibrary.GraphicalEditor.Model;
using HospitalLibrary.GraphicalEditor.Model.DTO;

namespace HospitalLibrary.GraphicalEditor.Service.Interfaces
{
    public interface IRoomService
    {
        IEnumerable<Room> GetAll();

        IEnumerable<Room> Search(string name);

        Room GetById(int id);

        IEnumerable<Room> GetRoomsByFloorId(int id);
        public IEnumerable<Room> GetFreeRooms();

        List<FreeSpaceDTO> GetTransferedEquipment(EquipmentTransferDTO dto);

        SeparatedRoomsDTO GetSeparatedRooms(RoomForSeparateDTO dto);

        MergedRoomDTO GetMergedRoom(RoomsForMergeDTO dto);

        SchedulesDTO GetSchedules(int id);
    }
}
