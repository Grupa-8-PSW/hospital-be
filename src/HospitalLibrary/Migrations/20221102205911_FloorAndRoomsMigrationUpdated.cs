using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalLibrary.Migrations
{
    public partial class FloorAndRoomsMigrationUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Floors",
                keyColumn: "Id",
                keyValue: 1,
                column: "BuildingId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Floors",
                keyColumn: "Id",
                keyValue: 2,
                column: "Y",
                value: 170);

            migrationBuilder.UpdateData(
                table: "Floors",
                keyColumn: "Id",
                keyValue: 3,
                column: "Y",
                value: 70);

            migrationBuilder.UpdateData(
                table: "Floors",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "BuildingId", "Number", "Y" },
                values: new object[] { 2, "Floor 1", 270 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Floors",
                keyColumn: "Id",
                keyValue: 1,
                column: "BuildingId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Floors",
                keyColumn: "Id",
                keyValue: 2,
                column: "Y",
                value: 270);

            migrationBuilder.UpdateData(
                table: "Floors",
                keyColumn: "Id",
                keyValue: 3,
                column: "Y",
                value: 170);

            migrationBuilder.UpdateData(
                table: "Floors",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "BuildingId", "Number", "Y" },
                values: new object[] { 1, "Floor 4", 70 });
        }
    }
}
