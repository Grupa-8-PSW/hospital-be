using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Repository;
using HospitalLibrary.Core.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Service
{
    public class ExaminationDoneService : IExaminationDoneService
    {
        private readonly IExaminationDoneRepository _examinationDoneRepository;
        //private readonly IExaminationValidation _validation;
        //private readonly IDoctorRepository _doctorRepository;

        public ExaminationDoneService(IExaminationDoneRepository examinationDoneRepository)
        {
            _examinationDoneRepository = examinationDoneRepository;

        }

        public IEnumerable<ExaminationDone> GetAll()
        {
            return _examinationDoneRepository.GetAll();
        }

        public ExaminationDone GetById(int id)
        {
            return _examinationDoneRepository.GetById(id);
        }

        public bool Create(ExaminationDone examinationDone)
        {
            /*if (!_validation.Validate(examination.DoctorId, examination.StartTime, examination.Duration))
            {
                return false;
            }*/
            _examinationDoneRepository.Create(examinationDone);
            return true;
        }

        public bool Update(ExaminationDone examinationDone)
        {
            /*if (!_validation.ValidateNotIncludingExaminationId(examination.DoctorId, examination.StartTime, examination.Duration, examination.Id))
            {
                return false;
            }
            Doctor doctor = _doctorRepository.GetById(examination.DoctorId);
            examination.Doctor = doctor;*/
            _examinationDoneRepository.Update(examinationDone);
            return true;
        }

        public void Delete(ExaminationDone examinationDone)
        {
            _examinationDoneRepository.Delete(examinationDone);
        }

        public IEnumerable<Symptom> GetAllSymptoms()
        {
            return _examinationDoneRepository.GetAllSymptoms();
        }

        public ExaminationDone? GetByExamination(int examinationId)
        {
            return _examinationDoneRepository.GetByExamination(examinationId);
        }
    }
}
