using HospitalLibrary.GraphicalEditor.Model;
using HospitalLibrary.GraphicalEditor.Repository.Interfaces;
using HospitalLibrary.Settings;

namespace HospitalLibrary.GraphicalEditor.Repository
{
    public class FloorRepository : IFloorRepository
    {
        private readonly HospitalDbContext _context;

        public FloorRepository(HospitalDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Floor> GetAll()
        {
            return _context.Floors.ToList();
        }

        public Floor GetById(int id)
        {
            return _context.Floors.Find(id);
        }

        public IEnumerable<Floor> GetFloorsByBuildingId(int id)
        {
            return _context.Floors.Where(f => f.BuildingId == id);
        }


    }
}
