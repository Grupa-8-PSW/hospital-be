using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalLibrary.GraphicalEditor.Model;
using HospitalLibrary.GraphicalEditor.Repository.Interfaces;
using HospitalLibrary.Settings;

namespace HospitalLibrary.GraphicalEditor.Repository
{
    public class FormRepository : IFormRepository
    {
        private readonly HospitalDbContext _context;

        public FormRepository(HospitalDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Form> GetAll()
        {
            return _context.Forms.ToList();
        }

        public IEnumerable<Form> GetInformationsOfRooms(int id)
        {
            return _context.Forms.Where(f => f.RoomId == id);
        }
    }
}
