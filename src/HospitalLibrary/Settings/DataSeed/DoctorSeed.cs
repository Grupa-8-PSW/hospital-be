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
                new Doctor() { Id = 1, FirstName = "firstName", LastName = "lastName", RoomId = 1, StartWork = new DateTime(), EndWork = new DateTime() });
        }
    }
}
