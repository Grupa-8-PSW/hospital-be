using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Enums;
using HospitalLibrary.Core.Repository;
using HospitalLibrary.Core.Service;
using HospitalLibrary.Settings;
using Moq;
using Shouldly;

namespace HospitalTests
{
    public class PatientTests
    {
        [Fact]
        public void Finds_all_patients()
        {
            PatientService service = new PatientService(CreateStubRepository());

            List<Patient> patients = service.GetAll();

            patients.ShouldNotBeEmpty();
            patients.Count().ShouldBe(3);
        }
        [Fact]
        public void Find_patient_by_id()
        {
            PatientService service = new PatientService(CreateStubRepository());

            List<Patient> patients = service.GetAll();
            Patient foundPatient = service.GetById(1);
            foundPatient.ShouldNotBeNull();
        }
        [Fact]
        public void Creates_valid_age_statistic()
        {
            PatientService service = new PatientService(CreateStubRepository());

            AgeStatistic statistic = service.GetAgeStatistic();

            statistic.ShouldNotBeNull();
            statistic.ZeroToEighteen.ShouldBeLessThanOrEqualTo(1);
            statistic.NineteenToSixtyFour.ShouldBeLessThanOrEqualTo(2);
            statistic.SixtyFivePlus.ShouldBeGreaterThanOrEqualTo(0);
        }

        [Fact]
        public void Calculates_age_from_pin()
        {
            PatientService service = new PatientService(CreateStubRepository());

            int ageOfFirstPatient = service.CalculateAgeFromPin(service.GetById(1));

            ageOfFirstPatient.ShouldBeGreaterThanOrEqualTo(22);
        }

        private IPatientRepository CreateStubRepository()
        {
            List<Patient> patients = new List<Patient>();
            Patient p1 = new Patient(1, "Pera", "Peric", "peraperic@gmail.com", "2201000120492", Gender.MALE, BloodType.ZERO_POSITIVE);
            Patient p2 = new Patient(2, "Marko", "Markovic", "markomarkovic@gmail.com", "1412995012451", Gender.MALE, BloodType.AB_NEGATIVE);
            Patient p3 = new Patient(3, "Dusan", "Baljinac", "dusanbaljinac@gmail.com", "2008004124293", Gender.MALE, BloodType.B_NEGATIVE);
            patients.Add(p1);
            patients.Add(p2);
            patients.Add(p3);

            var stubRepository = new Mock<IPatientRepository>();
            stubRepository.Setup(m => m.GetAll()).Returns(patients);
            stubRepository.Setup(m => m.GetById(1)).Returns(patients.SingleOrDefault(p => p.Id == 1));

            return stubRepository.Object;
        }
    }
}