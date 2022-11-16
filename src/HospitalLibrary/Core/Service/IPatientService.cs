using HospitalLibrary.Core.Model;

namespace HospitalLibrary.Core.Service
{
    public interface IPatientService
    {
        public List<Patient> GetAll();
        public Patient GetById(int id);
        public Patient Create(Patient patient);
        public void Update(Patient patient);
        public void Delete(int id);
        public AgeStatistic GetAgeStatistic();
    }
}
