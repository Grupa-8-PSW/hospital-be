using HospitalLibrary.GraphicalEditor.Model;

namespace HospitalLibrary.GraphicalEditor.Repository.Interfaces
{
    public interface IEquipmentTransferRepository
    {
        IEnumerable<EquipmentTransfer> GetAll();
        EquipmentTransfer GetById(int id);
    }
}
