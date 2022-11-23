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
    public class BloodUnitRepository : IBloodUnitRepository
    {
        private readonly HospitalDbContext _context;

        public BloodUnitRepository(HospitalDbContext context)
        {
            _context = context;
        }

        public IEnumerable<BloodUnit> GetAll()
        {
            return _context.BloodUnits.ToList();
        }

        public BloodUnit GetById(int id)
        {
            return _context.BloodUnits.Find(id);
        }

        public void Create(BloodUnit bloodUnit)
        {
            _context.BloodUnits.Add(bloodUnit);
            _context.SaveChanges();
        }

        public void Update(BloodUnit bloodUnit)
        {
            BloodUnit bloodUnitOld = _context.BloodUnits.Find(bloodUnit.Id);
            _context.Entry(bloodUnitOld).CurrentValues.SetValues(bloodUnit);

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public void Delete(BloodUnit bloodUnit)
        {
            _context.BloodUnits.Remove(bloodUnit);
            _context.SaveChanges();
        }

        
    }
}
