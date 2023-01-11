using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalLibrary.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Therapies",
                keyColumn: "Id",
                keyValue: 1,
                column: "WhenPrescribed",
                value: new DateTime(2023, 1, 10, 15, 35, 37, 408, DateTimeKind.Utc).AddTicks(3911));

            migrationBuilder.UpdateData(
                table: "Therapies",
                keyColumn: "Id",
                keyValue: 2,
                column: "WhenPrescribed",
                value: new DateTime(2023, 1, 10, 15, 35, 37, 408, DateTimeKind.Utc).AddTicks(3914));

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 1, 10, 15, 35, 37, 408, DateTimeKind.Utc).AddTicks(3799), new DateTime(2023, 1, 10, 15, 35, 37, 408, DateTimeKind.Utc).AddTicks(3797) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 1, 10, 15, 35, 37, 408, DateTimeKind.Utc).AddTicks(3804), new DateTime(2023, 1, 10, 15, 35, 37, 408, DateTimeKind.Utc).AddTicks(3804) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 1, 10, 15, 35, 37, 408, DateTimeKind.Utc).AddTicks(3806), new DateTime(2023, 1, 10, 15, 35, 37, 408, DateTimeKind.Utc).AddTicks(3806) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 4,
                column: "StartDate",
                value: new DateTime(2023, 1, 10, 15, 35, 37, 408, DateTimeKind.Utc).AddTicks(3808));

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 5,
                column: "StartDate",
                value: new DateTime(2023, 1, 10, 15, 35, 37, 408, DateTimeKind.Utc).AddTicks(3809));

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 6,
                column: "StartDate",
                value: new DateTime(2023, 1, 10, 15, 35, 37, 408, DateTimeKind.Utc).AddTicks(3810));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Therapies",
                keyColumn: "Id",
                keyValue: 1,
                column: "WhenPrescribed",
                value: new DateTime(2023, 1, 9, 15, 30, 6, 972, DateTimeKind.Utc).AddTicks(3508));

            migrationBuilder.UpdateData(
                table: "Therapies",
                keyColumn: "Id",
                keyValue: 2,
                column: "WhenPrescribed",
                value: new DateTime(2023, 1, 9, 15, 30, 6, 972, DateTimeKind.Utc).AddTicks(3510));

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 1, 9, 15, 30, 6, 972, DateTimeKind.Utc).AddTicks(3473), new DateTime(2023, 1, 9, 15, 30, 6, 972, DateTimeKind.Utc).AddTicks(3472) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 1, 9, 15, 30, 6, 972, DateTimeKind.Utc).AddTicks(3476), new DateTime(2023, 1, 9, 15, 30, 6, 972, DateTimeKind.Utc).AddTicks(3475) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 1, 9, 15, 30, 6, 972, DateTimeKind.Utc).AddTicks(3477), new DateTime(2023, 1, 9, 15, 30, 6, 972, DateTimeKind.Utc).AddTicks(3477) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 4,
                column: "StartDate",
                value: new DateTime(2023, 1, 9, 15, 30, 6, 972, DateTimeKind.Utc).AddTicks(3478));

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 5,
                column: "StartDate",
                value: new DateTime(2023, 1, 9, 15, 30, 6, 972, DateTimeKind.Utc).AddTicks(3479));

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 6,
                column: "StartDate",
                value: new DateTime(2023, 1, 9, 15, 30, 6, 972, DateTimeKind.Utc).AddTicks(3479));
        }
    }
}
