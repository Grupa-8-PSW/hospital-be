using HospitalLibrary.GraphicalEditor.Model;
using HospitalLibrary.GraphicalEditor.Repository.Interfaces;
using HospitalLibrary.Settings;

namespace HospitalLibrary.GraphicalEditor.Repository
{
    public class BuildingRepository : IBuildingRepository
    {
        private readonly HospitalDbContext _context;

        public BuildingRepository(HospitalDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Building> GetAll()
        {
            return _context.Buildings.ToList();
        }

        public Building GetById(int id)
        {
            return _context.Buildings.Find(id);
        }
    }
}
