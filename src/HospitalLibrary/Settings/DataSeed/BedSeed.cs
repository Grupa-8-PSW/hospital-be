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
                new Bed() { Id = 1, RoomId = 1, Available = true },
                new Bed() { Id = 2, RoomId = 1, Available = true },
                new Bed() { Id = 3, RoomId = 2, Available = false },
                new Bed() { Id = 4, RoomId = 2, Available = true },
                new Bed() { Id = 5, RoomId = 3, Available = false },
                new Bed() { Id = 6, RoomId = 3, Available = false }
                );
        }

    }
}
