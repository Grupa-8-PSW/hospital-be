using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalLibrary.Migrations
{
    public partial class AllBuildingsFloorsAndRoomsDatasUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Forms",
                columns: new[] { "Id", "Description", "EndHourSaturday", "EndHourSunday", "EndHourWorkDay", "Name", "RoomId", "StartHourSaturday", "StartHourSunday", "StartHourWorkDay" },
                values: new object[,]
                {
                    { 5, "Pregledi za decu", "17:00h", "CLOSED", "17:00h", "202,Stomatologija", 5, "12:00h", "CLOSED", "10:00h" },
                    { 6, "Stanje robe u objektu", "17:00h", "CLOSED", "17:00h", "301,Magacin", 6, "12:00h", "CLOSED", "10:00h" },
                    { 7, "Kreveti i sve potrebno za oporavku", "17:00h", "CLOSED", "17:00h", "302,Opsta nega", 7, "12:00h", "CLOSED", "10:00h" },
                    { 8, "Stolice i fotelje za cekanje", "17:00h", "CLOSED", "17:00h", "303,Cekaonica", 8, "12:00h", "CLOSED", "10:00h" },
                    { 9, "...", "17:00h", "CLOSED", "17:00h", "101a,Kardiologija", 9, "12:00h", "CLOSED", "10:00h" },
                    { 10, "...", "17:00h", "CLOSED", "17:00h", "102a,Vaskularne bolesti", 10, "12:00h", "CLOSED", "10:00h" },
                    { 11, "...,...,...", "17:00h", "CLOSED", "17:00h", "103a,Hirurgija", 11, "12:00h", "CLOSED", "10:00h" },
                    { 12, "... ... ... ...", "17:00h", "CLOSED", "17:00h", "201a,Papirologija", 12, "12:00h", "CLOSED", "10:00h" },
                    { 13, "...", "17:00h", "CLOSED", "17:00h", "202a,Prijavna soba", 13, "12:00h", "CLOSED", "10:00h" },
                    { 14, "...", "17:00h", "CLOSED", "17:00h", "203a,Uplasta/isplata", 14, "12:00h", "CLOSED", "10:00h" },
                    { 15, "...", "17:00h", "CLOSED", "17:00h", "204a,Izgubljeno/nadjeno", 15, "12:00h", "CLOSED", "10:00h" },
                    { 16, "...", "17:00h", "CLOSED", "17:00h", "101b,Onkologija", 16, "12:00h", "CLOSED", "10:00h" },
                    { 17, "...", "17:00h", "CLOSED", "17:00h", "102b,Pedijatrija", 17, "12:00h", "CLOSED", "10:00h" },
                    { 18, "...", "17:00h", "CLOSED", "17:00h", "201b,Gastronomija", 18, "12:00h", "CLOSED", "10:00h" },
                    { 19, "...", "17:00h", "CLOSED", "17:00h", "301b,Magacin", 19, "12:00h", "CLOSED", "10:00h" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Forms",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Forms",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Forms",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Forms",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Forms",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Forms",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Forms",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Forms",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Forms",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Forms",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Forms",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Forms",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Forms",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Forms",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Forms",
                keyColumn: "Id",
                keyValue: 19);
        }
    }
}
