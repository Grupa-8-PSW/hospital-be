using HospitalLibrary.Core.Model;
using HospitalLibrary.GraphicalEditor.Model;
using HospitalLibrary.GraphicalEditor.Repository;
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

    }
}
