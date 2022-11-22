using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalLibrary.Migrations
{
    public partial class integrationMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndWork", "StartWork" },
                values: new object[] { new DateTime(2022, 11, 21, 15, 23, 58, 69, DateTimeKind.Utc).AddTicks(7694), new DateTime(2022, 11, 21, 15, 23, 58, 69, DateTimeKind.Utc).AddTicks(7693) });

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndWork", "StartWork" },
                values: new object[] { new DateTime(2022, 11, 21, 15, 23, 58, 69, DateTimeKind.Utc).AddTicks(7695), new DateTime(2022, 11, 21, 15, 23, 58, 69, DateTimeKind.Utc).AddTicks(7695) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 11, 21, 15, 23, 58, 69, DateTimeKind.Utc).AddTicks(7726), new DateTime(2022, 11, 21, 15, 23, 58, 69, DateTimeKind.Utc).AddTicks(7725) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 11, 21, 15, 23, 58, 69, DateTimeKind.Utc).AddTicks(7730), new DateTime(2022, 11, 21, 15, 23, 58, 69, DateTimeKind.Utc).AddTicks(7730) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 11, 21, 15, 23, 58, 69, DateTimeKind.Utc).AddTicks(7732), new DateTime(2022, 11, 21, 15, 23, 58, 69, DateTimeKind.Utc).AddTicks(7731) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndWork", "StartWork" },
                values: new object[] { new DateTime(2022, 11, 21, 1, 23, 45, 975, DateTimeKind.Utc).AddTicks(8310), new DateTime(2022, 11, 21, 1, 23, 45, 975, DateTimeKind.Utc).AddTicks(8308) });

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndWork", "StartWork" },
                values: new object[] { new DateTime(2022, 11, 21, 1, 23, 45, 975, DateTimeKind.Utc).AddTicks(8313), new DateTime(2022, 11, 21, 1, 23, 45, 975, DateTimeKind.Utc).AddTicks(8312) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 11, 21, 1, 23, 45, 975, DateTimeKind.Utc).AddTicks(8378), new DateTime(2022, 11, 21, 1, 23, 45, 975, DateTimeKind.Utc).AddTicks(8377) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 11, 21, 1, 23, 45, 975, DateTimeKind.Utc).AddTicks(8386), new DateTime(2022, 11, 21, 1, 23, 45, 975, DateTimeKind.Utc).AddTicks(8385) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 11, 21, 1, 23, 45, 975, DateTimeKind.Utc).AddTicks(8388), new DateTime(2022, 11, 21, 1, 23, 45, 975, DateTimeKind.Utc).AddTicks(8388) });
        }
    }
}
