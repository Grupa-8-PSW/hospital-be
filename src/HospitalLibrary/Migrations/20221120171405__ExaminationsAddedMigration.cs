using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalLibrary.Migrations
{
    public partial class _ExaminationsAddedMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Examinations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Examinations",
                keyColumn: "Id",
                keyValue: 2);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Examinations",
                columns: new[] { "Id", "DoctorId", "Duration", "PatientId", "RoomId", "StartTime" },
                values: new object[,]
                {
                    { 1, 1, 120, 1, 1, new DateTime(2022, 11, 22, 2, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 2, 300, 2, 1, new DateTime(2022, 11, 22, 6, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }
    }
}
