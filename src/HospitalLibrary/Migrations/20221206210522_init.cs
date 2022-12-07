using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalLibrary.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Therapies",
                keyColumn: "Id",
                keyValue: 1,
                column: "WhenPrescribed",
                value: new DateTime(2022, 12, 6, 21, 5, 21, 346, DateTimeKind.Utc).AddTicks(9666));

            migrationBuilder.UpdateData(
                table: "Therapies",
                keyColumn: "Id",
                keyValue: 2,
                column: "WhenPrescribed",
                value: new DateTime(2022, 12, 6, 21, 5, 21, 346, DateTimeKind.Utc).AddTicks(9670));

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 12, 6, 21, 5, 21, 346, DateTimeKind.Utc).AddTicks(9596), new DateTime(2022, 12, 6, 21, 5, 21, 346, DateTimeKind.Utc).AddTicks(9595) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 12, 6, 21, 5, 21, 346, DateTimeKind.Utc).AddTicks(9601), new DateTime(2022, 12, 6, 21, 5, 21, 346, DateTimeKind.Utc).AddTicks(9601) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 12, 6, 21, 5, 21, 346, DateTimeKind.Utc).AddTicks(9603), new DateTime(2022, 12, 6, 21, 5, 21, 346, DateTimeKind.Utc).AddTicks(9603) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 4,
                column: "StartDate",
                value: new DateTime(2022, 12, 6, 21, 5, 21, 346, DateTimeKind.Utc).AddTicks(9605));

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 5,
                column: "StartDate",
                value: new DateTime(2022, 12, 6, 21, 5, 21, 346, DateTimeKind.Utc).AddTicks(9606));

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 6,
                column: "StartDate",
                value: new DateTime(2022, 12, 6, 21, 5, 21, 346, DateTimeKind.Utc).AddTicks(9608));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Therapies",
                keyColumn: "Id",
                keyValue: 1,
                column: "WhenPrescribed",
                value: new DateTime(2022, 12, 6, 11, 36, 22, 933, DateTimeKind.Utc).AddTicks(3006));

            migrationBuilder.UpdateData(
                table: "Therapies",
                keyColumn: "Id",
                keyValue: 2,
                column: "WhenPrescribed",
                value: new DateTime(2022, 12, 6, 11, 36, 22, 933, DateTimeKind.Utc).AddTicks(3007));

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 12, 6, 11, 36, 22, 933, DateTimeKind.Utc).AddTicks(2975), new DateTime(2022, 12, 6, 11, 36, 22, 933, DateTimeKind.Utc).AddTicks(2974) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 12, 6, 11, 36, 22, 933, DateTimeKind.Utc).AddTicks(2978), new DateTime(2022, 12, 6, 11, 36, 22, 933, DateTimeKind.Utc).AddTicks(2978) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 12, 6, 11, 36, 22, 933, DateTimeKind.Utc).AddTicks(2979), new DateTime(2022, 12, 6, 11, 36, 22, 933, DateTimeKind.Utc).AddTicks(2979) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 4,
                column: "StartDate",
                value: new DateTime(2022, 12, 6, 11, 36, 22, 933, DateTimeKind.Utc).AddTicks(2980));

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 5,
                column: "StartDate",
                value: new DateTime(2022, 12, 6, 11, 36, 22, 933, DateTimeKind.Utc).AddTicks(2980));

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 6,
                column: "StartDate",
                value: new DateTime(2022, 12, 6, 11, 36, 22, 933, DateTimeKind.Utc).AddTicks(2981));
        }
    }
}
