using HospitalLibrary.Core.Enums;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Repository;
using HospitalLibrary.Core.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HospitalLibrary.Core.Service
{
    public class TherapyService : ITherapyService
    {
        private readonly ITherapyRepository _therapyRepository;
        private readonly IBloodRepository _bloodRepository;
        private readonly IMedicalDrugsRepository _medicalDrugRepository;
        private readonly ITherapyValidation _therapyValidation;
        private readonly IBloodUnitRepository _bloodUnitRepository;

        public TherapyService(ITherapyRepository therapyRepository, IBloodRepository bloodRepository,
            IMedicalDrugsRepository medicalDrugRepository, ITherapyValidation therapyValidation, IBloodUnitRepository bloodUnitRepository)
        {
            _therapyRepository = therapyRepository;
            _bloodRepository = bloodRepository;
            _medicalDrugRepository = medicalDrugRepository;
            _therapyValidation = therapyValidation;
            _bloodUnitRepository = bloodUnitRepository;
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
            therapy.WhenPrescribed = DateTime.Now.ToUniversalTime();
            therapy.DoctorId = 1;

            string therapySubject = therapy.TherapySubject;
            int amount = therapy.Amount;

            if (therapy.TherapyType == TherapyType.BLOOD_THERAPY)
            {
                if (!_therapyValidation.ValidateBlood(therapySubject, amount))
                {
                    return false;
                }
                BloodType bloodType;
                if (!Enum.TryParse<BloodType>(therapySubject, out bloodType))
                {
                    return false;
                }
                Blood blood = _bloodRepository.GetByBloodType(bloodType);
                blood.Quantity -= amount;
                _bloodRepository.Update(blood);

                //dodati bloodUnit u 
                BloodUnit bloodUnit = new BloodUnit(0, therapy.WhenPrescribed, bloodType, amount);
                _bloodUnitRepository.Create(bloodUnit);
            }
            else
            {
                if (!_therapyValidation.ValidateMedicalDrug(therapySubject, amount))
                {
                    return false;
                }
                MedicalDrugs medicalDrugs = _medicalDrugRepository.GetByCode(therapySubject);
                medicalDrugs.Amount -= amount;
                _medicalDrugRepository.Update(medicalDrugs);
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
