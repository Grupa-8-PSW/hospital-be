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
    public class TreatmentHistoryService
    {
        private readonly IExaminationRepository _examinationRepository;
        private readonly IValidation _validation;
        private readonly IDoctorRepository _doctorRepository;

        public TreatmentHistoryService(IExaminationRepository examinationRepository, IValidation validation, IDoctorRepository doctorRepository)
        {
            _examinationRepository = examinationRepository;
            _validation = validation;
            _doctorRepository = doctorRepository;
        }

        public IEnumerable<Examination> GetAll()
        {
            return _examinationRepository.GetAll();
        }

        public Examination GetById(int id)
        {
            return _examinationRepository.GetById(id);
        }

        public bool Create(Examination examination)
        {
           // if (!_validation.Validate(examination.DoctorId, examination.StartTime, examination.Duration))
         //   {
         //       return false;
         //   }
            _examinationRepository.Create(examination);
            return true;
        }

        public bool Update(Examination examination)
        {
     /*       if (!_validation.ValidateNotIncludingExaminationId(examination.DoctorId, examination.StartTime, examination.Duration, examination.Id))
            {
                return false;
            }
            Doctor doctor = _doctorRepository.GetById(examination.DoctorId);
            examination.Doctor = doctor;
     */       _examinationRepository.Update(examination);
            return true;
        }

        public void Delete(Examination examination)
        {
            _examinationRepository.Delete(examination);
        }


    }
}
