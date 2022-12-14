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
                value: new DateTime(2022, 12, 14, 16, 18, 10, 100, DateTimeKind.Utc).AddTicks(6477));

            migrationBuilder.UpdateData(
                table: "Therapies",
                keyColumn: "Id",
                keyValue: 2,
                column: "WhenPrescribed",
                value: new DateTime(2022, 12, 14, 16, 18, 10, 100, DateTimeKind.Utc).AddTicks(6479));

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 12, 14, 16, 18, 10, 100, DateTimeKind.Utc).AddTicks(6424), new DateTime(2022, 12, 14, 16, 18, 10, 100, DateTimeKind.Utc).AddTicks(6423) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 12, 14, 16, 18, 10, 100, DateTimeKind.Utc).AddTicks(6429), new DateTime(2022, 12, 14, 16, 18, 10, 100, DateTimeKind.Utc).AddTicks(6429) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 12, 14, 16, 18, 10, 100, DateTimeKind.Utc).AddTicks(6431), new DateTime(2022, 12, 14, 16, 18, 10, 100, DateTimeKind.Utc).AddTicks(6430) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 4,
                column: "StartDate",
                value: new DateTime(2022, 12, 14, 16, 18, 10, 100, DateTimeKind.Utc).AddTicks(6432));

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 5,
                column: "StartDate",
                value: new DateTime(2022, 12, 14, 16, 18, 10, 100, DateTimeKind.Utc).AddTicks(6433));

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 6,
                column: "StartDate",
                value: new DateTime(2022, 12, 14, 16, 18, 10, 100, DateTimeKind.Utc).AddTicks(6434));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Therapies",
                keyColumn: "Id",
                keyValue: 1,
                column: "WhenPrescribed",
                value: new DateTime(2022, 12, 13, 11, 56, 32, 480, DateTimeKind.Utc).AddTicks(5482));

            migrationBuilder.UpdateData(
                table: "Therapies",
                keyColumn: "Id",
                keyValue: 2,
                column: "WhenPrescribed",
                value: new DateTime(2022, 12, 13, 11, 56, 32, 480, DateTimeKind.Utc).AddTicks(5484));

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 12, 13, 11, 56, 32, 480, DateTimeKind.Utc).AddTicks(5376), new DateTime(2022, 12, 13, 11, 56, 32, 480, DateTimeKind.Utc).AddTicks(5376) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 12, 13, 11, 56, 32, 480, DateTimeKind.Utc).AddTicks(5382), new DateTime(2022, 12, 13, 11, 56, 32, 480, DateTimeKind.Utc).AddTicks(5381) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 12, 13, 11, 56, 32, 480, DateTimeKind.Utc).AddTicks(5384), new DateTime(2022, 12, 13, 11, 56, 32, 480, DateTimeKind.Utc).AddTicks(5383) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 4,
                column: "StartDate",
                value: new DateTime(2022, 12, 13, 11, 56, 32, 480, DateTimeKind.Utc).AddTicks(5385));

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 5,
                column: "StartDate",
                value: new DateTime(2022, 12, 13, 11, 56, 32, 480, DateTimeKind.Utc).AddTicks(5387));

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 6,
                column: "StartDate",
                value: new DateTime(2022, 12, 13, 11, 56, 32, 480, DateTimeKind.Utc).AddTicks(5388));
        }
    }
}
