using HospitalLibrary.GraphicalEditor.Model.Map;
using HospitalLibrary.GraphicalEditor.Repository.Map.Interfaces;
using HospitalLibrary.Settings;

namespace HospitalLibrary.GraphicalEditor.Repository
{
    public class MapBuildingRepository : IMapBuildingRepository
    {
        private readonly HospitalDbContext _context;

        public MapBuildingRepository(HospitalDbContext context)
        {
            _context = context;
        }

        public IEnumerable<MapBuilding> GetAll()
        {
            return _context.MapBuildings.ToList();
        }

        public MapBuilding GetById(int id)
        {
            return _context.MapBuildings.Find(id);
        }
    }
}
