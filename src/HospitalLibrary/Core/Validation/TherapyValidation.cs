using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalLibrary.Core.Enums;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Repository;

namespace HospitalLibrary.Core.Validation
{
    public class TherapyValidation : ITherapyValidation
    {
        private readonly IBloodUnitRepository _bloodUnitRepository;
        private readonly IMedicalDrugRepository _medicalDrugRepository;

        public TherapyValidation(IBloodUnitRepository bloodUnitRepository, IMedicalDrugRepository medicalDrugRepository)
        {
            _bloodUnitRepository = bloodUnitRepository;
            _medicalDrugRepository = medicalDrugRepository;
        }

        public bool ValidateBlood(string bloodType, int amount)
        {
            throw new NotImplementedException();
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
