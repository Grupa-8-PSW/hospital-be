using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalLibrary.Migrations
{
    public partial class _ExaminationsUpdatedMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Examinations",
                keyColumn: "Id",
                keyValue: 1,
                column: "Duration",
                value: 300);

            migrationBuilder.UpdateData(
                table: "Examinations",
                keyColumn: "Id",
                keyValue: 2,
                column: "StartTime",
                value: new DateTime(2022, 11, 22, 7, 30, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Examinations",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Duration", "StartTime" },
                values: new object[] { 420, new DateTime(2022, 11, 22, 11, 30, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Examinations",
                keyColumn: "Id",
                keyValue: 4,
                column: "StartTime",
                value: new DateTime(2022, 11, 22, 20, 30, 0, 0, DateTimeKind.Utc));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Examinations",
                keyColumn: "Id",
                keyValue: 1,
                column: "Duration",
                value: 30);

            migrationBuilder.UpdateData(
                table: "Examinations",
                keyColumn: "Id",
                keyValue: 2,
                column: "StartTime",
                value: new DateTime(2022, 11, 22, 5, 30, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Examinations",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Duration", "StartTime" },
                values: new object[] { 60, new DateTime(2022, 11, 22, 9, 30, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Examinations",
                keyColumn: "Id",
                keyValue: 4,
                column: "StartTime",
                value: new DateTime(2022, 11, 22, 12, 30, 0, 0, DateTimeKind.Utc));
        }
    }
}
