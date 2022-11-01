using HospitalLibrary.GraphicalEditor.Model;
using Microsoft.EntityFrameworkCore;

namespace HospitalLibrary.Settings
{
    public class HospitalDbContext : DbContext
    {
        public DbSet<Building> Buildings { get; set; }

        public HospitalDbContext(DbContextOptions<HospitalDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Building>().HasData(
                new Building() { Id = 1, Name = "One" },
                new Building() { Id = 2, Name = "Too" },
                new Building() { Id = 3, Name = "Tre" }
            );
            base.OnModelCreating(modelBuilder);
        }
    }
}