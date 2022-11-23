using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalLibrary.Migrations
{
    public partial class Proba : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Examinations",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Examinations",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.UpdateData(
                table: "Examinations",
                keyColumn: "Id",
                keyValue: 3,
                column: "RoomId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Examinations",
                keyColumn: "Id",
                keyValue: 4,
                column: "RoomId",
                value: 2);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Examinations",
                keyColumn: "Id",
                keyValue: 3,
                column: "RoomId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Examinations",
                keyColumn: "Id",
                keyValue: 4,
                column: "RoomId",
                value: 4);

            migrationBuilder.InsertData(
                table: "Examinations",
                columns: new[] { "Id", "DoctorId", "Duration", "PatientId", "RoomId", "StartTime" },
                values: new object[,]
                {
                    { 5, 2, 90, 1, 1, new DateTime(2022, 11, 22, 11, 30, 0, 0, DateTimeKind.Utc) },
                    { 6, 2, 60, 2, 2, new DateTime(2022, 11, 23, 11, 30, 0, 0, DateTimeKind.Utc) }
                });
        }
    }
}
