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
        public void Creates_valid_age_statistic()
        {
            PatientService service = new PatientService(CreateStubRepository());

            AgeStatistic statistic = service.GetAgeStatistic(service.GetAll());

            statistic.ShouldNotBeNull();
            statistic.ZeroToEighteen.ShouldBeLessThanOrEqualTo(1);
            statistic.NineteenToSixtyFour.ShouldBeLessThanOrEqualTo(2);
            statistic.SixtyFivePlus.ShouldBeGreaterThanOrEqualTo(0);
        }

        [Fact]
        public void Creates_valid_gender_statistic()
        {
            PatientService service = new PatientService(CreateStubRepository());

            GenderStatistic statistic = service.GetGenderStatistic(service.GetAll());

            statistic.ShouldNotBeNull();
            statistic.Male.ShouldBe(3);
            statistic.Female.ShouldBe(0);
        }

        [Fact]
        public void Creates_valid_blood_type_statistic()
        {
            PatientService service = new PatientService(CreateStubRepository());

            BloodTypeStatistic statistic = service.GetBloodTypeStatistic(service.GetAll());

            statistic.ShouldNotBeNull();
            statistic.ZeroPositive.ShouldBe(1);
            statistic.BNegative.ShouldBe(2);
            statistic.APositive.ShouldBe(0);
        }

        [Fact]
        public void Calculates_age_from_pin()
        {
            PatientService service = new PatientService(CreateStubRepository());

            int ageOfFirstPatient = service.CalculateAgeFromPin(service.GetById(1));

            ageOfFirstPatient.ShouldBeGreaterThanOrEqualTo(22);
        }
        public void Create_patient_and_add_allergens()
        {
            var service = new PatientService(CreateStubRepository());

            var patient = service.CreateAndAddAllergens(new Patient(), new List<Allergen>());

            patient.ShouldNotBeNull();
            patient.Allergens.Count.ShouldBe(1);
        }

        private IPatientRepository CreateStubRepository()
        {
            List<Patient> patients = new List<Patient>();
            
            Patient p1 = new Patient(1, "Pera", "Peric", "peraperic@gmail.com", "2201000120492", Gender.MALE, BloodType.ZERO_POSITIVE, 1, 1);
            Patient p2 = new Patient(2, "Marko", "Markovic", "markomarkovic@gmail.com", "1412995012451", Gender.MALE, BloodType.B_NEGATIVE, 2, 1);
            Patient p3 = new Patient(3, "Dusan", "Baljinac", "dusanbaljinac@gmail.com", "2008004124293", Gender.MALE, BloodType.B_NEGATIVE, 3, 2);
            Patient p4 = new Patient(4, "Pera", "Peric", "peraperic@gmail.com", "2201000120492", Gender.MALE, BloodType.ZERO_POSITIVE, 1, 2);

            patients.Add(p1);
            patients.Add(p2);
            patients.Add(p3);

            p4.Allergens = new List<Allergen>
            {
                new Allergen
                {
                    Name = "Penicilin"
                }
            };

            var stubRepository = new Mock<IPatientRepository>();
            stubRepository.Setup(m => m.GetAll()).Returns(patients);
            stubRepository.Setup(m => m.GetById(1)).Returns(patients.SingleOrDefault(p => p.Id == 1));
            stubRepository.Setup(m => m.Create(It.IsAny<Patient>())).Returns(p4);

            return stubRepository.Object;
        }
    }
}