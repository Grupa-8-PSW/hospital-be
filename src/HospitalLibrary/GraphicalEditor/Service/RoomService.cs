using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Repository;
using HospitalLibrary.GraphicalEditor.Model;
using HospitalLibrary.GraphicalEditor.Model.DTO;
using HospitalLibrary.GraphicalEditor.Repository.Interfaces;
using HospitalLibrary.GraphicalEditor.Service.Interfaces;
using System.Collections.Generic;

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
                retList.Add(new ExaminationDTO(item.Id, item.StartTime, item.Duration));
            }
            
            return retList;
        }

        private List<EquipmentTransferDTO> EntityToEntityEquipListDTO(List<EquipmentTransfer> entities)
        {
            var retList = new List<EquipmentTransferDTO>();
            foreach (var item in entities)
            {
                retList.Add(new EquipmentTransferDTO(item.Id, item.StartDate, item.EndDate, item.FromRoomId,item.ToRoomId));
            }

            return retList;
        }
    }
}
