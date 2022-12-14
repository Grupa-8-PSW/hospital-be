using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Model.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalLibrary.Core.Enums;

namespace HospitalLibrary.Settings.DataSeed
{
    public static class ExaminationSeed
    {
        public static void SeedExamination(this ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Examination>(b =>
            {
                b.HasData(new Examination(1, 1, 1, 1, ExaminationStatus.FINISHED));
                b.OwnsOne(e => e.DateRange).HasData(new
                {
                    ExaminationId = 1,
                    Start = new DateTime(2022, 12, 1, 7, 0, 0),
                    End = new DateTime(2022, 12, 1, 7, 30, 0)
                });

                b.HasData(new Examination(2, 1, 1, 2, ExaminationStatus.FINISHED));
                b.OwnsOne(e => e.DateRange).HasData(new
                {
                    ExaminationId = 2,
                    Start = new DateTime(2022, 12, 1, 8, 0, 0),
                    End = new DateTime(2022, 12, 1, 8, 30, 0)
                });

                b.HasData(new Examination(3, 2, 1, 2, ExaminationStatus.UPCOMING));
                b.OwnsOne(e => e.DateRange).HasData(new
                {
                    ExaminationId = 3,
                    Start = new DateTime(2022, 12, 15, 12, 0, 0),
                    End = new DateTime(2022, 12, 15, 12, 30, 0)
                });

                b.HasData(new Examination(4, 3, 1, 3, ExaminationStatus.UPCOMING));
                b.OwnsOne(e => e.DateRange).HasData(new
                {
                    ExaminationId = 4,
                    Start = new DateTime(2023, 1, 22, 8, 0, 0),
                    End = new DateTime(2023, 1, 22, 8, 30, 0)
                });

                b.HasData(new Examination(5, 1, 1, 1, ExaminationStatus.UPCOMING));
                b.OwnsOne(e => e.DateRange).HasData(new
                {
                    ExaminationId = 5,
                    Start = new DateTime(2023, 2, 5, 9, 0, 0),
                    End = new DateTime(2023, 2, 5, 9, 30, 0)
                });

                b.HasData(new Examination(6, 1, 1, 1, ExaminationStatus.CANCELED));
                b.OwnsOne(e => e.DateRange).HasData(new
                {
                    ExaminationId = 6,
                    Start = new DateTime(2022, 12, 27, 7, 0, 0),
                    End = new DateTime(2022, 12, 27, 7, 30, 0)
                });

                b.HasData(new Examination(7, 1, 3, 3, ExaminationStatus.FINISHED));
                b.OwnsOne(e => e.DateRange).HasData(new
                {
                    ExaminationId = 7,
                    Start = new DateTime(2022, 12, 1, 8, 30, 0),
                    End = new DateTime(2022, 12, 1, 9, 0, 0)
                });
            });
        }
    }
}
