using System.Collections.Specialized;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Repository;
using HospitalLibrary.Core.Service;
using HospitalLibrary.GraphicalEditor.Model;
using HospitalLibrary.GraphicalEditor.Model.DTO;
using HospitalLibrary.GraphicalEditor.Repository;
using HospitalLibrary.GraphicalEditor.Repository.Interfaces;
using HospitalLibrary.GraphicalEditor.Service.Interfaces;

namespace HospitalLibrary.GraphicalEditor.Service
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;

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

        public List<FreeSpaceDTO> GetTransferedEquipment(EquipmentTransferDTO dto)
        {
            IEnumerable<Examination> fromRoomExaminations = _examinationRepository.GetByRoomId(dto.FromRoomId);
            IEnumerable<Examination> toRoomExaminations = _examinationRepository.GetByRoomId(dto.ToRoomId);
            DateTime startDate = dto.StartDate;
            DateTime startDateTemp = dto.StartDate;
            DateTime endDate = dto.EndDate;
            List<FreeSpaceDTO> freeSpacesFromRoom = new List<FreeSpaceDTO>();
            FreeSpaceDTO freeSpace = new FreeSpaceDTO();
            List<FreeSpaceDTO> freeSpacesToRoom = new List<FreeSpaceDTO>();
            List<FreeSpaceDTO> filteredFreeSpaces = new List<FreeSpaceDTO>();


            while (startDate < endDate)
            {
                foreach (Examination exam in fromRoomExaminations)
                {
                    DateTime endExaminationTimeForFromRoom = exam.StartTime.AddMinutes(exam.Duration);
                    if (startDateTemp.AddHours(dto.Duration) < exam.StartTime)
                    {
                        freeSpace.StartTime = startDate;
                        freeSpace.EndTime = exam.StartTime;
                        freeSpacesFromRoom.Add(freeSpace);
                    }
                    startDate = endExaminationTimeForFromRoom;
                }
            }

            startDate = dto.StartDate;
            startDateTemp = dto.StartDate;
            endDate = dto.EndDate;

            while (startDate < endDate)
            {
                foreach (Examination exam2 in toRoomExaminations)
                {
                    DateTime endExaminationTimeForToRoom = exam2.StartTime.AddMinutes(exam2.Duration);
                    if (startDateTemp.AddHours(dto.Duration) < exam2.StartTime)
                    {
                        freeSpace.StartTime = startDate;
                        freeSpace.EndTime = exam2.StartTime;
                        freeSpacesToRoom.Add(freeSpace);
                    }
                    startDate = endExaminationTimeForToRoom;
                }
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
    }
}
