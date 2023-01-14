using HospitalLibrary.GraphicalEditor.Model;
using HospitalLibrary.GraphicalEditor.Repository.Interfaces;
using HospitalLibrary.Settings;

namespace HospitalLibrary.GraphicalEditor.Repository
{
    public class EquipmentTransferRepository : IEquipmentTransferRepository
    {
        private readonly HospitalDbContext _context;

        public EquipmentTransferRepository(HospitalDbContext context)
        {
            _context = context;
        }

        public IEnumerable<EquipmentTransfer> GetAll()
        {
            return _context.EquipmentTransfers.ToList();
        }

        public EquipmentTransfer GetById(int id)
        {
            return _context.EquipmentTransfers.Find(id);
        }
    }
}
