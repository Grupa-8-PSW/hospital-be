using HospitalLibrary.GraphicalEditor.Model;
using HospitalLibrary.GraphicalEditor.Repository.Interfaces;
using HospitalLibrary.Settings;

namespace HospitalLibrary.GraphicalEditor.Repository
{
    public class RenovationRepository : IRenovationRepository
    {
        private readonly HospitalDbContext _context;

        public RenovationRepository(HospitalDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Renovation> GetAll()
        {
            return _context.Renovations.ToList();
        }

        public Renovation GetById(int id)
        {
            return _context.Renovations.Find(id);
        }

        public IEnumerable<Renovation> GetByRoomId(int id)
        {
            return _context.Renovations.Where(r => r.RoomId == id);
        }
    }
}
