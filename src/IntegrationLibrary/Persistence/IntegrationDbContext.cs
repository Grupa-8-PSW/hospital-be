using IntegrationLibrary.Core.Model;
using Microsoft.EntityFrameworkCore;

namespace IntegrationLibrary.Persistence
{
    public class IntegrationDbContext: DbContext
    {
        public DbSet<BloodBank> BloodBanks { get; set; }
        public IntegrationDbContext(DbContextOptions options): base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BloodBank>().HasData(
                new BloodBank() { Id = 1, Email = "test@test.com", Name = "testName", ServerAddress = "testServAdd" }
            );
            base.OnModelCreating(modelBuilder);
        }

    }
}
