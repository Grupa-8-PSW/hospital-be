using HospitalLibrary.GraphicalEditor.Model;

namespace HospitalLibrary.GraphicalEditor.Service.Interfaces
{
    public interface IEquipmentTransferService
    {
        IEnumerable<EquipmentTransfer> GetAll();
        EquipmentTransfer GetById(int id);
    }
}
