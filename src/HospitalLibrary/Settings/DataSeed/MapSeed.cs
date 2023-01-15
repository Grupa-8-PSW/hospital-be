using HospitalLibrary.Core.Enums;
using HospitalLibrary.GraphicalEditor.Model;
using Microsoft.EntityFrameworkCore;

namespace HospitalLibrary.Settings.DataSeed
{
    public static class MapSeed
    {
        public static void SeedMap(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Building>().HasData(
                new Building() { Id = 1, X = 100, Y = 100, Width = 450, Height = 150, Color = "gray", Name = "A-Wing", Floors = new List<Floor>() },
                new Building() { Id = 2, X = 600, Y = 100, Width = 150, Height = 450, Color = "gray", Name = "B-Wing", Floors = new List<Floor>() },
                new Building() { Id = 3, X = 400, Y = 600, Width = 400, Height = 130, Color = "gray", Name = "Y-Wing", Floors = new List<Floor>() }
            );

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

            modelBuilder.Entity<Room>(r =>
            {
                r.HasData(
                    new { Id = 1, Number = "101", Name = "Neurohirurgija", FloorId = 1, Type = RoomType.OPERATIONS },
                    new { Id = 2, Number = "102", Name = "Kafeterija", FloorId = 1, Type = RoomType.CAFETERIA },
                    new { Id = 3, Number = "103", Name = "Otorinolaringologija", FloorId = 1, Type = RoomType.OTHER },
                    new { Id = 4, Number = "201", Name = "Fizioterapeut", FloorId = 2, Type = RoomType.OTHER },
                    new { Id = 5, Number = "202", Name = "Stomatologija", FloorId = 2, Type = RoomType.OTHER },
                    new { Id = 6, Number = "301", Name = "Magacin", FloorId = 3, Type = RoomType.MAGAZINE },
                    new { Id = 7, Number = "302", Name = "Opsta nega", FloorId = 3, Type = RoomType.OTHER },
                    new { Id = 8, Number = "303", Name = "Cekaonica", FloorId = 3, Type = RoomType.OTHER },
                    new { Id = 9, Number = "101a", Name = "Kardiologija", FloorId = 4, Type = RoomType.OPERATIONS },
                    new { Id = 10, Number = "102a", Name = "Vaskularne bolesti", FloorId = 4, Type = RoomType.OTHER },
                    new { Id = 11, Number = "103a", Name = "Hirurgija", FloorId = 4, Type = RoomType.OPERATIONS },
                    new { Id = 12, Number = "201a", Name = "Papirologija", FloorId = 5, Type = RoomType.OTHER },
                    new { Id = 13, Number = "202a", Name = "Prijavna soba", FloorId = 5, Type = RoomType.OTHER },
                    new { Id = 14, Number = "203a", Name = "Uplasta/isplata", FloorId = 5, Type = RoomType.OTHER },
                    new { Id = 15, Number = "204a", Name = "Izgubljeno/nadjeno", FloorId = 5, Type = RoomType.OTHER },
                    new { Id = 16, Number = "101b", Name = "Onkologija", FloorId = 6, Type = RoomType.OTHER },
                    new { Id = 17, Number = "102b", Name = "Endokrinologija", FloorId = 6, Type = RoomType.OPERATIONS },
                    new { Id = 18, Number = "201b", Name = "Gastronomija", FloorId = 7, Type = RoomType.OTHER },
                    new { Id = 19, Number = "301b", Name = "Magacin", FloorId = 8, Type = RoomType.MAGAZINE }
                    );
                r.OwnsOne(r => r.Map).HasData(
                    new { RoomId = 1, X = 0, Y = 0, Width = 260, Height = 160, Color = "blue" },
                    new { RoomId = 2, X = 0, Y = 338, Width = 220, Height = 140, Color = "blue" },
                    new { RoomId = 3, X = 237, Y = 0, Width = 300, Height = 180, Color = "blue" },
                    new { RoomId = 4, X = 270, Y = 378, Width = 200, Height = 100, Color = "blue" },
                    new { RoomId = 5, X = 0, Y = 0, Width = 360, Height = 180, Color = "blue" },
                    new { RoomId = 6, X = 0, Y = 0, Width = 260, Height = 180, Color = "blue" },
                    new { RoomId = 7, X = 0, Y = 338, Width = 220, Height = 140, Color = "blue" },
                    new { RoomId = 8, X = 330, Y = 158, Width = 220, Height = 140, Color = "blue" },
                    new { RoomId = 9, X = 0, Y = 0, Width = 320, Height = 170, Color = "blue" },
                    new { RoomId = 10, X = 0, Y = 365, Width = 220, Height = 140, Color = "blue" },
                    new { RoomId = 11, X = 245, Y = 0, Width = 220, Height = 140, Color = "blue" },
                    new { RoomId = 12, X = 0, Y = 0, Width = 220, Height = 140, Color = "blue" },
                    new { RoomId = 13, X = 200, Y = 0, Width = 220, Height = 140, Color = "blue" },
                    new { RoomId = 14, X = 0, Y = 350, Width = 220, Height = 140, Color = "blue" },
                    new { RoomId = 15, X = 200, Y = 350, Width = 220, Height = 140, Color = "blue" },
                    new { RoomId = 16, X = 0, Y = 0, Width = 320, Height = 190, Color = "blue" },
                    new { RoomId = 17, X = 200, Y = 300, Width = 250, Height = 240, Color = "blue" },
                    new { RoomId = 18, X = 50, Y = 100, Width = 420, Height = 280, Color = "blue" },
                    new { RoomId = 19, X = 100, Y = 138, Width = 320, Height = 170, Color = "blue" }
                    );
            });

            modelBuilder.Entity<Renovation>().HasData(
                new { Id = 1, Type = 2, RoomId = 2, Interval = 3, Duration = 3, Available = 3, Changes = 1, Schedule = 1 },
                new { Id = 2, Type = 1, RoomId = 2, Interval = 1, Duration = 3, Available = 3, Changes = 1, Schedule = 1 },
                new { Id = 3, Type = 1, RoomId = 1, Interval = 2, Duration = 3, Available = 2, Changes = 1, Schedule = 1 },
                new { Id = 4, Type = 2, RoomId = 3, Interval = 2, Duration = 3, Available = 2, Changes = 1, Schedule = 0 },
                new { Id = 5, Type = 2, RoomId = 3, Interval = 2, Duration = 2, Available = 2, Changes = 0, Schedule = 0 },
                new { Id = 6, Type = 2, RoomId = 2, Interval = 2, Duration = 2, Available = 2, Changes = 1, Schedule = 1 },
                new { Id = 7, Type = 1, RoomId = 2, Interval = 3, Duration = 3, Available = 1, Changes = 1, Schedule = 1 },
                new { Id = 8, Type = 1, RoomId = 1, Interval = 1, Duration = 1, Available = 0, Changes = 0, Schedule = 0 },
                new { Id = 9, Type = 2, RoomId = 2, Interval = 2, Duration = 1, Available = 1, Changes = 0, Schedule = 0 }
            );

            modelBuilder.Entity<Form>().HasData(
                new Form() { Id = 1, Name = "101,Neurohirurgija", Description = "Neuroloske operacije i zahvati", StartHourWorkDay = "8:00h", EndHourWorkDay = "17:00h", StartHourSaturday = "12:00h", EndHourSaturday = "17:00h", StartHourSunday = "CLOSED", EndHourSunday = "CLOSED", RoomId = 1 },
                new Form() { Id = 2, Name = "102,Kafeterija", Description = "Opustanje za radnike i posetioce", StartHourWorkDay = "10:00h", EndHourWorkDay = "17:00h", StartHourSaturday = "12:00h", EndHourSaturday = "17:00h", StartHourSunday = "CLOSED", EndHourSunday = "CLOSED", RoomId = 2 },
                new Form() { Id = 3, Name = "103,Otorinolaringologija", Description = "UHO,GRLO,NOS", StartHourWorkDay = "10:00h", EndHourWorkDay = "17:00h", StartHourSaturday = "12:00h", EndHourSaturday = "17:00h", StartHourSunday = "CLOSED", EndHourSunday = "CLOSED", RoomId = 3 },
                new Form() { Id = 4, Name = "201,Fizioterapeut", Description = "Pregled misica i povreda", StartHourWorkDay = "10:00h", EndHourWorkDay = "17:00h", StartHourSaturday = "12:00h", EndHourSaturday = "17:00h", StartHourSunday = "CLOSED", EndHourSunday = "CLOSED", RoomId = 4 },
                new Form() { Id = 5, Name = "202,Stomatologija", Description = "Pregledi za decu", StartHourWorkDay = "10:00h", EndHourWorkDay = "17:00h", StartHourSaturday = "12:00h", EndHourSaturday = "17:00h", StartHourSunday = "CLOSED", EndHourSunday = "CLOSED", RoomId = 5 },
                new Form() { Id = 6, Name = "301,Magacin", Description = "Stanje robe u objektu", StartHourWorkDay = "10:00h", EndHourWorkDay = "17:00h", StartHourSaturday = "12:00h", EndHourSaturday = "17:00h", StartHourSunday = "CLOSED", EndHourSunday = "CLOSED", RoomId = 6 },
                new Form() { Id = 7, Name = "302,Opsta nega", Description = "Kreveti i sve potrebno za oporavku", StartHourWorkDay = "10:00h", EndHourWorkDay = "17:00h", StartHourSaturday = "12:00h", EndHourSaturday = "17:00h", StartHourSunday = "CLOSED", EndHourSunday = "CLOSED", RoomId = 7 },
                new Form() { Id = 8, Name = "303,Cekaonica", Description = "Stolice i fotelje za cekanje", StartHourWorkDay = "10:00h", EndHourWorkDay = "17:00h", StartHourSaturday = "12:00h", EndHourSaturday = "17:00h", StartHourSunday = "CLOSED", EndHourSunday = "CLOSED", RoomId = 8 },
                new Form() { Id = 9, Name = "101a,Kardiologija", Description = "...", StartHourWorkDay = "10:00h", EndHourWorkDay = "17:00h", StartHourSaturday = "12:00h", EndHourSaturday = "17:00h", StartHourSunday = "CLOSED", EndHourSunday = "CLOSED", RoomId = 9 },
                new Form() { Id = 10, Name = "102a,Vaskularne bolesti", Description = "...", StartHourWorkDay = "10:00h", EndHourWorkDay = "17:00h", StartHourSaturday = "12:00h", EndHourSaturday = "17:00h", StartHourSunday = "CLOSED", EndHourSunday = "CLOSED", RoomId = 10 },
                new Form() { Id = 11, Name = "103a,Hirurgija", Description = "...,...,...", StartHourWorkDay = "10:00h", EndHourWorkDay = "17:00h", StartHourSaturday = "12:00h", EndHourSaturday = "17:00h", StartHourSunday = "CLOSED", EndHourSunday = "CLOSED", RoomId = 11 },
                new Form() { Id = 12, Name = "201a,Papirologija", Description = "... ... ... ...", StartHourWorkDay = "10:00h", EndHourWorkDay = "17:00h", StartHourSaturday = "12:00h", EndHourSaturday = "17:00h", StartHourSunday = "CLOSED", EndHourSunday = "CLOSED", RoomId = 12 },
                new Form() { Id = 13, Name = "202a,Prijavna soba", Description = "...", StartHourWorkDay = "10:00h", EndHourWorkDay = "17:00h", StartHourSaturday = "12:00h", EndHourSaturday = "17:00h", StartHourSunday = "CLOSED", EndHourSunday = "CLOSED", RoomId = 13 },
                new Form() { Id = 14, Name = "203a,Uplasta/isplata", Description = "...", StartHourWorkDay = "10:00h", EndHourWorkDay = "17:00h", StartHourSaturday = "12:00h", EndHourSaturday = "17:00h", StartHourSunday = "CLOSED", EndHourSunday = "CLOSED", RoomId = 14 },
                new Form() { Id = 15, Name = "204a,Izgubljeno/nadjeno", Description = "...", StartHourWorkDay = "10:00h", EndHourWorkDay = "17:00h", StartHourSaturday = "12:00h", EndHourSaturday = "17:00h", StartHourSunday = "CLOSED", EndHourSunday = "CLOSED", RoomId = 15 },
                new Form() { Id = 16, Name = "101b,Onkologija", Description = "...", StartHourWorkDay = "10:00h", EndHourWorkDay = "17:00h", StartHourSaturday = "12:00h", EndHourSaturday = "17:00h", StartHourSunday = "CLOSED", EndHourSunday = "CLOSED", RoomId = 16 },
                new Form() { Id = 17, Name = "102b,Endokrinologija", Description = "Operacija endokrinog sistema", StartHourWorkDay = "10:00h", EndHourWorkDay = "17:00h", StartHourSaturday = "12:00h", EndHourSaturday = "17:00h", StartHourSunday = "CLOSED", EndHourSunday = "CLOSED", RoomId = 17 },
                new Form() { Id = 18, Name = "201b,Gastronomija", Description = "...", StartHourWorkDay = "10:00h", EndHourWorkDay = "17:00h", StartHourSaturday = "12:00h", EndHourSaturday = "17:00h", StartHourSunday = "CLOSED", EndHourSunday = "CLOSED", RoomId = 18 },
                new Form() { Id = 19, Name = "301b,Magacin", Description = "...", StartHourWorkDay = "10:00h", EndHourWorkDay = "17:00h", StartHourSaturday = "12:00h", EndHourSaturday = "17:00h", StartHourSunday = "CLOSED", EndHourSunday = "CLOSED", RoomId = 19 });

            modelBuilder.Entity<Equipment>().HasData(
               new Equipment() { Id = 1, Name = "Krevet", Amount = 2, RoomId = 1 },
               new Equipment() { Id = 2, Name = "Stetoskop", Amount = 2, RoomId = 1 },
               new Equipment() { Id = 3, Name = "Stolica", Amount = 4, RoomId = 1 },
               new Equipment() { Id = 4, Name = "Stolica", Amount = 20, RoomId = 2 },
               new Equipment() { Id = 5, Name = "Aparat za kafu", Amount = 2, RoomId = 2 },
               new Equipment() { Id = 6, Name = "Fotelja", Amount = 4, RoomId = 2 },
               new Equipment() { Id = 7, Name = "Busilica", Amount = 2, RoomId = 3 },
               new Equipment() { Id = 8, Name = "Otoskop", Amount = 3, RoomId = 3 },
               new Equipment() { Id = 9, Name = "Stetoskop", Amount = 2, RoomId = 4 },
               new Equipment() { Id = 10, Name = "Bolnicki krevet", Amount = 3, RoomId = 4 },
               new Equipment() { Id = 11, Name = "Aparat za merenje pritiska", Amount = 2, RoomId = 4 },
               new Equipment() { Id = 12, Name = "Stolica", Amount = 4, RoomId = 5 },
               new Equipment() { Id = 13, Name = "Zavoji", Amount = 50, RoomId = 6 },
               new Equipment() { Id = 14, Name = "Spricevi", Amount = 24, RoomId = 6 },
               new Equipment() { Id = 15, Name = "Gips", Amount = 12, RoomId = 6 },
               new Equipment() { Id = 16, Name = "Flasteri", Amount = 200, RoomId = 6 },
               new Equipment() { Id = 17, Name = "Bolnicki krevet", Amount = 20, RoomId = 7 },
               new Equipment() { Id = 18, Name = "Infuzija", Amount = 20, RoomId = 7 },
               new Equipment() { Id = 19, Name = "Stolica", Amount = 20, RoomId = 8 },
               new Equipment() { Id = 20, Name = "Stetoskop", Amount = 2, RoomId = 9 },
               new Equipment() { Id = 21, Name = "Stolica", Amount = 4, RoomId = 10 },
               new Equipment() { Id = 22, Name = "Krevet", Amount = 2, RoomId = 11 },
               new Equipment() { Id = 23, Name = "Stetoskop", Amount = 2, RoomId = 12 },
               new Equipment() { Id = 24, Name = "Infuzija", Amount = 4, RoomId = 13 },
               new Equipment() { Id = 25, Name = "Fotelja", Amount = 1, RoomId = 13 },
               new Equipment() { Id = 26, Name = "Stolica", Amount = 20, RoomId = 13 }
           );
        }
    }
}
