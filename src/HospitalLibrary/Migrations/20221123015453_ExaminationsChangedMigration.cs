using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalLibrary.Migrations
{
    public partial class ExaminationsChangedMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Examinations",
                keyColumn: "Id",
                keyValue: 1,
                column: "Duration",
                value: 180);

            migrationBuilder.UpdateData(
                table: "Examinations",
                keyColumn: "Id",
                keyValue: 2,
                column: "Duration",
                value: 120);

            migrationBuilder.UpdateData(
                table: "Examinations",
                keyColumn: "Id",
                keyValue: 5,
                column: "Duration",
                value: 90);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Examinations",
                keyColumn: "Id",
                keyValue: 1,
                column: "Duration",
                value: 200);

            migrationBuilder.UpdateData(
                table: "Examinations",
                keyColumn: "Id",
                keyValue: 2,
                column: "Duration",
                value: 100);

            migrationBuilder.UpdateData(
                table: "Examinations",
                keyColumn: "Id",
                keyValue: 5,
                column: "Duration",
                value: 60);
        }
    }
}
