using HospitalLibrary.GraphicalEditor.Model.Map;
using HospitalLibrary.GraphicalEditor.Repository.Map.Interfaces;
using HospitalLibrary.Settings;

namespace HospitalLibrary.GraphicalEditor.Repository
{
    public class MapFloorRepository : IMapFloorRepository
    {
        private readonly HospitalDbContext _context;

        public MapFloorRepository(HospitalDbContext context)
        {
            _context = context;
        }

        public IEnumerable<MapFloor> GetAll()
        {
            return _context.MapFloors.ToList();
        }

        public MapFloor GetById(int id)
        {
            return _context.MapFloors.Find(id);
        }
    }
}
