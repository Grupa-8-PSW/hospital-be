using HospitalLibrary.Core.Model;
using HospitalLibrary.GraphicalEditor.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Settings.DataSeed
{
    public static class BedSeed
    {
        public static void SeedBed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bed>().HasData(
                new Bed() { Id = 1, RoomId = 1, Available = false },
                new Bed() { Id = 2, RoomId = 1, Available = false },
                new Bed() { Id = 3, RoomId = 1, Available = true },
                new Bed() { Id = 4, RoomId = 1, Available = false },
                new Bed() { Id = 5, RoomId = 3, Available = true },
                new Bed() { Id = 6, RoomId = 3, Available = true },
                new Bed() { Id = 7, RoomId = 3, Available = true },
                new Bed() { Id = 8, RoomId = 3, Available = true },
                new Bed() { Id = 9, RoomId = 3, Available = true },
                new Bed() { Id = 10, RoomId = 3, Available = true },
                new Bed() { Id = 11, RoomId = 9, Available = true },
                new Bed() { Id = 12, RoomId = 9, Available = true },
                new Bed() { Id = 13, RoomId = 9, Available = true },
                new Bed() { Id = 14, RoomId = 9, Available = true },
                new Bed() { Id = 15, RoomId = 16, Available = true },
                new Bed() { Id = 16, RoomId = 16, Available = true },
                new Bed() { Id = 17, RoomId = 16, Available = true }, 
                new Bed() { Id = 18, RoomId = 16, Available = true },
                new Bed() { Id = 19, RoomId = 17, Available = true },
                new Bed() { Id = 20, RoomId = 17, Available = true },
                new Bed() { Id = 21, RoomId = 17, Available = true },
                new Bed() { Id = 22, RoomId = 17, Available = true }
                );
        }

    }
}
