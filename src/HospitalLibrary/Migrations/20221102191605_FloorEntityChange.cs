using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalLibrary.Migrations
{
    public partial class FloorEntityChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Floors",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Height",
                table: "Floors",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Width",
                table: "Floors",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "X",
                table: "Floors",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Y",
                table: "Floors",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Floors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Color", "Height", "Number", "Width", "X", "Y" },
                values: new object[] { "white", 100, "Floor 3", 300, 100, 70 });

            migrationBuilder.UpdateData(
                table: "Floors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Color", "Height", "Number", "Width", "X", "Y" },
                values: new object[] { "white", 100, "Floor 2", 300, 100, 170 });

            migrationBuilder.UpdateData(
                table: "Floors",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Color", "Height", "Number", "Width", "X", "Y" },
                values: new object[] { "white", 100, "floor 1", 300, 100, 270 });

            migrationBuilder.UpdateData(
                table: "Floors",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Color", "Height", "Number", "Width", "X", "Y" },
                values: new object[] { "white", 100, "floor 1", 300, 100, 270 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "Floors");

            migrationBuilder.DropColumn(
                name: "Height",
                table: "Floors");

            migrationBuilder.DropColumn(
                name: "Width",
                table: "Floors");

            migrationBuilder.DropColumn(
                name: "X",
                table: "Floors");

            migrationBuilder.DropColumn(
                name: "Y",
                table: "Floors");

            migrationBuilder.UpdateData(
                table: "Floors",
                keyColumn: "Id",
                keyValue: 1,
                column: "Number",
                value: "One");

            migrationBuilder.UpdateData(
                table: "Floors",
                keyColumn: "Id",
                keyValue: 2,
                column: "Number",
                value: "Too");

            migrationBuilder.UpdateData(
                table: "Floors",
                keyColumn: "Id",
                keyValue: 3,
                column: "Number",
                value: "Tre");

            migrationBuilder.UpdateData(
                table: "Floors",
                keyColumn: "Id",
                keyValue: 4,
                column: "Number",
                value: "Noo");
        }
    }
}
