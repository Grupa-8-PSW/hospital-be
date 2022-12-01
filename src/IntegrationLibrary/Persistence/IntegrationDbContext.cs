﻿using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Persistence.DataSeed;
using Microsoft.EntityFrameworkCore;

namespace IntegrationLibrary.Persistence
{
    public class IntegrationDbContext: DbContext
    {
        public DbSet<BloodBank> BloodBanks { get; set; }
        public DbSet<BloodConsumptionConfiguration> BloodConsumptionConfiguration { get; set; }
        public DbSet<BloodBankNews> BloodBankNews { get; set; }
        public DbSet<Tender> Tenders { get; set; }
        public IntegrationDbContext(DbContextOptions options): base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<BloodBank>().HasData(
                new BloodBank() { Id = 1, Email = "test@test.com", Name = "testName", ServerAddress = "htttp://localhost:8081/" }
            );

            modelBuilder.Entity<Tender>()
                .Property(b => b.DateRange)
                .HasColumnType("jsonb");

            modelBuilder.Entity<Tender>()
                .Property(b => b.Blood)
                .HasColumnType("jsonb");

            modelBuilder.SeedBloodBankNews();
        }

    }
}
