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
                    freeSpacesFromRoom.Add(freeSpace);
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
                    freeSpacesToRoom.Add(freeSpace);
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
    }
}
