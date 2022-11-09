using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Repository
{
    public class TherapyRepository : ITherapyRepository
    {
        private readonly HospitalDbContext _context;

        public ExaminationRepository(HospitalDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Therapy> GetAll()
        {
            return _context.Therapies.ToList();
        }

        public Examination GetById(int id)
        {
            return _context.Therapies.Find(id);
        }

        public void Create(Examination examination)
        {
            _context.Therapies.Add(examination);
            _context.SaveChanges();
        }

        public void Update(Examination examination)
        {
            Examination examinationOld = _context.Therapies.Find(examination.Id);
            _context.Entry(examinationOld).CurrentValues.SetValues(examination);
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

        public void Delete(Examination examination)
        {
            _context.Examinations.Remove(examination);
            _context.SaveChanges();
        }

       
    }
}
