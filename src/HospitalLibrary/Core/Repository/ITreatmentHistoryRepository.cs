using HospitalLibrary.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Repository
{
    public interface ITreatmentHistoryRepository
    {
        public IEnumerable<TreatmentHistory> GetAll();
        public TreatmentHistory GetById(int id);
        public void Create(TreatmentHistory doctor);
        public void Update(TreatmentHistory doctor);
        public void Delete(TreatmentHistory doctor);
    }
}
