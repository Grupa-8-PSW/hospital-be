using HospitalLibrary.GraphicalEditor.Model.Map;
using HospitalLibrary.GraphicalEditor.Model;
using Microsoft.EntityFrameworkCore;


namespace HospitalLibrary.Settings.DataSeed
{
    public static class MapSeed
    {
        public static void SeedMap(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Building>().HasData(
                new Building() { Id = 1, X = 100, Y = 100, Width = 450, Height = 150, Color = "gray", Name = "One", Floors = new List<Floor>() },
                new Building() { Id = 2, X = 600, Y = 100, Width = 150, Height = 450, Color = "gray", Name = "Too", Floors = new List<Floor>() },
                new Building() { Id = 3, X = 400, Y = 600, Width = 400, Height = 130, Color = "gray", Name = "Tre", Floors = new List<Floor>() }
            );
            /*
            modelBuilder.Entity<MapBuilding>().HasData(
                new MapBuilding() { Id = 1, X = 100, Y = 100, Width = 450, Height = 150, Color = "gray", BuildingId = 1 },
                new MapBuilding() { Id = 2, X = 600, Y = 100, Width = 150, Height = 450, Color = "gray", BuildingId = 2 },
                new MapBuilding() { Id = 3, X = 400, Y = 600, Width = 400, Height = 130, Color = "gray", BuildingId = 3 }
            );
            */
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
        }
    }
}
