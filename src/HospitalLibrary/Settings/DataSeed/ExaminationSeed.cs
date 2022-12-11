using HospitalLibrary.Core.Model;
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
                    new Examination(1, 1, 1, 1, new DateTime(2022, 12, 1, 7, 0, 0, DateTimeKind.Utc), 20, 0),
                    new Examination(2, 1, 1, 2, new DateTime(2022, 12, 1, 8, 0, 0, DateTimeKind.Utc), 45, 0),
                    new Examination(3, 1, 2, 3, new DateTime(2022, 12, 15, 18, 30, 0, DateTimeKind.Utc), 7, 0),
                    new Examination(4, 2, 1, 3, new DateTime(2022, 12, 11, 23, 30, 0, DateTimeKind.Utc), 23, 0),
                    new Examination(5, 2, 1, 2, new DateTime(2022, 12, 20, 19, 30, 0, DateTimeKind.Utc), 24, 0),
                    new Examination(6, 1, 1, 1, new DateTime(2023, 10, 23, 14, 15, 0, DateTimeKind.Utc), 45, 0));

        }
    }
}
