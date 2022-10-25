using HospitalLibrary.Core.Model;
using Microsoft.EntityFrameworkCore;

namespace HospitalLibrary.Settings
{
    public class HospitalDbContext : DbContext
    {
        public DbSet<BloodBank> BloodBanks { get; set; }

        public HospitalDbContext(DbContextOptions<HospitalDbContext> options) : base(options) { }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BloodBank>().HasData(
                new BloodBank() { Id=1, Email = "test@test.com", Name = "testName", ServerAddress = "testServAdd" }
            );
            base.OnModelCreating(modelBuilder);
        }
    }
}