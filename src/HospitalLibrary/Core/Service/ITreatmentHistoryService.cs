using HospitalLibrary.Core.Model;
using HospitalLibrary.GraphicalEditor.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Service
{
    public interface ITreatmentHistoryService
    {
        public IEnumerable<TreatmentHistory> GetAll();
        public TreatmentHistory GetById(int id);
        public bool Create(TreatmentHistory treatmentHistory);
        public bool Update(TreatmentHistory treatmentHistory);
        public void Delete(TreatmentHistory treatmentHistory);
        public TreatmentHistory GetByIdEager(int id);
        bool FinishTreatmentHistory(TreatmentHistory treatmentHistory);
        public IEnumerable<Patient> GetPatientsWithoutActiveTreatmentHistory();
    }
}