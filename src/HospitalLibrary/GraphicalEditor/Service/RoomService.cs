using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Model.ValueObjects;
using HospitalLibrary.Core.Repository;
using HospitalLibrary.GraphicalEditor.Model;
using HospitalLibrary.GraphicalEditor.Model.DTO;
using HospitalLibrary.GraphicalEditor.Model.Map;
using HospitalLibrary.GraphicalEditor.Repository.Interfaces;
using HospitalLibrary.GraphicalEditor.Service.Interfaces;
using System;
using System.Threading;
using Org.BouncyCastle.Asn1.X500;

namespace HospitalLibrary.GraphicalEditor.Service
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IBedRepository _bedRepository;
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

        public List<DateRange> GetAvailableIntervals(EquipmentTransferDTO dto)
        {
            List<DateRange> froms = GetById(dto.FromRoomId).GetAvailableIntervals(dto.StartDate, dto.EndDate, dto.Duration);
            List<DateRange> tos = GetById(dto.ToRoomId).GetAvailableIntervals(dto.StartDate, dto.EndDate, dto.Duration);
            List<DateRange> available = new();

            foreach (DateRange from in froms)
            {
                foreach (DateRange to in tos)
                {
                    if (from.IncludesRange(to))
                        available.Add(to);
                    if (to.IncludesRange(from))
                        available.Add(from);
                }
            }
            return available;
        }

        public SeparatedRoomsDTO GetSeparatedRooms(RoomForSeparateDTO dto)
        {
            Room oldRoom = new Room();
            oldRoom = GetById(dto.OldRoomId);

            SeparatedRoomsDTO newRooms = new SeparatedRoomsDTO();

            Random rnd = new Random();
            MapRoom firstRoom = new MapRoom(oldRoom.Map.X, oldRoom.Map.Y, oldRoom.Map.Width / 2, oldRoom.Map.Height, "blue");
            newRooms.FirstRoom = new Room(rnd.Next(30, 3000), Core.Enums.RoomType.OTHER, oldRoom.Number, dto.NewRoom1Name, firstRoom, oldRoom.FloorId, null);
            MapRoom secondRoom = new MapRoom(oldRoom.Map.X , oldRoom.Map.Y + oldRoom.Map.Width / 2, oldRoom.Map.Width / 2,oldRoom.Map.Height, "blue");
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
            IEnumerable<Examination> fromRoomExaminations = _examinationRepository.GetByRoomId(dto.FromRoomId);
            IEnumerable<Examination> toRoomExaminations = _examinationRepository.GetByRoomId(dto.ToRoomId);
            DateTime startDate = dto.StartDate.AddHours(1);
            DateTime endDate = dto.EndDate.AddHours(1);
            List<FreeSpaceDTO> freeSpacesFromRoom = new List<FreeSpaceDTO>();
            List<FreeSpaceDTO> freeSpacesToRoom = new List<FreeSpaceDTO>();
            List<FreeSpaceDTO> filteredFreeSpaces = new List<FreeSpaceDTO>();

            foreach (Examination exam in fromRoomExaminations)
            {
                while (startDate < exam.DateRange.Start)
                {
                    FreeSpaceDTO freeSpace = new FreeSpaceDTO();
                    freeSpace.StartTime = startDate;
                    freeSpace.EndTime = startDate.AddHours(dto.Duration);
                    if (freeSpace.EndTime <= exam.DateRange.Start)
                    {
                        freeSpacesFromRoom.Add(freeSpace);
                    }
                    startDate = startDate.AddHours(0.5);
                }
                startDate = startDate.AddMinutes(exam.DateRange.DurationInMinutes);
            }

            while (startDate < endDate)
            {
                FreeSpaceDTO freeSpace2 = new FreeSpaceDTO();
                freeSpace2.StartTime = startDate;
                freeSpace2.EndTime = startDate.AddHours(dto.Duration);
                freeSpacesFromRoom.Add(freeSpace2);
                startDate = startDate.AddHours(0.5);
            }


            startDate = dto.StartDate.AddHours(1);
            endDate = dto.EndDate.AddHours(1);

            foreach (Examination exam in toRoomExaminations)
            {

                while (startDate < exam.DateRange.Start)
                {
                    FreeSpaceDTO freeSpace = new FreeSpaceDTO();
                    freeSpace.StartTime = startDate;
                    freeSpace.EndTime = startDate.AddHours(dto.Duration);
                    if (freeSpace.EndTime <= exam.DateRange.Start)
                    {
                        freeSpacesToRoom.Add(freeSpace);
                    }
                    startDate = startDate.AddHours(0.5);
                }

                startDate = startDate.AddMinutes(exam.DateRange.DurationInMinutes);

            }

            while (startDate < endDate)
            {
                FreeSpaceDTO freeSpace2 = new FreeSpaceDTO();
                freeSpace2.StartTime = startDate;
                freeSpace2.EndTime = startDate.AddHours(dto.Duration);
                freeSpacesToRoom.Add(freeSpace2);
                startDate = startDate.AddHours(0.5);
            }


            foreach (FreeSpaceDTO freeSpaceFrom in freeSpacesFromRoom)
            {
                foreach (FreeSpaceDTO freeSpaceTo in freeSpacesToRoom)
                {
                    if (freeSpaceFrom.StartTime >= freeSpaceTo.StartTime && freeSpaceFrom.EndTime <= freeSpaceTo.EndTime)
                    {
                        filteredFreeSpaces.Add(freeSpaceFrom);
                    }
                    else if (freeSpaceFrom.StartTime <= freeSpaceTo.StartTime && freeSpaceFrom.EndTime >= freeSpaceTo.EndTime)
                    {
                        filteredFreeSpaces.Add(freeSpaceTo);
                    }
                }
            }

            return filteredFreeSpaces;
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
