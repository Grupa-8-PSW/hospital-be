using HospitalLibrary.Core.Enums;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Util;
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
            var workHour = new DateRange(new DateTime(2022, 12, 1, 8, 0, 0), new DateTime(2022, 12, 1, 16, 0, 0));
            modelBuilder.Entity<Doctor>().HasData(
                new List<Doctor>() {
                    new Doctor(1, "Slobodan", "Radulovic", DoctorSpecialization.GENERAL_PRACTICIONER, 1, workHour),
                    new Doctor(2, "Aleksa", "Zindovic", DoctorSpecialization.GENERAL_PRACTICIONER, 2, workHour),
                    new Doctor(3, "Mica", "Micic", DoctorSpecialization.GENERAL_PRACTICIONER, 3, workHour)
                }
                );
        }
    }
}
