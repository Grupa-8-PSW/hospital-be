
namespace HospitalLibrary.Patient
{
    public interface IPatientService
    {
        public List<Patient> GetAll();
        public Patient GetById(int id);
        public Patient Create(Patient patient);
        public void Update(Patient patient);
        public void Delete(int id);
    }
}
