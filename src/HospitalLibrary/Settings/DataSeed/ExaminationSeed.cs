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
                    new Examination(1, 1, 1, 1, new DateTime(2022, 12, 1, 7, 0, 0, DateTimeKind.Utc), 20),
                    new Examination(2, 1, 1, 2, new DateTime(2022, 12, 1, 8, 0, 0, DateTimeKind.Utc), 45),
                    new Examination(3, 1, 2, 3, new DateTime(2022, 12, 1, 8, 30, 0, DateTimeKind.Utc), 18),
                    new Examination(4, 2, 1, 3, new DateTime(2022, 12, 8, 19, 30, 0, DateTimeKind.Utc), 23),
                    new Examination(5, 2, 1, 3, new DateTime(2022, 12, 20, 19, 30, 0, DateTimeKind.Utc), 24));
        }
    }
}
