using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalLibrary.Migrations
{
    public partial class AllFloorsAddedMigraton : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Floors",
                columns: new[] { "Id", "BuildingId", "Color", "Height", "Number", "Width", "X", "Y" },
                values: new object[,]
                {
                    { 5, 2, "white", 100, "Floor 2", 300, 100, 170 },
                    { 6, 3, "white", 100, "Floor 1", 300, 100, 270 },
                    { 7, 3, "white", 100, "Floor 2", 300, 100, 170 },
                    { 8, 3, "white", 100, "Floor 3", 300, 100, 70 }
                });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Thre");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Four");

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "Color", "FloorId", "Height", "Name", "Width", "X", "Y" },
                values: new object[,]
                {
                    { 5, "blue", 2, 180, "Five", 360, 0, 0 },
                    { 6, "blue", 3, 180, "Six", 260, 0, 0 },
                    { 7, "blue", 3, 140, "Seven", 220, 0, 138 },
                    { 8, "blue", 4, 140, "Seven", 220, 0, 138 },
                    { 9, "blue", 5, 140, "Seven", 220, 0, 138 },
                    { 10, "blue", 6, 140, "Seven", 220, 0, 138 },
                    { 11, "blue", 7, 140, "Seven", 220, 0, 138 },
                    { 12, "blue", 8, 140, "Seven", 220, 0, 138 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Floors",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Floors",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Floors",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Floors",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Tre");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Tre");
        }
    }
}
