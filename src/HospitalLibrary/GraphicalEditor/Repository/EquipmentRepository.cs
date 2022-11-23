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
    public class EquipmentRepository : IEquipmentRepository
    {
        private readonly HospitalDbContext _context;

        public EquipmentRepository(HospitalDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Equipment> GetAll()
        {
            return _context.Equipments.ToList();
        }

        public IEnumerable<Equipment> GetEquipmentByRoomId(int id)
        {
            return _context.Equipments.Where(f => f.RoomId == id);
        }

        public IEnumerable<Equipment> Search(string name, int? amount)
        {
            IQueryable<Equipment> query = _context.Equipments;

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(r => r.Name.ToLower().Contains(name.Trim().ToLower()));
            }

            if (amount != null)
            {
                query = query.Where(r => r.Amount >= amount);
            }

            return query.ToList();
        }

    }
}
