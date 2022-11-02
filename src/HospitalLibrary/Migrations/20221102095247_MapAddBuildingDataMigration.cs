using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalLibrary.Migrations
{
    public partial class MapAddBuildingDataMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MapBuildings",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MapBuildings",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MapBuildings",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Buildings",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Height",
                table: "Buildings",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Width",
                table: "Buildings",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "X",
                table: "Buildings",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Y",
                table: "Buildings",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Color", "Height", "Width", "X", "Y" },
                values: new object[] { "gray", 150, 450, 100, 100 });

            migrationBuilder.UpdateData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Color", "Height", "Width", "X", "Y" },
                values: new object[] { "gray", 450, 150, 600, 100 });

            migrationBuilder.UpdateData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Color", "Height", "Width", "X", "Y" },
                values: new object[] { "gray", 130, 400, 400, 600 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "Buildings");

            migrationBuilder.DropColumn(
                name: "Height",
                table: "Buildings");

            migrationBuilder.DropColumn(
                name: "Width",
                table: "Buildings");

            migrationBuilder.DropColumn(
                name: "X",
                table: "Buildings");

            migrationBuilder.DropColumn(
                name: "Y",
                table: "Buildings");

            migrationBuilder.InsertData(
                table: "MapBuildings",
                columns: new[] { "Id", "BuildingId", "Color", "Height", "Width", "X", "Y" },
                values: new object[,]
                {
                    { 1, 1, "gray", 150, 450, 100, 100 },
                    { 2, 2, "gray", 450, 150, 600, 100 },
                    { 3, 3, "gray", 130, 400, 400, 600 }
                });
        }
    }
}
