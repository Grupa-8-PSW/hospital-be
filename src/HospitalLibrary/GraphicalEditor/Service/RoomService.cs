using HospitalLibrary.Core.Model;
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
        private readonly IBedRepository _bedRepository;

        private readonly IExaminationRepository _examinationRepository;

        public EquipmentTransferDTO dto;

        public RoomService(IRoomRepository roomRepository, IExaminationRepository examinationRepository)
        {
            _roomRepository = roomRepository;
            _examinationRepository = examinationRepository;
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

        public SeparatedRoomsDTO GetSeparatedRooms(RoomForSeparateDTO dto)
        {
            Room oldRoom = new Room();
            oldRoom = GetById(dto.OldRoomId);

            SeparatedRoomsDTO newRooms = new SeparatedRoomsDTO();
          
            MapRoom firstRoom = new MapRoom(oldRoom.Map.X, oldRoom.Map.Y, (oldRoom.Map.X + oldRoom.Map.Width) / 2, oldRoom.Map.Height, "blue");
            newRooms.FirstRoom = new Room(oldRoom.Id, Core.Enums.RoomType.OTHER, "102", dto.NewRoom1Name, firstRoom, 1, null);
            MapRoom secondRoom = new MapRoom((oldRoom.Map.X + oldRoom.Map.Width) / 2, oldRoom.Map.Y, oldRoom.Map.X + oldRoom.Map.Width,oldRoom.Map.Height, "blue");
            newRooms.SecondRoom = new Room(oldRoom.Id + 100, Core.Enums.RoomType.OPERATIONS, "103", dto.NewRoom2Name, secondRoom, 1, null);

            return newRooms;
        }

        public MergedRoomDTO GetMergedRoom(RoomsForMergeDTO dto)
        {
            Room oldRoom1 = new Room();
            Room oldRoom2 = new Room();

            oldRoom1 = GetById(dto.OldRoom1Id);
            oldRoom2 = GetById(dto.OldRoom2Id);

            MergedRoomDTO newRoom = new MergedRoomDTO();

            MapRoom mergedRoomMap = new MapRoom(oldRoom1.Map.X, oldRoom1.Map.Y, oldRoom1.Map.Width + oldRoom2.Map.Width, (oldRoom1.Map.Height + oldRoom2.Map.Height) / 2, "blue");
            newRoom.Room = new Room(oldRoom1.Id, Core.Enums.RoomType.OTHER, "103", dto.NewRoomName, mergedRoomMap, 1, null);

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
                while (startDate < exam.StartTime)
                {
                    FreeSpaceDTO freeSpace = new FreeSpaceDTO();
                    freeSpace.StartTime = startDate;
                    freeSpace.EndTime = startDate.AddHours(dto.Duration);
                    if (freeSpace.EndTime <= exam.StartTime)
                    {
                        freeSpacesFromRoom.Add(freeSpace);
                    }
                    startDate = startDate.AddHours(0.5);
                }
                startDate = startDate.AddMinutes(exam.Duration);
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

                while (startDate < exam.StartTime)
                {
                    FreeSpaceDTO freeSpace = new FreeSpaceDTO();
                    freeSpace.StartTime = startDate;
                    freeSpace.EndTime = startDate.AddHours(dto.Duration);
                    if (freeSpace.EndTime <= exam.StartTime)
                    {
                        freeSpacesToRoom.Add(freeSpace);
                    }
                    startDate = startDate.AddHours(0.5);
                }

                startDate = startDate.AddMinutes(exam.Duration);

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

    }
}
