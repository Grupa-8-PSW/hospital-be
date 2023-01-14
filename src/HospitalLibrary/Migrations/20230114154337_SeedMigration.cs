using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalLibrary.Migrations
{
    public partial class SeedMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Consiliums",
                columns: new[] { "Id", "Duration", "Subject", "Interval_End", "Interval_Start" },
                values: new object[,]
                {
                    { 1, 120, "New disease", new DateTime(2023, 1, 22, 16, 30, 0, 0, DateTimeKind.Utc), new DateTime(2023, 1, 22, 15, 30, 0, 0, DateTimeKind.Utc) },
                    { 2, 180, "Covid-19", new DateTime(2022, 10, 20, 12, 15, 0, 0, DateTimeKind.Utc), new DateTime(2022, 10, 20, 9, 15, 0, 0, DateTimeKind.Utc) }
                });

            migrationBuilder.InsertData(
                table: "ExaminationsDone",
                columns: new[] { "Id", "ExaminationId", "Record" },
                values: new object[,]
                {
                    { 1, 1, "Patient successfully recovered." },
                    { 2, 2, "Patient successfully recovered after having stomach problems." },
                    { 3, 3, "Patient feels great." }
                });

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Consiliums",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Consiliums",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ExaminationsDone",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ExaminationsDone",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ExaminationsDone",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
