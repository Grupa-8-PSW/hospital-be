using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using HospitalLibrary.Core.Enums;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Repository;

namespace HospitalLibrary.Core.Validation
{
    public class TherapyValidation : ITherapyValidation
    {
        private readonly IBloodRepository _bloodRepository;
        private readonly IMedicalDrugRepository _medicalDrugRepository;

        public TherapyValidation(IBloodRepository bloodRepository, IMedicalDrugRepository medicalDrugRepository)
        {
            _bloodRepository = bloodRepository;
            _medicalDrugRepository = medicalDrugRepository;
        }

        public bool ValidateBlood(string bloodTypeName, int amount)
        {
            BloodType bloodType;
            if(!Enum.TryParse<BloodType>(bloodTypeName, out bloodType))
            {
                return false;
            }
            Blood blood = _bloodRepository.GetByBloodType(bloodType);
            if(blood == null)
            {
                return false;
            }
            if (amount > blood.Quantity)
            {
                return false;
            }
            return true;
        }

        public bool ValidateMedicalDrug(string name, int amount)
        {
            MedicalDrugs medicalDrugs = _medicalDrugRepository.GetByCode(name);
            if(medicalDrugs == null)
            {
                return false;
            }
            if(amount > medicalDrugs.Amount)
            {
                return false;
            }
            return true;
        }
    }
}
