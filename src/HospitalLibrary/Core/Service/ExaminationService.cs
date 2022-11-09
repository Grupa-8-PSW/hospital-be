using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Repository;
using HospitalLibrary.Core.Validation;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

namespace HospitalLibrary.Core.Service
{
    public class ExaminationService : IExaminationService
    {
        private readonly IExaminationRepository _examinationRepository;
        private readonly IValidation _validation;
        private readonly IDoctorRepository _doctorRepository;

        public ExaminationService(IExaminationRepository examinationRepository, IValidation validation, IDoctorRepository doctorRepository)
        {
            _examinationRepository = examinationRepository;
            _validation = validation;
            _doctorRepository = doctorRepository;
        }

        public IEnumerable<Examination> GetAll()
        {
            /*  Room room = new Room(1, "11", 1);
              Patient patient1 = new Patient(1, "Pera", "Peric");
              Patient patient2 = new Patient(1, "Mira", "Miric");
              Patient patient3 = new Patient(1, "Sara", "Peric");
              Doctor doctor = new Doctor(1, "Lara", "Laric", 1, room);
              var examinations = new List<Examination>();
              examinations.Add(new Examination(1, 1, doctor, 1, patient1, 1, room, new DateTime(2022, 11, 17, 7, 30, 00), 20));
              examinations.Add(new Examination(1, 1, doctor, 1, patient2, 1, room, new DateTime(2022, 11, 17, 7, 50, 00), 20));
              examinations.Add(new Examination(1, 1, doctor, 1, patient3, 1, room, new DateTime(2022, 11, 17, 8, 30, 00), 20));
              examinations.Add(new Examination(1, 1, doctor, 1, patient1, 1, room, new DateTime(2022, 11, 18, 7, 30, 00), 20));


              return examinations;*/
            return _examinationRepository.GetAll();
        }

        public Examination GetById(int id)
        {
            return _examinationRepository.GetById(id);
        }

        public bool Create(Examination examination)
        {
            if (!_validation.Validate(examination.DoctorId, examination.StartTime, examination.Duration))
            {
                return false;
            }
            _examinationRepository.Create(examination);
            return true;
        }

        public bool Update(Examination examination)
        {
            if (!_validation.ValidateNotIncludingExaminationId(examination.DoctorId, examination.StartTime, examination.Duration, examination.Id))
            {
                return false;
            }
            Doctor doctor = _doctorRepository.GetById(examination.DoctorId);
            examination.Doctor = doctor;
            _examinationRepository.Update(examination);
            return true;
        }

        public void Delete(Examination examination)
        {
            _examinationRepository.Delete(examination);
        }
        public IEnumerable<Examination> GetByDate(DateTime startTime)
        {
            return _examinationRepository.GetByDate(startTime);
        }
        public IEnumerable<Examination> GetByDoctorIdAndDate(int doctorId, DateTime startTime)
        {
            return _examinationRepository.GetByDoctorIdAndDate(doctorId, startTime);
        }


    }
}