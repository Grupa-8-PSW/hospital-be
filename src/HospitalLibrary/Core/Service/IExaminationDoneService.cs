using HospitalLibrary.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Service
{
    public interface IExaminationDoneService
    {
        IEnumerable<ExaminationDone> GetAll();
        ExaminationDone GetById(int id);
        bool Create(ExaminationDone examinationDone);
        bool Update(ExaminationDone examinationDone);
        void Delete(ExaminationDone examinationDone);
        IEnumerable<Symptom> GetAllSymptoms();

    }
}
