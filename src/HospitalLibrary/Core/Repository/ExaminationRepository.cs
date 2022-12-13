﻿using HospitalLibrary.Core.Model;
using HospitalLibrary.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HospitalLibrary.Core.Enums;

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
        public IEnumerable<Examination> GetCancelled()
        {
            return _context.Examinations.Where(ex => ex.Status == (ExaminationStatus.CANCELLED));
        }
        public void Delete(Examination examination)
        {
            _context.Examinations.Remove(examination);
            _context.SaveChanges();
        }

        public IEnumerable<Examination> GetByDate(DateTime startTime)
        {
            return _context.Examinations.Where(ex => ex.StartTime.ToLocalTime().Date == startTime.ToLocalTime().Date).ToList();
        }

        public IEnumerable<Examination> GetByDoctorIdAndDate(int doctorId, DateTime startTime)
        {
            return _context.Examinations.Where(ex => ex.DoctorId == doctorId && ex.StartTime.Date == startTime.Date).ToList();
        }

        public IEnumerable<Examination> GetByPatientId(int patientId)
        {
            return _context.Examinations.Include(ex => ex.Room).Include(ex => ex.Doctor).Where(ex => ex.PatientId == patientId).ToList();
        }
    }
}
