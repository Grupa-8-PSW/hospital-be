using HospitalLibrary.GraphicalEditor.Model.Map;
using HospitalLibrary.GraphicalEditor.Model;
using Microsoft.EntityFrameworkCore;
using HospitalLibrary.Core.Enums;
using HospitalLibrary.Core.Model;

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

            modelBuilder.Entity<Doctor>().HasData(
                new Doctor() { Id = 1, FirstName = "Pera", LastName = "Peric", RoomId = 1, StartWork = new DateTime(2022, 11, 22, 10, 10, 10, DateTimeKind.Utc), EndWork = new DateTime(2022, 11, 22, 18, 10, 10, DateTimeKind.Utc) },
                new Doctor() { Id = 2, FirstName = "Sergej", LastName = "Milinkovic-Savic", RoomId = 1, StartWork = new DateTime(2022, 11, 22, 10, 10, 10, DateTimeKind.Utc), EndWork = new DateTime(2022, 11, 22, 19, 10, 10, DateTimeKind.Utc) }
             );

            modelBuilder.Entity<Examination>().HasData(
                new Examination() { Id = 1, DoctorId = 1, PatientId = 1, RoomId = 1,  StartTime = new DateTime(2022, 11, 22, 2, 00, 00, DateTimeKind.Utc), Duration = 300 },
                new Examination() { Id = 2, DoctorId = 2, PatientId = 2, RoomId = 2, StartTime = new DateTime(2022, 11, 22, 7, 30, 00, DateTimeKind.Utc), Duration = 120 },
                new Examination() { Id = 3, DoctorId = 1, PatientId = 3, RoomId = 1, StartTime = new DateTime(2022, 11, 22, 11, 30, 00, DateTimeKind.Utc), Duration = 420 },
                new Examination() { Id = 4, DoctorId = 2, PatientId = 4, RoomId = 2, StartTime = new DateTime(2022, 11, 22, 20, 30, 00, DateTimeKind.Utc), Duration = 150 }
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
                new Room() { Id = 1, X = 0, Y = 0, Width = 260, Height = 160, Color = "blue", Name = "Neurohirurgija", FloorId = 1, Type = RoomType.OPERATIONS },
                new Room() { Id = 2, X = 0, Y = 338, Width = 220, Height = 140, Color = "blue", Name = "Kafeterija", FloorId = 1, Type = RoomType.CAFETERIA },
                new Room() { Id = 3, X = 237, Y = 0, Width = 300, Height = 180, Color = "blue", Name = "Otorinolaringologija", FloorId = 1 , Type = RoomType.OTHER},
                new Room() { Id = 4, X = 270, Y = 378, Width = 200, Height = 100, Color = "blue", Name = "Fizioterapeut", FloorId = 2 , Type = RoomType.OTHER },
                new Room() { Id = 5, X = 0, Y = 0, Width = 360, Height = 180, Color = "blue", Name = "Stomatologija", FloorId = 2 , Type = RoomType.OTHER },
                new Room() { Id = 6, X = 0, Y = 0, Width = 260, Height = 180, Color = "blue", Name = "Magacin", FloorId = 3 , Type = RoomType.MAGAZINE },
                new Room() { Id = 7, X = 0, Y = 338, Width = 220, Height = 140, Color = "blue", Name = "Opsta nega", FloorId = 3, Type = RoomType.OTHER },
                new Room() { Id = 8, X = 330, Y = 158, Width = 220, Height = 140, Color = "blue", Name = "Cekaonica", FloorId = 3, Type = RoomType.OTHER },
                new Room() { Id = 9, X = 0, Y = 0, Width = 320, Height = 170, Color = "blue", Name = "Kardiologija", FloorId = 4, Type = RoomType.OPERATIONS },
                new Room() { Id = 10, X = 0, Y = 365, Width = 220, Height = 140, Color = "blue", Name = "Vaskularne bolesti", FloorId = 4, Type = RoomType.OTHER },
                new Room() { Id = 11, X = 245, Y = 0, Width = 220, Height = 140, Color = "blue", Name = "Hirurgija", FloorId = 4 , Type = RoomType.OPERATIONS },
                new Room() { Id = 12, X = 0, Y = 0, Width = 220, Height = 140, Color = "blue", Name = "Papirologija", FloorId = 5 , Type = RoomType.OTHER },
                new Room() { Id = 13, X = 200, Y = 0, Width = 220, Height = 140, Color = "blue", Name = "Prijavna soba", FloorId = 5 , Type = RoomType.OTHER },
                new Room() { Id = 14, X = 0, Y = 350, Width = 220, Height = 140, Color = "blue", Name = "Uplasta/isplata", FloorId = 5 , Type = RoomType.OTHER},
                new Room() { Id = 15, X = 200, Y = 350, Width = 220, Height = 140, Color = "blue", Name = "Izgubljeno/nadjeno", FloorId = 5, Type= RoomType.OTHER},
                new Room() { Id = 16, X = 0, Y = 0, Width = 320, Height = 190, Color = "blue", Name = "Onkologija", FloorId = 6, Type = RoomType.OTHER },
                new Room() { Id = 17, X = 200, Y = 300, Width = 250, Height = 240, Color = "blue", Name = "Endokrinologija", FloorId = 6 , Type = RoomType.OPERATIONS},
                new Room() { Id = 18, X = 50, Y = 100, Width = 420, Height = 280, Color = "blue", Name = "Gastronomija", FloorId = 7, Type = RoomType.OTHER },
                new Room() { Id = 19, X = 100, Y = 138, Width = 320, Height = 170, Color = "blue", Name = "Magacin", FloorId = 8, Type = RoomType.MAGAZINE }
            );

                modelBuilder.Entity<Form>().HasData(
                new Form() { Id = 1, Name = "101,Neurohirurgija" , Description= "Neuroloske operacije i zahvati", StartHourWorkDay = "8:00h" , EndHourWorkDay = "17:00h" , StartHourSaturday = "12:00h" , EndHourSaturday = "17:00h" , StartHourSunday = "CLOSED" , EndHourSunday = "CLOSED", RoomId = 1 },
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
                new Form() { Id = 19, Name = "301b,Magacin", Description = "...", StartHourWorkDay = "10:00h", EndHourWorkDay = "17:00h", StartHourSaturday = "12:00h", EndHourSaturday = "17:00h", StartHourSunday = "CLOSED", EndHourSunday = "CLOSED", RoomId = 19 }            );

            modelBuilder.Entity<Equipment>().HasData(
               new Equipment() { EquipmentId = 1, Name = "Krevet", Amount = 2, RoomId = 1 },
               new Equipment() { EquipmentId = 2, Name = "Stetoskop", Amount = 2, RoomId = 1 },
               new Equipment() { EquipmentId = 3, Name = "Stolica", Amount = 4, RoomId = 1 },
               new Equipment() { EquipmentId = 4, Name = "Stolica", Amount = 20, RoomId = 2 },
               new Equipment() { EquipmentId = 5, Name = "Aparat za kafu", Amount = 2, RoomId = 2 },
               new Equipment() { EquipmentId = 6, Name = "Fotelja", Amount = 4, RoomId = 2 },
               new Equipment() { EquipmentId = 7, Name = "Spric za ispiranje usiju", Amount = 2, RoomId = 3 },
               new Equipment() { EquipmentId = 8, Name = "Otoskop", Amount = 3, RoomId = 3 },
               new Equipment() { EquipmentId = 9, Name = "Stetoskop", Amount = 2, RoomId = 4 },
               new Equipment() { EquipmentId = 10, Name = "Bolnicki krevet", Amount = 3, RoomId = 4 },
               new Equipment() { EquipmentId = 11, Name = "Aparat za merenje pritiska", Amount = 2, RoomId = 4 },
               new Equipment() { EquipmentId = 12, Name = "Stolica", Amount = 4, RoomId = 5 },
               new Equipment() { EquipmentId = 13, Name = "Zavoji", Amount = 50, RoomId = 6 },
               new Equipment() { EquipmentId = 14, Name = "Spricevi", Amount = 24, RoomId = 6 },
               new Equipment() { EquipmentId = 15, Name = "Gips", Amount = 12, RoomId = 6 },
               new Equipment() { EquipmentId = 16, Name = "Flasteri", Amount = 200, RoomId = 6 },
               new Equipment() { EquipmentId = 17, Name = "Bolnicki krevet", Amount = 20, RoomId = 7 },
               new Equipment() { EquipmentId = 18, Name = "Infuzija", Amount = 20, RoomId = 7 },
               new Equipment() { EquipmentId = 19, Name = "Stolica", Amount = 20, RoomId = 8 },
               new Equipment() { EquipmentId = 20, Name = "Stetoskop", Amount = 2, RoomId = 9 },
               new Equipment() { EquipmentId = 21, Name = "Stolica", Amount = 4, RoomId = 10 },
               new Equipment() { EquipmentId = 22, Name = "Krevet", Amount = 2, RoomId = 11 },
               new Equipment() { EquipmentId = 23, Name = "Stetoskop", Amount = 2, RoomId = 12 },
               new Equipment() { EquipmentId = 24, Name = "Infuzija", Amount = 4, RoomId = 13 },
               new Equipment() { EquipmentId = 25, Name = "Fotelja", Amount = 1, RoomId = 13 },
               new Equipment() { EquipmentId = 26, Name = "Stolica", Amount = 20, RoomId = 13 }
           );
        }
    }
}
