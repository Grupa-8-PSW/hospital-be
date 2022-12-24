using HospitalLibrary.Core.Enums;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Repository;
using HospitalLibrary.Core.Service;
using HospitalLibrary.GraphicalEditor.Model;
using HospitalLibrary.GraphicalEditor.Repository.Interfaces;
using HospitalLibrary.GraphicalEditor.Service;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalTests.HospitalLibraryTests
{
    public class TherapyTests
    {
        [Fact]
        public void Create_therapy()
        {
            TherapyService therapyService = null;// new TherapyService(CreateTherapyStubRepository());

            Therapy therapy = new Therapy();

            var succes = therapyService.Create(therapy);

            var allTherapies = therapyService.GetAll();

            Assert.True(succes);
            Assert.True(allTherapies.Count() == 2);
        }

        /*
        private static ITherapyRepository CreateTherapyStubRepository()
        {
            var stubRepository = new Mock<ITherapyRepository>();

            List<Therapy> allTherapies = new List<Therapy>();

            Doctor doctor1 = new Doctor() { Id = 1, FirstName = "firstName", LastName = "lastName", RoomId = 0, Room = null, StartWork = new DateTime(), EndWork = new DateTime() };
            BloodUnit unit = new BloodUnit() { Id = 1, BloodType = BloodType.A_NEGATIVE, Amount = 200 };


            allTherapies.Add(new Therapy() { Id = 1, WhenPrescribed = new DateTime(), Amount = 50, Reason = "reason1",  DoctorId = 1, Doctor = doctor1 });


            stubRepository.Setup(r => r.GetAll()).Returns(allTherapies);

            return stubRepository.Object;


        }*/



       
    }
}
