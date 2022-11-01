using HospitalLibrary.GraphicalEditor.Model.Map;
using HospitalLibrary.GraphicalEditor.Repository.Map.Interfaces;
using HospitalLibrary.Settings;

namespace HospitalLibrary.GraphicalEditor.Repository
{
    public class MapRoomRepository : IMapRoomRepository
    {
        private readonly HospitalDbContext _context;

        public MapRoomRepository(HospitalDbContext context)
        {
            _context = context;
        }

        public IEnumerable<MapRoom> GetAll()
        {
            return _context.MapRooms.ToList();
        }

        public MapRoom GetById(int id)
        {
            return _context.MapRooms.Find(id);
        }
    }
}
