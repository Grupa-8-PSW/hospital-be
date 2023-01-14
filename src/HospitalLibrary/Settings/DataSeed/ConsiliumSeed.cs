using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Model.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace HospitalLibrary.Settings.DataSeed;

public static class ConsiliumSeed
{
    public static void SeedConsilium(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Consilium>(b =>
        {
            b.HasData(new Consilium(1, "New disease", 120));
            b.OwnsOne(c => c.Interval).HasData(new
            {
                ConsiliumId = 1,
                Start = new DateTime(2023, 1, 22, 15, 30, 0, DateTimeKind.Utc),
                End = new DateTime(2023, 1, 22, 16, 30, 0, DateTimeKind.Utc)
            });

            b.HasData(new Consilium(2, "Covid-19", 180));
            b.OwnsOne(c => c.Interval).HasData(new
            {
                ConsiliumId = 2,
                Start = new DateTime(2022, 10, 20, 9, 15, 0, DateTimeKind.Utc),
                End = new DateTime(2022, 10, 20, 12, 15, 0, DateTimeKind.Utc)
            });
        });
    }
}