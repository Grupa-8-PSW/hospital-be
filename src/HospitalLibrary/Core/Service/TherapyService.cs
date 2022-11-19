using HospitalLibrary.Core.Enums;
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
    public class TherapyService : ITherapyService
    {
        private readonly ITherapyRepository _therapyRepository;
        private readonly IBloodUnitRepository _bloodUnitRepository;
        private readonly IMedicalDrugRepository _medicalDrugRepository;
        private readonly ITherapyValidation _therapyValidation;

        public TherapyService(ITherapyRepository therapyRepository, IBloodUnitRepository bloodUnitRepository, 
            IMedicalDrugRepository medicalDrugRepository, ITherapyValidation therapyValidation)
        {
            _therapyRepository = therapyRepository;
            _bloodUnitRepository = bloodUnitRepository;
            _medicalDrugRepository = medicalDrugRepository;
            _therapyValidation = therapyValidation;
        }

        public IEnumerable<Therapy> GetAll()
        {
            return _therapyRepository.GetAll();
        }

        public Therapy GetById(int id)
        {
            return _therapyRepository.GetById(id);
        }

        public bool Create(Therapy therapy)
        {
            therapy.WhenPrescribed = DateTime.Now;
            therapy.DoctorId = 1;

            string therapySubject = therapy.TherapySubject;
            int amount = therapy.Amount;
            if(therapy.TherapyType == TherapyType.BLOOD_THERAPY)
            {
                if (!_therapyValidation.ValidateBlood(therapySubject, amount))
                {
                    return false;
                }
            }
            else
            {
                if (!_therapyValidation.ValidateMedicalDrug(therapySubject, amount))
                {
                    return false;
                }
            }


            
            _therapyRepository.Create(therapy);
            return true;
        }

        public bool Update(Therapy therapy)
        {
            _therapyRepository.Update(therapy);
            return true;
        }

    }
}
