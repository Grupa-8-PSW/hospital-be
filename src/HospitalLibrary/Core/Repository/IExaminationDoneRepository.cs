using HospitalLibrary.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Repository
{
    public interface IExaminationDoneRepository
    {
        IEnumerable<ExaminationDone> GetAll();
        ExaminationDone GetById(int id);
        void Create(ExaminationDone examinationDone);
        void Update(ExaminationDone examinationDone);
        void Delete(ExaminationDone examinationDone);
        IEnumerable<Symptom> GetAllSymptoms();
    }
}
