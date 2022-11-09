using HospitalLibrary.Core.Model;
using HospitalLibrary.Settings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Repository
{
    public class BedRepository : IBedRepository
    {
        private readonly HospitalDbContext _context;

        public BedRepository(HospitalDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Bed> GetAll()
        {
            return _context.Beds.ToList();
        }

        public Bed GetById(int id)
        {
            return _context.Beds.Find(id);
        }

        public void Create(Bed bed)
        {
            _context.Beds.Add(bed);
            _context.SaveChanges();
        }

        public void Update(Bed bed)
        {
            Bed bedOld = _context.Beds.Find(bed.Id);
            _context.Entry(bedOld).CurrentValues.SetValues(bed);
            //_context.Entry(examination).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public void Delete(Bed bed)
        {
            _context.Beds.Remove(bed);
            _context.SaveChanges();
        }

        public IEnumerable<Bed> GetFreeBeds()
        {
            return _context.Beds.Where(b => b.Available == true);
        }
    }
}