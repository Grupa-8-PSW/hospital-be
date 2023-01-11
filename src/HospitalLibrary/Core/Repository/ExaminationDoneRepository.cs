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
    public class ExaminationDoneRepository : IExaminationDoneRepository
    {
        private readonly HospitalDbContext _context;

        public ExaminationDoneRepository(HospitalDbContext context)
        {
            _context = context;
        }

        public IEnumerable<ExaminationDone> GetAll()
        {
            return _context.ExaminationsDone.ToList();
        }

        public IEnumerable<ExaminationDone> GetAllFinished()
        {
            return _context.ExaminationsDone.Include(x => x.Examination)
                                            .ThenInclude(x => x.Doctor)
                                            .Include(x => x.Examination)
                                            .ThenInclude(x => x.Patient)
                                            .Include(x => x.Symptoms)
                                            .Include(x => x.Examination)
                                            .ThenInclude(x => x.Room)
                                            .Include(x => x.Prescriptions)
                                            .ToList();
        }

        public ExaminationDone GetById(int id)
        {
            return _context.ExaminationsDone.Find(id);
        }

        public void Create(ExaminationDone examinationDone)
        {
            _context.ExaminationsDone.Add(examinationDone);
            _context.SaveChanges();
        }

        public void Update(ExaminationDone examinationDone)
        {
            ExaminationDone examinationDoneOld = _context.ExaminationsDone.Find(examinationDone.Id);
            _context.Entry(examinationDoneOld).CurrentValues.SetValues(examinationDone);
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

        public void Delete(ExaminationDone examinationDone)
        {
            _context.ExaminationsDone.Remove(examinationDone);
            _context.SaveChanges();
        }

        public IEnumerable<Symptom> GetAllSymptoms()
        {
            return _context.Symptoms.ToList();
        }

        public ExaminationDone? GetByExamination(int examinationId)
        {
            return _context.ExaminationsDone
                .Include(x => x.Prescriptions)
                .ThenInclude(p => p.PrescriptionItem)
                .ThenInclude(pi => pi.MedicalDrug)
                .Include(x => x.Symptoms)
                .SingleOrDefault(x => x.ExaminationId == examinationId);
        }
    }
}
