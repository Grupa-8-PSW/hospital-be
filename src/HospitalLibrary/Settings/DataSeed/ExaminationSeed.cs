using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Model.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Settings.DataSeed
{
    public static class ExaminationSeed
    {
        public static void SeedExamination(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Examination>().HasData(
                new List<Examination>() { 
                    new Examination(1, 1, 1, new DateRange(new DateTime(2022, 12, 1, 7, 0, 0), new DateTime(2022, 12, 1, 7, 30, 0))),
                    new Examination(2, 1, 2, new DateRange(new DateTime(2022, 12, 1, 8, 0, 0), new DateTime(2022, 12, 1, 8, 30, 0))),
                    new Examination(3, 1, 3, new DateRange(new DateTime(2022, 12, 1, 8, 30, 0), new DateTime(2022, 12, 1, 9, 0, 0))),
                    new Examination(4, 2, 1, new DateRange(new DateTime(2022, 12, 16, 6, 0, 0), new DateTime(2022, 12, 16, 6, 30, 0))),
                    new Examination(5, 2, 1, new DateRange(new DateTime(2022, 12, 25, 9, 0, 0), new DateTime(2022, 12, 25, 9, 30, 0))),
                    new Examination(6, 1, 1, new DateRange(new DateTime(2022, 12, 27, 10, 0, 0), new DateTime(2022, 12, 27, 10, 30, 0)))
                });

        }
    }
}
