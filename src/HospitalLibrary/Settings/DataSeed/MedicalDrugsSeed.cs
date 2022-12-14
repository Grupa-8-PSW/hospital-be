using HospitalLibrary.Core.Enums;
using HospitalLibrary.Core.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Settings.DataSeed
{
    public static class MedicalDrugsSeed
    {
        public static void SeedMedicalDrugs(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MedicalDrugs>().HasData(
                new MedicalDrugs() { Id = 1, Name = "Drugs1", Code = "Code1", Amount = 50 },
                new MedicalDrugs() { Id = 2, Name = "Drugs2", Code = "Code2", Amount = 50 },
                new MedicalDrugs() { Id = 3, Name = "Drugs3", Code = "Code3", Amount = 50 }
                );
        }
    }
}
