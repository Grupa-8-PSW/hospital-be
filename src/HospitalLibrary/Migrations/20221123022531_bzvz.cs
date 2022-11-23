using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalLibrary.Migrations
{
    public partial class bzvz : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Examinations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Duration", "StartTime" },
                values: new object[] { 30, new DateTime(2022, 11, 22, 2, 0, 0, 0, DateTimeKind.Utc) });

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
                columns: new[] { "Duration", "StartTime" },
                values: new object[] { 150, new DateTime(2022, 11, 22, 12, 30, 0, 0, DateTimeKind.Utc) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Examinations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Duration", "StartTime" },
                values: new object[] { 180, new DateTime(2022, 11, 22, 10, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Examinations",
                keyColumn: "Id",
                keyValue: 2,
                column: "StartTime",
                value: new DateTime(2022, 11, 21, 12, 30, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Examinations",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Duration", "StartTime" },
                values: new object[] { 300, new DateTime(2022, 11, 23, 4, 30, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Examinations",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Duration", "StartTime" },
                values: new object[] { 60, new DateTime(2022, 11, 21, 5, 30, 0, 0, DateTimeKind.Utc) });
        }
    }
}
