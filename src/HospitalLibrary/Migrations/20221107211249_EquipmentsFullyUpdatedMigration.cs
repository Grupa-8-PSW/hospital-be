using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalLibrary.Migrations
{
    public partial class EquipmentsFullyUpdatedMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Equipments",
                columns: new[] { "EquipmentId", "Amount", "Name", "RoomId" },
                values: new object[,]
                {
                    { 5, 2, "Aparat za kafu", 2 },
                    { 6, 4, "Fotelja", 2 },
                    { 7, 2, "Spric za ispiranje usiju", 3 },
                    { 8, 3, "Otoskop", 3 },
                    { 9, 2, "Stetoskop", 4 },
                    { 10, 3, "Bolnicki krevet", 4 },
                    { 11, 2, "Aparat za merenje pritiska", 4 },
                    { 12, 4, "Stolica", 5 },
                    { 13, 50, "Zavoji", 6 },
                    { 14, 24, "Spricevi", 6 },
                    { 15, 12, "Gips", 6 },
                    { 16, 200, "Flasteri", 6 },
                    { 17, 20, "Bolnicki krevet", 7 },
                    { 18, 20, "Infuzija", 7 },
                    { 19, 20, "Stolica", 8 },
                    { 20, 2, "Stetoskop", 9 },
                    { 21, 4, "Stolica", 10 },
                    { 22, 2, "Krevet", 11 },
                    { 23, 2, "Stetoskop", 12 },
                    { 24, 4, "Infuzija", 13 },
                    { 25, 1, "Fotelja", 13 },
                    { 26, 20, "Stolica", 13 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "EquipmentId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "EquipmentId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "EquipmentId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "EquipmentId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "EquipmentId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "EquipmentId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "EquipmentId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "EquipmentId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "EquipmentId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "EquipmentId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "EquipmentId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "EquipmentId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "EquipmentId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "EquipmentId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "EquipmentId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "EquipmentId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "EquipmentId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "EquipmentId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "EquipmentId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "EquipmentId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "EquipmentId",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "EquipmentId",
                keyValue: 26);
        }
    }
}
