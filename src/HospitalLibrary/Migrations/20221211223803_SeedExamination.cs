using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalLibrary.Migrations
{
    public partial class SeedExamination : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Examinations",
                columns: new[] { "Id", "DoctorId", "Duration", "PatientId", "RoomId", "StartTime" },
                values: new object[] { 1, 1, 20, 1, 1, new DateTime(2022, 12, 11, 22, 37, 58, 42, DateTimeKind.Utc).AddTicks(1216) });

            migrationBuilder.UpdateData(
                table: "Therapies",
                keyColumn: "Id",
                keyValue: 1,
                column: "WhenPrescribed",
                value: new DateTime(2022, 12, 11, 22, 37, 58, 42, DateTimeKind.Utc).AddTicks(945));

            migrationBuilder.UpdateData(
                table: "Therapies",
                keyColumn: "Id",
                keyValue: 2,
                column: "WhenPrescribed",
                value: new DateTime(2022, 12, 11, 22, 37, 58, 42, DateTimeKind.Utc).AddTicks(952));

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 12, 11, 22, 37, 58, 42, DateTimeKind.Utc).AddTicks(497), new DateTime(2022, 12, 11, 22, 37, 58, 42, DateTimeKind.Utc).AddTicks(495) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 12, 11, 22, 37, 58, 42, DateTimeKind.Utc).AddTicks(514), new DateTime(2022, 12, 11, 22, 37, 58, 42, DateTimeKind.Utc).AddTicks(514) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 12, 11, 22, 37, 58, 42, DateTimeKind.Utc).AddTicks(520), new DateTime(2022, 12, 11, 22, 37, 58, 42, DateTimeKind.Utc).AddTicks(519) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 4,
                column: "StartDate",
                value: new DateTime(2022, 12, 11, 22, 37, 58, 42, DateTimeKind.Utc).AddTicks(709));

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 5,
                column: "StartDate",
                value: new DateTime(2022, 12, 11, 22, 37, 58, 42, DateTimeKind.Utc).AddTicks(719));

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 6,
                column: "StartDate",
                value: new DateTime(2022, 12, 11, 22, 37, 58, 42, DateTimeKind.Utc).AddTicks(723));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Examinations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "Therapies",
                keyColumn: "Id",
                keyValue: 1,
                column: "WhenPrescribed",
                value: new DateTime(2022, 12, 8, 1, 4, 9, 992, DateTimeKind.Utc).AddTicks(4395));

            migrationBuilder.UpdateData(
                table: "Therapies",
                keyColumn: "Id",
                keyValue: 2,
                column: "WhenPrescribed",
                value: new DateTime(2022, 12, 8, 1, 4, 9, 992, DateTimeKind.Utc).AddTicks(4406));

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 12, 8, 1, 4, 9, 992, DateTimeKind.Utc).AddTicks(4131), new DateTime(2022, 12, 8, 1, 4, 9, 992, DateTimeKind.Utc).AddTicks(4127) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 12, 8, 1, 4, 9, 992, DateTimeKind.Utc).AddTicks(4152), new DateTime(2022, 12, 8, 1, 4, 9, 992, DateTimeKind.Utc).AddTicks(4151) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 12, 8, 1, 4, 9, 992, DateTimeKind.Utc).AddTicks(4159), new DateTime(2022, 12, 8, 1, 4, 9, 992, DateTimeKind.Utc).AddTicks(4158) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 4,
                column: "StartDate",
                value: new DateTime(2022, 12, 8, 1, 4, 9, 992, DateTimeKind.Utc).AddTicks(4161));

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 5,
                column: "StartDate",
                value: new DateTime(2022, 12, 8, 1, 4, 9, 992, DateTimeKind.Utc).AddTicks(4166));

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 6,
                column: "StartDate",
                value: new DateTime(2022, 12, 8, 1, 4, 9, 992, DateTimeKind.Utc).AddTicks(4169));
        }
    }
}
