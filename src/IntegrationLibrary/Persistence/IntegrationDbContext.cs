using IntegrationLibrary.Core.Model;
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
        public IntegrationDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Tender> Tenders { get; set; }
        public DbSet<Ad> Ads { get; set; }
        public DbSet<MonthlySubscription> MonthlySubscription { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<BloodBank>().HasData(
                new BloodBank() { Id = 1, Email = "test@test.com", Name = "Banka 1", ServerAddress = "http://localhost:8081/", APIKey="123", MonthlySubscriptionRoutingKey= "monthlySubscriptions29"},
                new BloodBank() { Id = 2, Email = "test@test.com", Name = "Banka 2", ServerAddress = "http://localhost:8082/", APIKey = "321", MonthlySubscriptionRoutingKey = "monthlySubscriptions30" },
                new BloodBank() { Id = 3, Email = "test@test.com", Name = "Banka 3", ServerAddress = "http://localhost:8083/", APIKey = "213", MonthlySubscriptionRoutingKey = "monthlySubscriptions31" },
                new BloodBank() { Id = 4, Email = "test@test.com", Name = "Banka 4", ServerAddress = "http://localhost:8084/", APIKey = "231", MonthlySubscriptionRoutingKey = "monthlySubscriptions32" }
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

            modelBuilder.Entity<MonthlySubscription>()
                .Property(b => b.RequestedBlood)
                .HasColumnType("jsonb");

            modelBuilder.SeedBloodBankNews();
        }

    }
}