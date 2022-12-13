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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Therapies",
                keyColumn: "Id",
                keyValue: 1,
                column: "WhenPrescribed",
                value: new DateTime(2022, 12, 12, 10, 50, 15, 307, DateTimeKind.Utc).AddTicks(6553));

            migrationBuilder.UpdateData(
                table: "Therapies",
                keyColumn: "Id",
                keyValue: 2,
                column: "WhenPrescribed",
                value: new DateTime(2022, 12, 12, 10, 50, 15, 307, DateTimeKind.Utc).AddTicks(6554));

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 12, 12, 10, 50, 15, 307, DateTimeKind.Utc).AddTicks(6525), new DateTime(2022, 12, 12, 10, 50, 15, 307, DateTimeKind.Utc).AddTicks(6525) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 12, 12, 10, 50, 15, 307, DateTimeKind.Utc).AddTicks(6529), new DateTime(2022, 12, 12, 10, 50, 15, 307, DateTimeKind.Utc).AddTicks(6528) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 12, 12, 10, 50, 15, 307, DateTimeKind.Utc).AddTicks(6530), new DateTime(2022, 12, 12, 10, 50, 15, 307, DateTimeKind.Utc).AddTicks(6530) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 4,
                column: "StartDate",
                value: new DateTime(2022, 12, 12, 10, 50, 15, 307, DateTimeKind.Utc).AddTicks(6531));

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 5,
                column: "StartDate",
                value: new DateTime(2022, 12, 12, 10, 50, 15, 307, DateTimeKind.Utc).AddTicks(6532));

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 6,
                column: "StartDate",
                value: new DateTime(2022, 12, 12, 10, 50, 15, 307, DateTimeKind.Utc).AddTicks(6532));
        }
    }
}
