using HospitalLibrary.Core.Model.ValueObjects;
using HospitalLibrary.GraphicalEditor.Model;
using HospitalLibrary.GraphicalEditor.Repository.Interfaces;
using Moq;
using Shouldly;

namespace HospitalTests.HospitalLibraryTests
{
    public class RoomTests
    {

        [Fact]
        public void Check_availability_type()
        {
            var room = new Room();

            var from = new DateTime(2022, 12, 10, 16, 30, 0, DateTimeKind.Utc);
            var to = new DateTime(2022, 12, 20, 20, 15, 0, DateTimeKind.Utc);
            int duration = 120;

            var interval = room.GetAvailableIntervals(from, to, duration);

            interval.ShouldBeOfType<List<DateRange>>();
        }

        [Fact]
        public void Finds_available_intervals()
        {
            var stubRepository = new Mock<IRoomRepository>();
            //var stubEqipment = new Mock<IExaminationRepository>();

            var rooms = new List<Room>();

            var from1 = new DateTime(2022, 12, 10, 1, 0, 0, DateTimeKind.Utc);
            var to1 = new DateTime(2022, 12, 10, 2, 30, 0, DateTimeKind.Utc);
            var transfer1 = new EquipmentTransfer(1, 20, 1, 2, from1, to1, 90, "test");

            var from2 = new DateTime(2022, 12, 11, 16, 0, 0, DateTimeKind.Utc);
            var to2 = new DateTime(2022, 12, 11, 18, 0, 0, DateTimeKind.Utc);
            var transfer2 = new EquipmentTransfer(1, 20, 1, 2, from1, to1, 120, "test");

            var room1 = new Room();
            room1.Transfers = new List<EquipmentTransfer>();
            room1.Transfers.Add(transfer1);
            room1.Transfers.Add(transfer2);

            rooms.Add(room1);

            stubRepository.Setup(r => r.GetAll()).Returns(rooms);

            //RoomService service = new(stubRepository.Object, stubEqipment.Object);

            List<DateRange> available = room1.GetAvailableIntervals(new DateTime(2022, 12, 11, 4, 0, 0, DateTimeKind.Utc), new DateTime(2022, 12, 12, 4, 0, 0, DateTimeKind.Utc), 90);

            available.ShouldNotBeNull();
        }
    }
}
