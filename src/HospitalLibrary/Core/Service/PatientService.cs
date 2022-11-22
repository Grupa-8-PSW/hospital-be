using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Repository;

namespace HospitalLibrary.Core.Service
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

        public Statistic GetStatistic()
        {
            List<Patient> patients = GetAll();
            return new Statistic(GetAgeStatistic(patients), GetGenderStatistic(patients), GetBloodTypeStatistic(patients));
        }

        public AgeStatistic GetAgeStatistic(List<Patient> patients)
        {
            AgeStatistic statistic = new AgeStatistic();

            foreach(Patient p in patients)
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

            if(Int32.Parse(birthYear) > Int32.Parse(dateNow.Year.ToString().Substring(1, 3)))
            {
                fullBirthYear = "1" + birthYear;
            } else
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
    }
}
