using HospitalLibrary.Core.Enums;
using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Core.Model.ValueObject;
using IntegrationLibrary.Persistence.DataSeed;
using Microsoft.EntityFrameworkCore;
using MimeKit;

namespace IntegrationLibrary.Persistence
{
    public class IntegrationDbContext : DbContext
    {
        public DbSet<BloodBank> BloodBanks { get; set; }
        public DbSet<BloodConsumptionConfiguration> BloodConsumptionConfiguration { get; set; }
        public DbSet<BloodBankNews> BloodBankNews { get; set; }
        public DbSet<TenderOffer> TenderOffer { get; set; }

        public DbSet<UrgentRequest> UrgentRequest { get; set; }
        
        public DbSet<Tender> Tenders { get; set; }

        public DbSet<MonthlySubscription> MonthlySubscription { get; set; }

        public DbSet<BloodRequestDelivery> BloodRequestDelivery { get; set; }

        public IntegrationDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<BloodBank>().HasData(
                new BloodBank() { Id = 1, Email = "nbloodbank@mail.com", Name = "National blood bank", ServerAddress = "http://localhost:8081/", APIKey="123", MonthlySubscriptionRoutingKey= "monthlySubscriptions29", Image= "https://firebasestorage.googleapis.com/v0/b/isapsw-6ef61.appspot.com/o/hospital%20images%2Fhospital2.jpg?alt=media&token=86e5b815-e371-4b88-9411-fc5e6cc179df" },
                new BloodBank() { Id = 2, Email = "bloodsource@mail.com", Name = "BloodSource", ServerAddress = "http://localhost:8082/", APIKey = "321", MonthlySubscriptionRoutingKey = "monthlySubscriptions30", Image= "https://firebasestorage.googleapis.com/v0/b/isapsw-6ef61.appspot.com/o/hospital%20images%2Fhospital3.jpg?alt=media&token=522f1c18-ae7f-494b-b696-091fac455630" },
                new BloodBank() { Id = 3, Email = "bloodalliance@mail.com", Name = "The Blood Alliance", ServerAddress = "http://localhost:8083/", APIKey = "213", MonthlySubscriptionRoutingKey = "monthlySubscriptions31", Image= "https://firebasestorage.googleapis.com/v0/b/isapsw-6ef61.appspot.com/o/hospital%20images%2Fhospital4.jpg?alt=media&token=415ce5f8-c22d-4090-9ee2-3960d10a2b25" },
                new BloodBank() { Id = 4, Email = "fingercross@mail.com", Name = "Finger cross", ServerAddress = "http://localhost:8084/", APIKey = "231", MonthlySubscriptionRoutingKey = "monthlySubscriptions32", Image= "https://firebasestorage.googleapis.com/v0/b/isapsw-6ef61.appspot.com/o/hospital%20images%2Fhospital1.jpg?alt=media&token=db040d31-6fb8-4615-a875-3ff3f4aa78f5" }
                
            );

            modelBuilder.Entity<TenderOffer>()
             .Property(b => b.Offers)
             .HasColumnType("jsonb");


            modelBuilder.Entity<Tender>()
                .Property(b => b.DateRange)
                .HasColumnType("jsonb");

            modelBuilder.Entity<Tender>()
                .Property(b => b.Blood)
                .HasColumnType("jsonb");

            modelBuilder.Entity<UrgentRequest>()
                .Property(b => b.Blood)
                .HasColumnType("jsonb");

            modelBuilder.Entity<MonthlySubscription>()
                .Property(b => b.RequestedBlood)
                .HasColumnType("jsonb");


            modelBuilder.SeedBloodBankNews();

        }

    }
}