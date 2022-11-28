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
    public class MedicalDrugsRepository : IMedicalDrugsRepository
    {
        private readonly HospitalDbContext _context;

        public MedicalDrugsRepository(HospitalDbContext context)
        {
            _context = context;
        }

        public IEnumerable<MedicalDrugs> GetAll()
        {
            return _context.MedicalDrugs.ToList();
        }

        public MedicalDrugs GetById(int id)
        {
            return _context.MedicalDrugs.Find(id);
        }

        public void Create(MedicalDrugs medicalDrugs)
        {
            _context.MedicalDrugs.Add(medicalDrugs);
            _context.SaveChanges();
        }


        public void Update(MedicalDrugs medicalDrugs)
        {
            MedicalDrugs medicalDrugsOld = _context.MedicalDrugs.Find(medicalDrugs.Id);
            _context.Entry(medicalDrugsOld).CurrentValues.SetValues(medicalDrugs);

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public void Delete(MedicalDrugs medicalDrugs)
        {
            _context.MedicalDrugs.Remove(medicalDrugs);
            _context.SaveChanges();
        }

        public MedicalDrugs GetByCode(string code)
        {

            MedicalDrugs medicalDrugs = _context.MedicalDrugs.SingleOrDefault(m => m.Code == code);
            return medicalDrugs;
        }
    }
}
