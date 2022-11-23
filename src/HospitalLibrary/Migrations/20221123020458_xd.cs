using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalLibrary.Migrations
{
    public partial class xd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Examinations",
                keyColumn: "Id",
                keyValue: 1,
                column: "StartTime",
                value: new DateTime(2022, 11, 22, 10, 0, 0, 0, DateTimeKind.Utc));

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
                column: "StartTime",
                value: new DateTime(2022, 11, 23, 4, 30, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Examinations",
                keyColumn: "Id",
                keyValue: 4,
                column: "StartTime",
                value: new DateTime(2022, 11, 21, 5, 30, 0, 0, DateTimeKind.Utc));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Examinations",
                keyColumn: "Id",
                keyValue: 1,
                column: "StartTime",
                value: new DateTime(2022, 11, 22, 10, 10, 10, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Examinations",
                keyColumn: "Id",
                keyValue: 2,
                column: "StartTime",
                value: new DateTime(2022, 11, 21, 7, 30, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Examinations",
                keyColumn: "Id",
                keyValue: 3,
                column: "StartTime",
                value: new DateTime(2022, 11, 24, 4, 30, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Examinations",
                keyColumn: "Id",
                keyValue: 4,
                column: "StartTime",
                value: new DateTime(2022, 11, 25, 5, 30, 0, 0, DateTimeKind.Utc));
        }
    }
}
