using HospitalLibrary.Core.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Settings.DataSeed
{
    public static class DoctorSeed
    {
        public static void SeedDoctor(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctor>().HasData(
                new Doctor() { Id = 1, FirstName = "Zeljko", LastName = "Babic", RoomId = 1, StartWork = new DateTime(1998, 04, 30, 7, 0, 0, DateTimeKind.Utc), EndWork = new DateTime(1998, 04, 30, 15, 0, 0, DateTimeKind.Utc) },
                new Doctor() { Id = 2, FirstName = "Bora", LastName = "Stevanovic", RoomId = 2, StartWork = new DateTime(1998, 04, 30, 8, 0, 0, DateTimeKind.Utc), EndWork = new DateTime(1998, 04, 30, 16, 0, 0, DateTimeKind.Utc) });      

        }
    }
}
