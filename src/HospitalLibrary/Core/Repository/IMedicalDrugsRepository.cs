using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalLibrary.Core.Model;

namespace HospitalLibrary.Core.Repository
{
    public interface IMedicalDrugRepository
    {
        IEnumerable<MedicalDrugs> GetAll();
        MedicalDrugs GetById(int id);
        void Create(MedicalDrugs medicalDrugs);
        void Update(MedicalDrugs medicalDrugs);
        void Delete(MedicalDrugs medicalDrugs);
        MedicalDrugs GetByCode(string code);
    }
}
