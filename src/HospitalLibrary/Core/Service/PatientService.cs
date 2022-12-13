using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Repository;
namespace HospitalLibrary.Core.Service
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IExaminationRepository _examinationRepository;
        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;

        }
        public PatientService(IPatientRepository patientRepository, IExaminationRepository examinationRepository)
        {
            _patientRepository = patientRepository;
            _examinationRepository = examinationRepository;
        }
        public List<Patient> GetAll() => _patientRepository.GetAll();

        public List<Patient> GetBySelectedDoctorId(int id) => _patientRepository.GetBySelectedDoctorId(id).ToList();
        public List<Patient> GetMalicious()
        {
            var cancelledExams = _examinationRepository.GetCancelled();
            var patients = _patientRepository.GetAll();
            var maliciousPatients = new List<Patient>();
            int cancelCount = 0;

            foreach(Patient patient in patients)
            {
                foreach(var exam in cancelledExams)
                {
                    if (exam.PatientId == patient.Id) cancelCount++;
                }
                if (cancelCount >= 3)maliciousPatients.Add(patient);
                cancelCount = 0;
            }

            return maliciousPatients;

        }

        public Patient GetById(int id) => _patientRepository.GetById(id);

        public Patient Create(Patient patient) => _patientRepository.Create(patient);

        public void Update(Patient patient) => _patientRepository.Update(patient);

        public void Delete(int id) => _patientRepository.Delete(id);

        public Patient GetByUserId(int userId) => _patientRepository.GetByUserId(userId);

        public Statistic GetStatistic()
        {
            List<Patient> patients = GetAll();
            return new Statistic(GetAgeStatistic(patients), GetGenderStatistic(patients), GetBloodTypeStatistic(patients));
        }

        public Statistic GetPatientStatisticForSelectedDoctor(int id)
        {
            List<Patient> patients = GetBySelectedDoctorId(id);
            return new Statistic(GetAgeStatistic(patients), GetGenderStatistic(patients), GetBloodTypeStatistic(patients));
        }

        public AgeStatistic GetAgeStatistic(List<Patient> patients)
        {
            AgeStatistic statistic = new AgeStatistic();

            foreach (Patient p in patients)
            {
                int age = CalculateAgeFromPin(p);
                switch (age)
                {
                    case <= 18:
                        statistic.ZeroToEighteen++;
                        break;
                    case (> 18 and < 65):
                        statistic.NineteenToSixtyFour++;
                        break;
                    case >= 65:
                        statistic.SixtyFivePlus++;
                        break;
                }
            }

            return statistic;
        }

        public int CalculateAgeFromPin(Patient p)
        {
            string birthYear = p.Pin.Substring(4, 3);
            string fullBirthYear;
            DateTime dateNow = DateTime.Now;

            if (Int32.Parse(birthYear) > Int32.Parse(dateNow.Year.ToString().Substring(1, 3)))
            {
                fullBirthYear = "1" + birthYear;
            }
            else
            {
                fullBirthYear = "2" + birthYear;
            }

            DateTime birthDate = DateTime.Parse(fullBirthYear + "-" + p.Pin.Substring(2, 2) + "-" + p.Pin.Substring(0, 2));
            return new DateTime(dateNow.Subtract(birthDate).Ticks).Year - 1;
        }

        public GenderStatistic GetGenderStatistic(List<Patient> patients)
        {
            GenderStatistic statistic = new GenderStatistic();

            foreach (Patient p in patients)
            {
                switch (p.Gender)
                {
                    case Enums.Gender.MALE:
                        statistic.Male++;
                        break;
                    case Enums.Gender.FEMALE:
                        statistic.Female++;
                        break;
                }
            }

            return statistic;
        }

        public BloodTypeStatistic GetBloodTypeStatistic(List<Patient> patients)
        {
            BloodTypeStatistic statistic = new BloodTypeStatistic();

            foreach (Patient p in patients)
            {
                switch (p.BloodType)
                {
                    case Enums.BloodType.ZERO_POSITIVE:
                        statistic.ZeroPositive++;
                        break;
                    case Enums.BloodType.ZERO_NEGATIVE:
                        statistic.ZeroNegative++;
                        break;
                    case Enums.BloodType.A_POSITIVE:
                        statistic.APositive++;
                        break;
                    case Enums.BloodType.A_NEGATIVE:
                        statistic.ANegative++;
                        break;
                    case Enums.BloodType.B_POSITIVE:
                        statistic.BPositive++;
                        break;
                    case Enums.BloodType.B_NEGATIVE:
                        statistic.BNegative++;
                        break;
                    case Enums.BloodType.AB_POSITIVE:
                        statistic.ABPositive++;
                        break;
                    case Enums.BloodType.AB_NEGATIVE:
                        statistic.ABNegative++;
                        break;
                }
            }

            return statistic;
        }

        public Patient CreateAndAddAllergens(Patient patient, List<Allergen> allers)
        {
            patient.Allergens = allers;
            return _patientRepository.Create(patient);
        }
    }
}

