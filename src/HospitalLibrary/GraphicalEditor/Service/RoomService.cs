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

        public IEnumerable<Examination> GetTransferedEquipment(EquipmentTransferDTO dto)
        {
           
            return null;
        }
    }
}
