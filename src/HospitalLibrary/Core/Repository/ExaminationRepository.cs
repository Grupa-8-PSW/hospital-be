using HospitalLibrary.Core.Model;
using HospitalLibrary.Settings;
using Microsoft.EntityFrameworkCore;
using HospitalLibrary.Core.Model.ValueObjects;

namespace HospitalLibrary.Core.Repository
{
    public class ExaminationRepository : IExaminationRepository
    {
        private readonly HospitalDbContext _context;

        public ExaminationRepository(HospitalDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Examination> GetAll()
        {
            return _context.Examinations.ToList();
        }

        public Examination GetById(int id)
        {
            return _context.Examinations.Find(id);
        }

        public void Create(Examination examination)
        {
            _context.Examinations.Add(examination);
            _context.SaveChanges();
        }

        public void Update(Examination examination)
        {
            Examination examinationOld = _context.Examinations.Find(examination.Id);
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

        public IEnumerable<Examination> GetByDate(DateTime startTime)
        {
            // return _context.Examinations.Where(ex => ex.StartTime.Date == startTime.Date).ToList();
            return null;
        }

        public IEnumerable<Examination> GetByDoctorAndDate(int doctorId, DateTime date)
        {
            return _context.Examinations.Where(ex => ex.DoctorId == doctorId && ex.DateRange.Start.Date == date.Date).ToList();
        }

        public List<DateRange> GetByDoctorAndDateRange(int doctorId, DateRange dateRange)
            => _context.Examinations
            .Where(ex => ex.DoctorId == doctorId && ex.DateRange.Start.Date == dateRange.Start.Date)
            .Select(dr => dr.DateRange)
            .ToList();

        public IEnumerable<Examination> GetByPatientId(int patientId)
        {
            return _context.Examinations.Include(ex => ex.Doctor).Where(ex => ex.PatientId == patientId).ToList();
        }
    }
}
