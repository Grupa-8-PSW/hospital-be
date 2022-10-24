
namespace HospitalLibrary.Patient
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;

        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public List<Patient> GetAll() => _patientRepository.GetAll();

        public Patient GetById(int id) => _patientRepository.GetById(id);

        public Patient Create(Patient patient) => _patientRepository.Create(patient);

        public void Update(Patient patient) => _patientRepository.Update(patient);

        public void Delete(int id) => _patientRepository.Delete(id);

    }
}
