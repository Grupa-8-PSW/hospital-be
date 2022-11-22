using HospitalLibrary.Core.Enums;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Repository;
using HospitalLibrary.Core.Service;
using HospitalLibrary.GraphicalEditor.Model;
using HospitalLibrary.GraphicalEditor.Repository.Interfaces;
using HospitalLibrary.GraphicalEditor.Service;
using Microsoft.EntityFrameworkCore;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalTests.HospitalLibraryTests
{
    public class TreatmentHistoryTests
    {
        [Fact]
        public void Finds_free_rooms()
        {
            RoomService roomService = new RoomService(CreateRoomStubRepository());

            var freeRooms = roomService.GetFreeRooms();

            Assert.NotNull(freeRooms);
            Assert.True(freeRooms.Count() == 3);
        }


        /*   [Fact]
           public void Finds_free_bed_in_room()
           {
               RoomService roomService = new RoomService(CreateRoomStubRepository());

               var room = roomService.GetById(1);

               Bed bed = roomService.GetFreeBedInRoom(room);

               Assert.NotNull(bed);
               Assert.True(bed.Available == true);
               Assert.True(bed.RoomId == room.Id);
           }

           [Fact]
           public void Check_if_room_has_available_bed()
           {
               RoomService roomService = new RoomService(CreateRoomStubRepository());
               var room = roomService.GetById(1);

               bool result = roomService.HasAvailableBed(room);

               Assert.True(result);
           }
        */

        [Fact]
        public void Generates_summarizing_report()
        {
            var treatmentHistoryStubRepo = CreateTreatmentHistoryStubRepo();
            string fileName = treatmentHistoryStubRepo.GetById(1).Patient.FirstName
               + treatmentHistoryStubRepo.GetById(1).Patient.LastName
               + "_report.pdf";
            TreatmentHistoryService treatmentHistoryService = new TreatmentHistoryService(
                treatmentHistoryStubRepo,
                null,
                null,
                null);

            treatmentHistoryService.GenerateSummarizingReport(treatmentHistoryStubRepo.GetById(1));
           
            File.Exists(@"C:\\Temp\" + fileName).ShouldBeTrue();
        } 

        private static IRoomRepository CreateRoomStubRepository()
        {
            var stubRepository = new Mock<IRoomRepository>();

            List<Room> allRooms = new List<Room>();

            allRooms.Add(new Room() { Id = 1, X = 0, Y = 0, Width = 260, Height = 160, Color = "blue", Name = "Pedijatrija", FloorId = 1 });
            allRooms.Add(new Room() { Id = 2, X = 0, Y = 0, Width = 260, Height = 160, Color = "blue", Name = "Pedijatrija", FloorId = 1 });
            allRooms.Add(new Room() { Id = 3, X = 0, Y = 0, Width = 260, Height = 160, Color = "blue", Name = "Pedijatrija", FloorId = 1 });
            
            allRooms[0].Beds = new List<Bed>();
            allRooms[1].Beds = new List<Bed>();
            allRooms[2].Beds = new List<Bed>();

            Bed bed1 = new Bed(1, 1, allRooms[0], false);
            Bed bed2 = new Bed(2, 1, allRooms[0], true);
            Bed bed3 = new Bed(3, 2, allRooms[1], true);
            Bed bed4 = new Bed(4, 2, allRooms[1], true);
            Bed bed5 = new Bed(5, 3, allRooms[2], false);
            Bed bed6 = new Bed(6, 3, allRooms[2], false);

            allRooms[0].Beds.Add(bed1);
            allRooms[0].Beds.Add(bed2);
            allRooms[1].Beds.Add(bed3);
            allRooms[1].Beds.Add(bed4);
            allRooms[2].Beds.Add(bed5);
            allRooms[2].Beds.Add(bed6);

            stubRepository.Setup(r => r.GetAll()).Returns(allRooms);
            stubRepository.Setup(r => r.GetFreeRooms()).Returns(allRooms);

            return stubRepository.Object;
        }

        private static ITreatmentHistoryRepository CreateTreatmentHistoryStubRepo()
        {
            var treatmentHistoryStubRepository = new Mock<ITreatmentHistoryRepository>();

            TreatmentHistory th1 = new TreatmentHistory()
            {
                Id = 1,
                Active = false,
                Bed = null,
                Reason = "Headache",
                DischargeReason = "Patient recovered.",
                StartDate = new DateTime(2022, 10, 15),
                EndDate = new DateTime(2022, 11, 17),
                BedId = 1,
                Patient = CreatePatientStubRepo().GetById(1),
                Therapies = CreateTherapyStubRepo().GetAll()
            };

            treatmentHistoryStubRepository.Setup(repo => repo.GetById(1)).Returns(th1);

            return treatmentHistoryStubRepository.Object;
        }

        private static IPatientRepository CreatePatientStubRepo()
        {
            var patientStubRepository = new Mock<IPatientRepository>();
            Patient patient1 = new Patient()
            {
                Id = 1,
                FirstName = "Dragan",
                LastName = "Kovacevic",
            };
            Patient patient2 = new Patient()
            {
                Id = 2,
                FirstName = "Svetlana",
                LastName = "Todorovic",
            };
            List<Patient> patients = new List<Patient>();
            patients.Add(patient1);
            patients.Add(patient2);
            patientStubRepository.Setup(repo => repo.GetAll()).Returns(patients);
            patientStubRepository.Setup(repo => repo.GetById(1)).Returns(patient1);
            patientStubRepository.Setup(repo => repo.GetById(2)).Returns(patient2);

            return patientStubRepository.Object;
        }

        private static ITherapyRepository CreateTherapyStubRepo()
        {
            var therapyStubRepo = new Mock<ITherapyRepository>();

            Therapy t1 = new Therapy()
            {
                Id = 1,
                Amount = 2,
                Prescribed = new MedicalDrugs() { Id = 1, Name = "Bromazepam 500mg", Type = MedicalDrugType.PILL },
                Reason = "Headache",
                WhenPrescribed = new DateTime(2022, 11, 2),
            };

            Therapy t2 = new Therapy()
            {
                Id = 2,
                Amount = 1,
                Prescribed = new BloodUnit() { Id = 1, AmountMl = 500, BloodType = BloodType.A_POSITIVE },
                Reason = "Blood loss",
                WhenPrescribed = new DateTime(2022, 11, 8),
            };
            List<Therapy> therapies = new List<Therapy>();
            therapies.Add(t1);
            therapies.Add(t2);
            therapyStubRepo.Setup(repo => repo.GetAll()).Returns(therapies);
            therapyStubRepo.Setup(repo => repo.GetById(1)).Returns(t1);
            therapyStubRepo.Setup(repo => repo.GetById(2)).Returns(t2);

            return therapyStubRepo.Object;
        }

    }
}
