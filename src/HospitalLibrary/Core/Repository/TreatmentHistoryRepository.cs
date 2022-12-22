using HospitalLibrary.Core.Model;
using HospitalLibrary.GraphicalEditor.Model;
using HospitalLibrary.Settings;
using Microsoft.EntityFrameworkCore;
using RestSharp.Serializers.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Repository
{
    public class TreatmentHistoryRepository : ITreatmentHistoryRepository
    {
        private readonly HospitalDbContext _context;

        public TreatmentHistoryRepository(HospitalDbContext context)
        {
            _context = context;
        }


        public IEnumerable<TreatmentHistory> GetAll()
        {
            return _context.TreatmentHistories.Include(th => th.Patient).ToList();
        }

        public TreatmentHistory GetById(int id)
        {
            return _context.TreatmentHistories.Include(th => th.Patient).Include(th => th.Bed).Where(th => th.Id == id).FirstOrDefault<TreatmentHistory>();
        }                                               //i bed

        public void Create(TreatmentHistory treatmentHistory)
        {
            _context.TreatmentHistories.Add(treatmentHistory);
            _context.SaveChanges();
        }

        public void Update(TreatmentHistory treatmentHistory)
        {
            TreatmentHistory treatmentHistoryOld = _context.TreatmentHistories.Find(treatmentHistory.Id);
            _context.Entry(treatmentHistoryOld).CurrentValues.SetValues(treatmentHistory);
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

        public void Delete(TreatmentHistory treatmentHistory)
        {
            _context.TreatmentHistories.Remove(treatmentHistory);
            _context.SaveChanges();
        }

        public TreatmentHistory GetByIdEager(int id)
        {
            return _context.TreatmentHistories
                .Include(th => th.Patient)
                .Include(th => th.Bed)
                .Include(th => th.Therapies)
                .First((th) => th.Id == id);
        }

        public IEnumerable<TreatmentHistory> GetAllActive()
        {
            return _context.TreatmentHistories.Include(th => th.Active == true).ToList();
        }

        public IEnumerable<Patient> GetPatientsWithoutActiveTreatmentHistory()
        {
            return _context.Patients.Except(from th in _context.TreatmentHistories
                     where th.Active == true
                     select th.Patient).ToList();
        }
    }
}
