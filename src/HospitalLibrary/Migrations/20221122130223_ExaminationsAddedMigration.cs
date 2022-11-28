using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalLibrary.Migrations
{
    public partial class ExaminationsAddedMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Examinations",
                keyColumn: "Id",
                keyValue: 2,
                column: "StartTime",
                value: new DateTime(2022, 11, 21, 7, 30, 0, 0, DateTimeKind.Utc));

            migrationBuilder.InsertData(
                table: "Examinations",
                columns: new[] { "Id", "DoctorId", "Duration", "PatientId", "RoomId", "StartTime" },
                values: new object[,]
                {
                    { 3, 1, 300, 3, 3, new DateTime(2022, 11, 25, 7, 30, 0, 0, DateTimeKind.Utc) },
                    { 4, 2, 60, 4, 4, new DateTime(2022, 11, 25, 7, 30, 0, 0, DateTimeKind.Utc) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Examinations",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Examinations",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "Examinations",
                keyColumn: "Id",
                keyValue: 2,
                column: "StartTime",
                value: new DateTime(2022, 11, 17, 7, 30, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
