using HospitalLibrary.GraphicalEditor.Model;
using HospitalLibrary.GraphicalEditor.Model.DTO;
using HospitalLibrary.GraphicalEditor.Repository.Interfaces;
using HospitalLibrary.Settings;

namespace HospitalLibrary.GraphicalEditor.Repository
{
    public class RoomRepository : IRoomRepository
    {
        private readonly HospitalDbContext _context;

        public RoomRepository(HospitalDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Room> GetAll()
        {
            return _context.Rooms.ToList();
        }

        public Room GetById(int id)
        {
            return _context.Rooms.Find(id);
        }

        public IEnumerable<Room> GetRoomsByFloorId(int id)
        {
            return _context.Rooms.Where(f => f.FloorId == id);
        }

        public IEnumerable<Room> GetTransferedEquipment(EquipmentTransferDTO dto)
        {
            return _context.Rooms.ToList();
        }

    }
}
