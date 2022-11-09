using HospitalLibrary.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalLibrary.Settings;
using Microsoft.EntityFrameworkCore;

namespace HospitalLibrary.Core.Repository
{
    public class TherapyRepository : ITherapyRepository
    {
        private readonly HospitalDbContext _context;

        public TherapyRepository(HospitalDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Therapy> GetAll()
        {
            return _context.Therapies.ToList();
        }

        public Therapy GetById(int id)
        {
            return _context.Therapies.Find(id);
        }

        public void Create(Therapy therapy)
        {
            _context.Therapies.Add(therapy);
            _context.SaveChanges();
        }

        public void Update(Therapy therapy)
        {
            Therapy therapyOld = _context.Therapies.Find(therapy.Id);
            _context.Entry(therapyOld).CurrentValues.SetValues(therapy);
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

        public void Delete(Therapy therapy)
        {
            _context.Therapies.Remove(therapy);
            _context.SaveChanges();
        }

       
    }
}
