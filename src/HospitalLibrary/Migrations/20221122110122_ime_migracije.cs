using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalLibrary.Migrations
{
    public partial class ime_migracije : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndWork", "StartWork" },
                values: new object[] { new DateTime(2022, 11, 22, 11, 1, 21, 503, DateTimeKind.Utc).AddTicks(3569), new DateTime(2022, 11, 22, 11, 1, 21, 503, DateTimeKind.Utc).AddTicks(3568) });

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndWork", "StartWork" },
                values: new object[] { new DateTime(2022, 11, 22, 11, 1, 21, 503, DateTimeKind.Utc).AddTicks(3571), new DateTime(2022, 11, 22, 11, 1, 21, 503, DateTimeKind.Utc).AddTicks(3571) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 11, 22, 11, 1, 21, 503, DateTimeKind.Utc).AddTicks(3595), new DateTime(2022, 11, 22, 11, 1, 21, 503, DateTimeKind.Utc).AddTicks(3595) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 11, 22, 11, 1, 21, 503, DateTimeKind.Utc).AddTicks(3599), new DateTime(2022, 11, 22, 11, 1, 21, 503, DateTimeKind.Utc).AddTicks(3599) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 11, 22, 11, 1, 21, 503, DateTimeKind.Utc).AddTicks(3601), new DateTime(2022, 11, 22, 11, 1, 21, 503, DateTimeKind.Utc).AddTicks(3601) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndWork", "StartWork" },
                values: new object[] { new DateTime(2022, 11, 21, 21, 41, 0, 569, DateTimeKind.Utc).AddTicks(2161), new DateTime(2022, 11, 21, 21, 41, 0, 569, DateTimeKind.Utc).AddTicks(2160) });

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndWork", "StartWork" },
                values: new object[] { new DateTime(2022, 11, 21, 21, 41, 0, 569, DateTimeKind.Utc).AddTicks(2163), new DateTime(2022, 11, 21, 21, 41, 0, 569, DateTimeKind.Utc).AddTicks(2163) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 11, 21, 21, 41, 0, 569, DateTimeKind.Utc).AddTicks(2194), new DateTime(2022, 11, 21, 21, 41, 0, 569, DateTimeKind.Utc).AddTicks(2193) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 11, 21, 21, 41, 0, 569, DateTimeKind.Utc).AddTicks(2198), new DateTime(2022, 11, 21, 21, 41, 0, 569, DateTimeKind.Utc).AddTicks(2198) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 11, 21, 21, 41, 0, 569, DateTimeKind.Utc).AddTicks(2200), new DateTime(2022, 11, 21, 21, 41, 0, 569, DateTimeKind.Utc).AddTicks(2200) });
        }
    }
}
