using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalLibrary.GraphicalEditor.Model.Map;
using HospitalLibrary.GraphicalEditor.Repository.Map.Interfaces;
using HospitalLibrary.Settings;

namespace HospitalLibrary.GraphicalEditor.Repository.Map
{
    public class MapFormRepository : IMapFormRepository
    {
        private readonly HospitalDbContext _context;

        public MapFormRepository(HospitalDbContext context)
        {
            _context = context;
        }

        public IEnumerable<MapForm> GetAll()
        {
            return _context.MapForms.ToList();
        }

    }
}
