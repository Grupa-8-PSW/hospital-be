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

            return stubRepository.Object;
        }
    }
}