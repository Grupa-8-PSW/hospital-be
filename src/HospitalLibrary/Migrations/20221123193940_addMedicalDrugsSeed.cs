using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalLibrary.Migrations
{
    public partial class addMedicalDrugsSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndWork", "StartWork" },
                values: new object[] { new DateTime(2022, 11, 23, 19, 39, 37, 805, DateTimeKind.Utc).AddTicks(4291), new DateTime(2022, 11, 23, 19, 39, 37, 805, DateTimeKind.Utc).AddTicks(4288) });

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndWork", "StartWork" },
                values: new object[] { new DateTime(2022, 11, 23, 19, 39, 37, 805, DateTimeKind.Utc).AddTicks(4294), new DateTime(2022, 11, 23, 19, 39, 37, 805, DateTimeKind.Utc).AddTicks(4293) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 11, 23, 19, 39, 37, 805, DateTimeKind.Utc).AddTicks(4365), new DateTime(2022, 11, 23, 19, 39, 37, 805, DateTimeKind.Utc).AddTicks(4364) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 11, 23, 19, 39, 37, 805, DateTimeKind.Utc).AddTicks(4375), new DateTime(2022, 11, 23, 19, 39, 37, 805, DateTimeKind.Utc).AddTicks(4374) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 11, 23, 19, 39, 37, 805, DateTimeKind.Utc).AddTicks(4378), new DateTime(2022, 11, 23, 19, 39, 37, 805, DateTimeKind.Utc).AddTicks(4377) });
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
