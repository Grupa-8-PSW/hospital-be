using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Model.ValueObjects;
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

        SchedulesDTO GetSchedules(int id);
        SeparatedRoomsDTO GetSeparatedRooms(RoomForSeparateDTO dto);
        MergedRoomDTO GetMergedRoom(RoomsForMergeDTO dto);
        List<DateRange> GetAvailableIntervals(int fromRoomId, int toRoomId, DateTime startDate, DateTime endDate, int durationInHours);
        List<DateRange> GetAvailableSlots(int roomId, DateTime from, DateTime to, int duration);
    }
}
