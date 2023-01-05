using HospitalLibrary.GraphicalEditor.Model;
using HospitalLibrary.GraphicalEditor.Repository.Interfaces;
using HospitalLibrary.GraphicalEditor.Service.Interfaces;

namespace HospitalLibrary.GraphicalEditor.Service
{
    public class EquipmentTransferService : IEquipmentTransferService
    {
        private readonly IEquipmentTransferRepository _equipmentTransferRepository;

        public EquipmentTransferService(IEquipmentTransferRepository equipmentTransferRepository)
        {
            _equipmentTransferRepository = equipmentTransferRepository;
        }

        public IEnumerable<EquipmentTransfer> GetAll()
        {
            return _equipmentTransferRepository.GetAll();
        }

        public EquipmentTransfer GetById(int id)
        {
            return _equipmentTransferRepository.GetById(id);
        }
    }
}
