using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Model.ValueObjects;
using HospitalLibrary.Core.Repository;
using HospitalLibrary.GraphicalEditor.Model;
using HospitalLibrary.GraphicalEditor.Model.DTO;
using HospitalLibrary.GraphicalEditor.Model.Map;
using HospitalLibrary.GraphicalEditor.Repository.Interfaces;
using HospitalLibrary.GraphicalEditor.Service.Interfaces;

namespace HospitalLibrary.GraphicalEditor.Service
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IEquipmentRepository _equipmentRepository;
        private readonly IExaminationRepository _examinationRepository;

        public EquipmentTransferDTO dto;

        public RoomService(IRoomRepository roomRepository, IExaminationRepository examinationRepository, IEquipmentRepository equipmentRepository)
        {
            _roomRepository = roomRepository;
            _examinationRepository = examinationRepository;
            _equipmentRepository = equipmentRepository;
        }

        public IEnumerable<Room> GetAll()
        {
            return _roomRepository.GetAll();
        }

        public IEnumerable<Room> Search(string name)
        {
            return _roomRepository.Search(name);
        }

        public Room GetById(int id)
        {
            return _roomRepository.GetById(id);
        }

        public IEnumerable<Room> GetRoomsByFloorId(int id)
        {
            try
            {
                return _roomRepository.GetRoomsByFloorId(id);

            }
            catch (Exception e)
            {
                return null;
            }

        }

        private List<DateRange> GetAvailableIntervals(int fromRoomId, int toRoomId, DateTime startDate, DateTime endDate, int durationInHours)
        {
            List<DateRange> froms = GetAvailableSlots(fromRoomId, startDate, endDate, durationInHours);
            List<DateRange> tos = GetAvailableSlots(toRoomId, startDate, endDate, durationInHours);
            List<DateRange> available = new();

            foreach (DateRange from in froms)
            {
                foreach (DateRange to in tos)
                {
                    if (from.Contains(to))
                        available.Add(to);
                    else if (to.Contains(from))
                        available.Add(from);
                }
            }
            return available;
        }

        private List<DateRange> GetAvailableSlots(int roomId, DateTime from, DateTime to, int duration)
        {
            List<DateRange> intervals = CreateSlots(from, to, duration);

            var examinations = _examinationRepository.GetByRoomId(roomId);
            var transfers = _equipmentRepository.GetEquipmentTransferByRoomId(roomId);
            //var renovations = _renovationRepository.GetByRoomId(roomId);

            foreach (DateRange i in intervals)
            {
                foreach (Examination examination in examinations)
                {
                    DateRange interval = new(examination.DateRange.Start,
                        examination.DateRange.Start.AddMinutes(examination.DateRange.DurationInMinutes));

                    if (interval.IsOverlapped(i))
                        intervals.Remove(i);
                }
                foreach (EquipmentTransfer transfer in transfers)
                {
                    DateRange interval = new(transfer.StartDate, transfer.EndDate);

                    if (interval.IsOverlapped(i))
                        intervals.Remove(i);
                }
                /*
                foreach (Renovation renovation in Renovations)
                {
                    DateRange interval = new(renovation.DateRange.Start, renovation.DateRange.End);

                    if (interval.IsOverlapped(i))
                        intervals.Remove(i);
                }
                */
            }
            return intervals;
        }

        private List<DateRange> CreateSlots(DateTime from, DateTime to, int hours)
        {
            DateRange searchedInterval = new(from, to);
            List<DateRange> slots = new();

            DateRange slot = new(from, from.AddHours(hours));
            while (searchedInterval.Contains(slot))
            {
                slots.Add(slot);
                slot = new(slot.Start.AddMinutes(30), slot.End.AddMinutes(30));
            }
            return slots;
        }

        public SeparatedRoomsDTO GetSeparatedRooms(RoomForSeparateDTO dto)
        {
            Room oldRoom = new Room();
            oldRoom = GetById(dto.OldRoomId);

            SeparatedRoomsDTO newRooms = new SeparatedRoomsDTO();

            Random rnd = new Random();
            MapRoom firstRoom = new MapRoom(oldRoom.Map.X, oldRoom.Map.Y, oldRoom.Map.Width / 2, oldRoom.Map.Height, "blue");
            newRooms.FirstRoom = new Room(rnd.Next(30, 3000), Core.Enums.RoomType.OTHER, oldRoom.Number, dto.NewRoom1Name, firstRoom, oldRoom.FloorId, null);
            MapRoom secondRoom = new MapRoom(oldRoom.Map.X, oldRoom.Map.Y + oldRoom.Map.Width / 2, oldRoom.Map.Width / 2, oldRoom.Map.Height, "blue");
            newRooms.SecondRoom = new Room(rnd.Next(30, 3000), Core.Enums.RoomType.OPERATIONS, oldRoom.Number + "a", dto.NewRoom2Name, secondRoom, oldRoom.FloorId, null);

            _roomRepository.Create(newRooms.FirstRoom);
            _roomRepository.Create(newRooms.SecondRoom);
            _roomRepository.Delete(oldRoom);

            return newRooms;
        }

        public MergedRoomDTO GetMergedRoom(RoomsForMergeDTO dto)
        {
            Room oldRoom1 = new Room();
            Room oldRoom2 = new Room();
            Random rnd = new Random();

            oldRoom1 = GetById(dto.OldRoom1Id);
            oldRoom2 = GetById(dto.OldRoom2Id);

            MergedRoomDTO newRoom = new MergedRoomDTO();
            MapRoom mergedRoomMap = new MapRoom();

            mergedRoomMap = new MapRoom(oldRoom1.Map.X, oldRoom1.Map.Y, oldRoom1.Map.Width + oldRoom2.Map.Width, (oldRoom1.Map.Height + oldRoom2.Map.Height) / 2, "blue");
            newRoom.Room = new Room(rnd.Next(30, 300), Core.Enums.RoomType.OTHER, oldRoom1.Number, dto.NewRoomName, mergedRoomMap, oldRoom1.FloorId, null);

            _roomRepository.Create(newRoom.Room);
            _roomRepository.Delete(oldRoom1);
            _roomRepository.Delete(oldRoom2);

            return newRoom;
        }

        public List<FreeSpaceDTO> GetTransferedEquipment(EquipmentTransferDTO dto)
        {
            List<DateRange> slots = GetAvailableIntervals(dto.FromRoomId, dto.ToRoomId, dto.StartDate.AddHours(1), dto.EndDate.AddHours(1), dto.Duration);
            List<FreeSpaceDTO> dtos = new();

            foreach (var slot in slots)
            {
                dtos.Add(new FreeSpaceDTO(slot.Start, slot.End));
            }
            return dtos;
        }

        public IEnumerable<Room> GetFreeRooms()
        {
            return _roomRepository.GetFreeRooms();
        }


        public SchedulesDTO GetSchedules(int id)
        {
            var examinationDTOs = EntityToEntityExeListDTO(_examinationRepository.GetByRoomId(id).ToList());
            var equipmentTransferDTOs = EntityToEntityEquipListDTO(_equipmentRepository.GetEquipmentTransferByRoomId(id).ToList());


            SchedulesDTO shedulesDto = new SchedulesDTO(examinationDTOs, equipmentTransferDTOs);
            return shedulesDto;
        }
        private List<ExaminationDTO> EntityToEntityExeListDTO(List<Examination> entities)
        {
            var retList = new List<ExaminationDTO>();
            foreach (var item in entities)
            {
                retList.Add(new ExaminationDTO(item.Id, item.DateRange.Start, item.DateRange.DurationInMinutes));
            }

            return retList;
        }

        private List<EquipmentTransferDTO> EntityToEntityEquipListDTO(List<EquipmentTransfer> entities)
        {
            var retList = new List<EquipmentTransferDTO>();
            foreach (var item in entities)
            {
                retList.Add(new EquipmentTransferDTO(item.Id, item.StartDate, item.EndDate, item.FromRoomId, item.ToRoomId));
            }

            return retList;
        }
    }
}
