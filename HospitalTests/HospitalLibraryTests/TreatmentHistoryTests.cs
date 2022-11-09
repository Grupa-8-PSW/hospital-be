using HospitalLibrary.Core.Enums;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Repository;
using HospitalLibrary.Core.Service;
using HospitalLibrary.GraphicalEditor.Model;
using HospitalLibrary.GraphicalEditor.Repository.Interfaces;
using HospitalLibrary.GraphicalEditor.Service;
using Microsoft.EntityFrameworkCore;
using Moq;
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
            Assert.NotEmpty(freeRooms);
        }



        [Fact]
        public void Finds_free_bed_in_room()
        {
            RoomService roomService = new RoomService(CreateRoomStubRepository());

            var room = roomService.GetById(1);

            Bed bed = roomService.GetFreeBedInRoom(room);

            Assert.NotNull(bed);
            Assert.True(bed.Available == true);
            Assert.True(bed.RoomId == room.Id);
        }


        private static IRoomRepository CreateRoomStubRepository()
        {
            var stubRepository = new Mock<IRoomRepository>();

            List<Room> allRooms = new List<Room>();

            allRooms.Add(new Room() { Id = 1, X = 0, Y = 0, Width = 260, Height = 160, Color = "blue", Name = "Pedijatrija", FloorId = 1 });
            allRooms[0].Beds = new List<Bed>();
            Bed bed1 = new Bed(1, 1, allRooms[0], true);
            allRooms[0].Beds.Add(bed1);

            stubRepository.Setup(r => r.GetAll()).Returns(allRooms);

            return stubRepository.Object;


        }


    }
}
