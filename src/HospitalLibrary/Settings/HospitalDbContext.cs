using HospitalLibrary.GraphicalEditor.Model;
using HospitalLibrary.GraphicalEditor.Model.Map;
using Microsoft.EntityFrameworkCore;

namespace HospitalLibrary.Settings
{
    public class HospitalDbContext : DbContext
    {
        public DbSet<MapBuilding> MapBuildings { get; set; }
        public DbSet<MapFloor> MapFloors { get; set; }
        public DbSet<MapRoom> MapRooms { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Floor> Floors { get; set; }
        public DbSet<Room> Rooms { get; set; }

        public HospitalDbContext(DbContextOptions<HospitalDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Building>().HasData(
                new Building() { Id = 1, Name = "One", Floors = new List<Floor>() },
                new Building() { Id = 2, Name = "Too", Floors = new List<Floor>() },
                new Building() { Id = 3, Name = "Tre", Floors = new List<Floor>() }
            );
            modelBuilder.Entity<MapBuilding>().HasData(
                new MapBuilding() { Id = 1, x = 100, y = 100, width = 450, height = 150, color = "gray", BuildingId = 1 },
                new MapBuilding() { Id = 2, x = 600, y = 100, width = 150, height = 450, color = "gray", BuildingId = 2 },
                new MapBuilding() { Id = 3, x = 400, y = 600, width = 400, height = 130, color = "gray", BuildingId = 3 }
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