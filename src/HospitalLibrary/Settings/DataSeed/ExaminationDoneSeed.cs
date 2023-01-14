using HospitalLibrary.Core.Model;
using Microsoft.EntityFrameworkCore;

namespace HospitalLibrary.Settings.DataSeed;

public static class ExaminationDoneSeed
{
    public static void SeedDoneExaminations(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ExaminationDone>().HasData(
            new ExaminationDone()
            {
                Id = 1,
                ExaminationId = 1,
                Record = "Patient successfully recovered."
            },
            new ExaminationDone()
            {
                Id = 2,
                ExaminationId = 2,
                Record = "Patient successfully recovered after having stomach problems."
            },
            new ExaminationDone()
            {
                Id = 3,
                ExaminationId = 3,
                Record = "Patient feels great."
            }
        );
    }
}