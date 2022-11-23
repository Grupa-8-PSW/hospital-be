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
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndWork", "StartWork" },
                values: new object[] { new DateTime(2022, 11, 22, 16, 23, 41, 164, DateTimeKind.Utc).AddTicks(766), new DateTime(2022, 11, 22, 16, 23, 41, 164, DateTimeKind.Utc).AddTicks(765) });

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndWork", "StartWork" },
                values: new object[] { new DateTime(2022, 11, 22, 16, 23, 41, 164, DateTimeKind.Utc).AddTicks(767), new DateTime(2022, 11, 22, 16, 23, 41, 164, DateTimeKind.Utc).AddTicks(767) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 11, 22, 16, 23, 41, 164, DateTimeKind.Utc).AddTicks(792), new DateTime(2022, 11, 22, 16, 23, 41, 164, DateTimeKind.Utc).AddTicks(791) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 11, 22, 16, 23, 41, 164, DateTimeKind.Utc).AddTicks(796), new DateTime(2022, 11, 22, 16, 23, 41, 164, DateTimeKind.Utc).AddTicks(796) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 11, 22, 16, 23, 41, 164, DateTimeKind.Utc).AddTicks(798), new DateTime(2022, 11, 22, 16, 23, 41, 164, DateTimeKind.Utc).AddTicks(797) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndWork", "StartWork" },
                values: new object[] { new DateTime(2022, 11, 22, 11, 5, 24, 359, DateTimeKind.Utc).AddTicks(1130), new DateTime(2022, 11, 22, 11, 5, 24, 359, DateTimeKind.Utc).AddTicks(1129) });

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndWork", "StartWork" },
                values: new object[] { new DateTime(2022, 11, 22, 11, 5, 24, 359, DateTimeKind.Utc).AddTicks(1164), new DateTime(2022, 11, 22, 11, 5, 24, 359, DateTimeKind.Utc).AddTicks(1164) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 11, 22, 11, 5, 24, 359, DateTimeKind.Utc).AddTicks(1195), new DateTime(2022, 11, 22, 11, 5, 24, 359, DateTimeKind.Utc).AddTicks(1195) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 11, 22, 11, 5, 24, 359, DateTimeKind.Utc).AddTicks(1200), new DateTime(2022, 11, 22, 11, 5, 24, 359, DateTimeKind.Utc).AddTicks(1200) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 11, 22, 11, 5, 24, 359, DateTimeKind.Utc).AddTicks(1201), new DateTime(2022, 11, 22, 11, 5, 24, 359, DateTimeKind.Utc).AddTicks(1201) });
        }
    }
}
