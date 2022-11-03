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
                new Floor() { Id = 3, X = 100, Y = 70, Width = 300, Height = 100, Color = "white", Number = "Floor 3", BuildingId = 1, Rooms = new List<Room>() },
                new Floor() { Id = 2, X = 100, Y = 170, Width = 300, Height = 100, Color = "white", Number = "Floor 2", BuildingId = 1, Rooms = new List<Room>() },
                new Floor() { Id = 1, X = 100, Y = 270, Width = 300, Height = 100, Color = "white", Number = "Floor 1", BuildingId = 1, Rooms = new List<Room>() },
                new Floor() { Id = 5, X = 100, Y = 170, Width = 300, Height = 100, Color = "white", Number = "Floor 2", BuildingId = 2, Rooms = new List<Room>() },
                new Floor() { Id = 4, X = 100, Y = 270, Width = 300, Height = 100, Color = "white", Number = "Floor 1", BuildingId = 2, Rooms = new List<Room>() },
                new Floor() { Id = 8, X = 100, Y = 70, Width = 300, Height = 100, Color = "white", Number = "Floor 3", BuildingId = 3, Rooms = new List<Room>() },
                new Floor() { Id = 7, X = 100, Y = 170, Width = 300, Height = 100, Color = "white", Number = "Floor 2", BuildingId = 3, Rooms = new List<Room>() },
                new Floor() { Id = 6, X = 100, Y = 270, Width = 300, Height = 100, Color = "white", Number = "Floor 1", BuildingId = 3, Rooms = new List<Room>() }
            );
            modelBuilder.Entity<Room>().HasData(
                new Room() { Id = 1, X = 0, Y = 0, Width = 260, Height = 160, Color = "blue", Name = "Pedijatrija" , FloorId = 1 },
                new Room() { Id = 2, X = 0, Y = 338, Width = 220, Height = 140, Color = "blue", Name = "Kafeterija", FloorId = 1 },
                new Room() { Id = 3, X = 237, Y = 0, Width = 300, Height = 180, Color = "blue", Name = "Otorinolaringologija", FloorId = 1 },
                new Room() { Id = 4, X = 270, Y = 378, Width = 200, Height = 100, Color = "blue", Name = "Fizioterapeut", FloorId = 2 },
                new Room() { Id = 5, X = 0, Y = 0, Width = 360, Height = 180, Color = "blue", Name = "Stomatologija", FloorId = 2 },
                new Room() { Id = 6, X = 0, Y = 0, Width = 260, Height = 180, Color = "blue", Name = "Magacin", FloorId = 3 },
                new Room() { Id = 7, X = 0, Y = 338, Width = 220, Height = 140, Color = "blue", Name = "Opsta nega", FloorId = 3},
                new Room() { Id = 8, X = 330, Y = 158, Width = 220, Height = 140, Color = "blue", Name = "Cekaonica", FloorId = 3 },
                new Room() { Id = 9, X = 0, Y = 0, Width = 320, Height = 170, Color = "blue", Name = "Kardiologija", FloorId = 4 },
                new Room() { Id = 10, X = 0, Y = 365, Width = 220, Height = 140, Color = "blue", Name = "Vaskularne bolesti", FloorId = 4 },
                new Room() { Id = 11, X = 245, Y = 0, Width = 220, Height = 140, Color = "blue", Name = "Hirurgija", FloorId = 4 },
                new Room() { Id = 12, X = 0, Y = 0, Width = 220, Height = 140, Color = "blue", Name = "Papirologija", FloorId = 5 },
                new Room() { Id = 13, X = 200, Y = 0, Width = 220, Height = 140, Color = "blue", Name = "Prijavna soba", FloorId = 5 },
                new Room() { Id = 14, X = 0, Y = 350, Width = 220, Height = 140, Color = "blue", Name = "Uplasta/isplata", FloorId = 5 },
                new Room() { Id = 15, X = 200, Y = 350, Width = 220, Height = 140, Color = "blue", Name = "Izgubljeno/nadjeno", FloorId = 5 },
                new Room() { Id = 16, X = 0, Y = 0, Width = 320, Height = 190, Color = "blue", Name = "Onkologija", FloorId = 6 },
                new Room() { Id = 17, X = 200, Y = 300, Width = 250, Height = 240, Color = "blue", Name = "Onkologija", FloorId = 6 },
                new Room() { Id = 18, X = 50, Y = 100, Width = 420, Height = 280, Color = "blue", Name = "Gastronomija", FloorId = 7 },
                new Room() { Id = 19, X = 100, Y = 138, Width = 320, Height = 170, Color = "blue", Name = "Magacin", FloorId = 8 }
            );

                modelBuilder.Entity<Form>().HasData(
                new Form() { Id = 1, Name = "101,Pedijatrija" , Description= "Pregledi za decu", StartHourWorkDay = "10:00h" , EndHourWorkDay = "17:00h" , StartHourSaturday = "12:00h" , EndHourSaturday = "17:00h" , StartHourSunday = "CLOSED" , EndHourSunday = "CLOSED", RoomId = 1 },
                new Form() { Id = 2, Name = "102,Kafeterija", Description = "Opustanje za radnike i posetioce", StartHourWorkDay = "10:00h", EndHourWorkDay = "17:00h", StartHourSaturday = "12:00h", EndHourSaturday = "17:00h", StartHourSunday = "CLOSED", EndHourSunday = "CLOSED", RoomId = 2 },
                new Form() { Id = 3, Name = "103,Otorinolaringologija", Description = "UHO,GRLO,NOS", StartHourWorkDay = "10:00h", EndHourWorkDay = "17:00h", StartHourSaturday = "12:00h", EndHourSaturday = "17:00h", StartHourSunday = "CLOSED", EndHourSunday = "CLOSED", RoomId = 3 },
                new Form() { Id = 4, Name = "201,Fizioterapeut", Description = "Pregled misica i povreda", StartHourWorkDay = "10:00h", EndHourWorkDay = "17:00h", StartHourSaturday = "12:00h", EndHourSaturday = "17:00h", StartHourSunday = "CLOSED", EndHourSunday = "CLOSED", RoomId = 4 }
            );
        }
    }
}
