using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalLibrary.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Therapies",
                keyColumn: "Id",
                keyValue: 1,
                column: "WhenPrescribed",
                value: new DateTime(2022, 12, 14, 18, 47, 7, 721, DateTimeKind.Utc).AddTicks(5975));

            migrationBuilder.UpdateData(
                table: "Therapies",
                keyColumn: "Id",
                keyValue: 2,
                column: "WhenPrescribed",
                value: new DateTime(2022, 12, 14, 18, 47, 7, 721, DateTimeKind.Utc).AddTicks(5977));

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 12, 14, 18, 47, 7, 721, DateTimeKind.Utc).AddTicks(5904), new DateTime(2022, 12, 14, 18, 47, 7, 721, DateTimeKind.Utc).AddTicks(5904) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 12, 14, 18, 47, 7, 721, DateTimeKind.Utc).AddTicks(5908), new DateTime(2022, 12, 14, 18, 47, 7, 721, DateTimeKind.Utc).AddTicks(5908) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 12, 14, 18, 47, 7, 721, DateTimeKind.Utc).AddTicks(5909), new DateTime(2022, 12, 14, 18, 47, 7, 721, DateTimeKind.Utc).AddTicks(5909) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 4,
                column: "StartDate",
                value: new DateTime(2022, 12, 14, 18, 47, 7, 721, DateTimeKind.Utc).AddTicks(5940));

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 5,
                column: "StartDate",
                value: new DateTime(2022, 12, 14, 18, 47, 7, 721, DateTimeKind.Utc).AddTicks(5941));

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 6,
                column: "StartDate",
                value: new DateTime(2022, 12, 14, 18, 47, 7, 721, DateTimeKind.Utc).AddTicks(5942));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Therapies",
                keyColumn: "Id",
                keyValue: 1,
                column: "WhenPrescribed",
                value: new DateTime(2022, 12, 14, 18, 23, 23, 710, DateTimeKind.Utc).AddTicks(9647));

            migrationBuilder.UpdateData(
                table: "Therapies",
                keyColumn: "Id",
                keyValue: 2,
                column: "WhenPrescribed",
                value: new DateTime(2022, 12, 14, 18, 23, 23, 710, DateTimeKind.Utc).AddTicks(9650));

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 12, 14, 18, 23, 23, 710, DateTimeKind.Utc).AddTicks(9607), new DateTime(2022, 12, 14, 18, 23, 23, 710, DateTimeKind.Utc).AddTicks(9607) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 12, 14, 18, 23, 23, 710, DateTimeKind.Utc).AddTicks(9610), new DateTime(2022, 12, 14, 18, 23, 23, 710, DateTimeKind.Utc).AddTicks(9610) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 12, 14, 18, 23, 23, 710, DateTimeKind.Utc).AddTicks(9612), new DateTime(2022, 12, 14, 18, 23, 23, 710, DateTimeKind.Utc).AddTicks(9611) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 4,
                column: "StartDate",
                value: new DateTime(2022, 12, 14, 18, 23, 23, 710, DateTimeKind.Utc).AddTicks(9612));

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 5,
                column: "StartDate",
                value: new DateTime(2022, 12, 14, 18, 23, 23, 710, DateTimeKind.Utc).AddTicks(9613));

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 6,
                column: "StartDate",
                value: new DateTime(2022, 12, 14, 18, 23, 23, 710, DateTimeKind.Utc).AddTicks(9614));
        }
    }
}
