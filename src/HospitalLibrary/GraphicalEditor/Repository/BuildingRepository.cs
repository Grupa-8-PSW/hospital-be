using HospitalLibrary.GraphicalEditor.Model;
using HospitalLibrary.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
