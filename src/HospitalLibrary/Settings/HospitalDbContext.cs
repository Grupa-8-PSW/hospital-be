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
                new Building() { Id = 1, Name = "One", Floors = new List<Floor>() },
                new Building() { Id = 2, Name = "Too", Floors = new List<Floor>() },
                new Building() { Id = 3, Name = "Tre", Floors = new List<Floor>() }
            );
            modelBuilder.Entity<Floor>().HasData(
                new Floor() { Id = 1, Number = "One", BuildingId = 1, Rooms = new List<Room>() },
                new Floor() { Id = 2, Number = "Too", BuildingId = 1, Rooms = new List<Room>() },
                new Floor() { Id = 3, Number = "Tre", BuildingId = 1, Rooms = new List<Room>() },
                new Floor() { Id = 4, Number = "Noo", BuildingId = 2, Rooms = new List<Room>() }
            );
            modelBuilder.Entity<Room>().HasData(
                new Room() { Id = 1, Name = "One", Number = "101A", FloorId = 1 },
                new Room() { Id = 2, Name = "Too", Number = "204", FloorId = 2 },
                new Room() { Id = 3, Name = "Tre", Number = "305B", FloorId = 3 }
            );
            base.OnModelCreating(modelBuilder);
        }
    }
}