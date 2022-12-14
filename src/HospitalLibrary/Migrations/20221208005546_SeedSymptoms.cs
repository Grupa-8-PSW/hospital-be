using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalLibrary.Migrations
{
    public partial class SeedSymptoms : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Therapies",
                keyColumn: "Id",
                keyValue: 1,
                column: "WhenPrescribed",
                value: new DateTime(2022, 12, 8, 0, 55, 36, 589, DateTimeKind.Utc).AddTicks(7520));

            migrationBuilder.UpdateData(
                table: "Therapies",
                keyColumn: "Id",
                keyValue: 2,
                column: "WhenPrescribed",
                value: new DateTime(2022, 12, 8, 0, 55, 36, 589, DateTimeKind.Utc).AddTicks(7528));

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 12, 8, 0, 55, 36, 589, DateTimeKind.Utc).AddTicks(6985), new DateTime(2022, 12, 8, 0, 55, 36, 589, DateTimeKind.Utc).AddTicks(6980) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 12, 8, 0, 55, 36, 589, DateTimeKind.Utc).AddTicks(6998), new DateTime(2022, 12, 8, 0, 55, 36, 589, DateTimeKind.Utc).AddTicks(6997) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 12, 8, 0, 55, 36, 589, DateTimeKind.Utc).AddTicks(7002), new DateTime(2022, 12, 8, 0, 55, 36, 589, DateTimeKind.Utc).AddTicks(7001) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 4,
                column: "StartDate",
                value: new DateTime(2022, 12, 8, 0, 55, 36, 589, DateTimeKind.Utc).AddTicks(7005));

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 5,
                column: "StartDate",
                value: new DateTime(2022, 12, 8, 0, 55, 36, 589, DateTimeKind.Utc).AddTicks(7009));

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 6,
                column: "StartDate",
                value: new DateTime(2022, 12, 8, 0, 55, 36, 589, DateTimeKind.Utc).AddTicks(7015));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Therapies",
                keyColumn: "Id",
                keyValue: 1,
                column: "WhenPrescribed",
                value: new DateTime(2022, 12, 7, 23, 54, 38, 341, DateTimeKind.Utc).AddTicks(7142));

            migrationBuilder.UpdateData(
                table: "Therapies",
                keyColumn: "Id",
                keyValue: 2,
                column: "WhenPrescribed",
                value: new DateTime(2022, 12, 7, 23, 54, 38, 341, DateTimeKind.Utc).AddTicks(7150));

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 12, 7, 23, 54, 38, 341, DateTimeKind.Utc).AddTicks(6870), new DateTime(2022, 12, 7, 23, 54, 38, 341, DateTimeKind.Utc).AddTicks(6867) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 12, 7, 23, 54, 38, 341, DateTimeKind.Utc).AddTicks(6887), new DateTime(2022, 12, 7, 23, 54, 38, 341, DateTimeKind.Utc).AddTicks(6886) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 12, 7, 23, 54, 38, 341, DateTimeKind.Utc).AddTicks(6891), new DateTime(2022, 12, 7, 23, 54, 38, 341, DateTimeKind.Utc).AddTicks(6890) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 4,
                column: "StartDate",
                value: new DateTime(2022, 12, 7, 23, 54, 38, 341, DateTimeKind.Utc).AddTicks(6893));

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 5,
                column: "StartDate",
                value: new DateTime(2022, 12, 7, 23, 54, 38, 341, DateTimeKind.Utc).AddTicks(6896));

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 6,
                column: "StartDate",
                value: new DateTime(2022, 12, 7, 23, 54, 38, 341, DateTimeKind.Utc).AddTicks(6898));
        }
    }
}
