using HospitalLibrary.Core.Enums;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Util;

namespace HospitalLibrary.Core.Service
{
    public interface IExaminationService
    {
        IEnumerable<Examination> GetAll();
        Examination GetById(int id);
        bool Create(Examination examination);
        bool Update(Examination examination);
        void Delete(Examination examination);
        IEnumerable<Examination> GetByDate(DateTime startTime);
        IEnumerable<Examination> GetByDoctorIdAndDate(int doctorId, DateTime startTime);
        IEnumerable<Examination> GetByPatientId(int patientId);
        bool CheckIfCancellable(int id);
    }
}