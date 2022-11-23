using HospitalLibrary.Core.Model;
using Microsoft.EntityFrameworkCore;
<<<<<<< HEAD
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
=======
>>>>>>> 4addd3d9fd52b77c8be88d680c2e3dc301c3a87a

namespace HospitalLibrary.Settings.DataSeed
{
    public static class DoctorSeed
    {
        public static void SeedDoctor(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctor>().HasData(
<<<<<<< HEAD
                new Doctor() { Id = 1, FirstName = "firstName", LastName = "lastName", RoomId = 1, StartWork = DateTime.UtcNow, EndWork = DateTime.UtcNow },
                new Doctor() { Id = 2, FirstName = "firstNam2", LastName = "lastName2", RoomId = 1, StartWork = DateTime.UtcNow, EndWork = DateTime.UtcNow });
=======
                new Doctor() { Id = 1, FirstName = "Zeljko", LastName = "Babic", RoomId = 1, StartWork = new DateTime(1998, 04, 30, 7, 0, 0, DateTimeKind.Utc), EndWork = new DateTime(1998, 04, 30, 15, 0, 0, DateTimeKind.Utc) },
                new Doctor() { Id = 2, FirstName = "Bora", LastName = "Stevanovic", RoomId = 2, StartWork = new DateTime(1998, 04, 30, 8, 0, 0, DateTimeKind.Utc), EndWork = new DateTime(1998, 04, 30, 16, 0, 0, DateTimeKind.Utc) });      
>>>>>>> 4addd3d9fd52b77c8be88d680c2e3dc301c3a87a
        }
    }
}
