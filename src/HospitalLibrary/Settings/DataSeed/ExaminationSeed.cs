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
            /*modelBuilder.Entity<Examination>().HasData(
                new List<Examination>() { 
                    new Examination(1, 1, 1, new DateRange(new DateTime(2022, 12, 1, 7, 0, 0), new DateTime(2022, 12, 1, 7, 30, 0))),
                    new Examination(2, 1, 2, new DateRange(new DateTime(2022, 12, 1, 8, 0, 0), new DateTime(2022, 12, 1, 8, 30, 0))),
                    new Examination(3, 1, 3, new DateRange(new DateTime(2022, 12, 1, 8, 30, 0), new DateTime(2022, 12, 1, 9, 0, 0)))
                });*/
            modelBuilder.Entity<Examination>(b =>
            {
                b.HasData(new Examination(1, 1, 1, 1));
                b.OwnsOne(e => e.DateRange).HasData(new
                {
                    ExaminationId = 1,
                    Start = new DateTime(2022, 12, 1, 7, 0, 0),
                    End = new DateTime(2022, 12, 1, 7, 30, 0)
                });
                b.HasData(new Examination(2, 1, 2, 2));
                b.OwnsOne(e => e.DateRange).HasData(new
                {
                    ExaminationId = 2,
                    Start = new DateTime(2022, 12, 1, 8, 0, 0),
                    End = new DateTime(2022, 12, 1, 8, 30, 0)
                });
                b.HasData(new Examination(3, 1, 3, 3));
                b.OwnsOne(e => e.DateRange).HasData(new
                {
                    ExaminationId = 3,
                    Start = new DateTime(2022, 12, 1, 8, 30, 0),
                    End = new DateTime(2022, 12, 1, 9, 0, 0)
                });
            });
        }
    }
}
