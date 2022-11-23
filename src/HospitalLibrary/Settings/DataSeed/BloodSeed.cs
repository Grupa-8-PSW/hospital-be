using System;
using System.Collections.Generic;
using HospitalLibrary.Core.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalLibrary.Core.Enums;

namespace HospitalLibrary.Settings.DataSeed
{
    public static class BloodSeed
    {
        public static void SeedBlood(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blood>().HasData(
                new Blood() { Id = 1, Type = BloodType.ZERO_POSITIVE, Quantity = 100},
                new Blood() { Id = 2, Type = BloodType.ZERO_NEGATIVE, Quantity = 100 },
                new Blood() { Id = 3, Type = BloodType.A_POSITIVE, Quantity = 100 },
                new Blood() { Id = 4, Type = BloodType.A_NEGATIVE, Quantity = 100 },
                new Blood() { Id = 5, Type = BloodType.B_POSITIVE, Quantity = 100 },
                new Blood() { Id = 6, Type = BloodType.B_NEGATIVE, Quantity = 100 },
                new Blood() { Id = 7, Type = BloodType.AB_POSITIVE, Quantity = 100 },
                new Blood() { Id = 8, Type = BloodType.AB_NEGATIVE, Quantity = 100 }
                );
        }
    }
}
