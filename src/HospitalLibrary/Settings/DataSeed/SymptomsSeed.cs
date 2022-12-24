using HospitalLibrary.Core.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Settings.DataSeed
{
    public static class SymptomsSeed
    {
        public static void SeedSymptoms(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Symptom>().HasData(
                new Symptom() { Id = 1, Name = "Temperatura" },
                new Symptom() { Id = 2, Name = "Glavobolja" },
                new Symptom() { Id = 3, Name = "Bol u stomaku" }
                );
        }
    }
}
