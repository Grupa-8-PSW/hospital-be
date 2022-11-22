using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalLibrary.Migrations
{
    public partial class migr1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndWork", "StartWork" },
                values: new object[] { new DateTime(2022, 11, 20, 0, 38, 55, 207, DateTimeKind.Utc).AddTicks(4576), new DateTime(2022, 11, 20, 0, 38, 55, 207, DateTimeKind.Utc).AddTicks(4574) });

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndWork", "StartWork" },
                values: new object[] { new DateTime(2022, 11, 20, 0, 38, 55, 207, DateTimeKind.Utc).AddTicks(4581), new DateTime(2022, 11, 20, 0, 38, 55, 207, DateTimeKind.Utc).AddTicks(4580) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 11, 20, 0, 38, 55, 207, DateTimeKind.Utc).AddTicks(4641), new DateTime(2022, 11, 20, 0, 38, 55, 207, DateTimeKind.Utc).AddTicks(4640) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 11, 20, 0, 38, 55, 207, DateTimeKind.Utc).AddTicks(4650), new DateTime(2022, 11, 20, 0, 38, 55, 207, DateTimeKind.Utc).AddTicks(4649) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 11, 20, 0, 38, 55, 207, DateTimeKind.Utc).AddTicks(4757), new DateTime(2022, 11, 20, 0, 38, 55, 207, DateTimeKind.Utc).AddTicks(4756) });
        }
    }
}
