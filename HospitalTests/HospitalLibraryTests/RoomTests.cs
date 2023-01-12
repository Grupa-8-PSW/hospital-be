using HospitalLibrary.Core.Enums;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Model.ValueObjects;
using HospitalLibrary.Core.Repository;
using HospitalLibrary.GraphicalEditor.Model;
using HospitalLibrary.GraphicalEditor.Model.Map;
using HospitalLibrary.GraphicalEditor.Repository.Interfaces;
using HospitalLibrary.GraphicalEditor.Service;
using Moq;
using Shouldly;

namespace HospitalTests.HospitalLibraryTests
{
    public class RoomTests
    {

        [Fact]
        public void Finds_available_intervals()
        {
            var stubRoom = new Mock<IRoomRepository>();
            var stubExamination = new Mock<IExaminationRepository>();
            var stubEquipmant = new Mock<IEquipmentRepository>();
            var stubRenovation = new Mock<IRenovationRepository>();

            var rooms = new List<Room>();
            var examinations = new List<Examination>();

            var room1 = new Room(1, RoomType.OPERATIONS, "101", "Neurohirurgija", new MapRoom(), 1, new Floor());
            var room2 = new Room(2, RoomType.CAFETERIA, "102", "Kafeterija", new MapRoom(), 1, new Floor());
            rooms.Add(room1);
            rooms.Add(room2);

            var from1 = new DateTime(2022, 12, 10, 1, 0, 0, DateTimeKind.Utc);
            var to1 = new DateTime(2022, 12, 10, 2, 30, 0, DateTimeKind.Utc);
            var transfer1 = new EquipmentTransfer(1, 20, 1, 2, from1, to1, 90, "test");

            var from2 = new DateTime(2022, 12, 11, 16, 0, 0, DateTimeKind.Utc);
            var to2 = new DateTime(2022, 12, 11, 18, 0, 0, DateTimeKind.Utc);
            var transfer2 = new EquipmentTransfer(1, 20, 1, 2, from1, to1, 120, "test");

            stubRoom.Setup(r => r.GetAll()).Returns(rooms);
            stubExamination.Setup(e => e.GetAll()).Returns(examinations);

            RoomService service = new RoomService(stubRoom.Object, stubExamination.Object, stubEquipmant.Object, stubRenovation.Object);
            List<DateRange> available = service.GetAvailableIntervals(1, 2, new DateTime(2022, 12, 11, 4, 0, 0, DateTimeKind.Utc), new DateTime(2022, 12, 12, 4, 0, 0, DateTimeKind.Utc), 90);

            available.ShouldNotBeNull();
        }
        
    }
}
