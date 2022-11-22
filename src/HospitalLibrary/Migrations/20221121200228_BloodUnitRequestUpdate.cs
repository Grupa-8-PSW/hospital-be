using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalLibrary.Migrations
{
    public partial class BloodUnitRequestUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ManagerComment",
                table: "BloodUnitRequests",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "Rejected",
                table: "BloodUnitRequests",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndWork", "StartWork" },
                values: new object[] { new DateTime(2022, 11, 21, 20, 2, 27, 380, DateTimeKind.Utc).AddTicks(2235), new DateTime(2022, 11, 21, 20, 2, 27, 380, DateTimeKind.Utc).AddTicks(2234) });

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndWork", "StartWork" },
                values: new object[] { new DateTime(2022, 11, 21, 20, 2, 27, 380, DateTimeKind.Utc).AddTicks(2237), new DateTime(2022, 11, 21, 20, 2, 27, 380, DateTimeKind.Utc).AddTicks(2237) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 11, 21, 20, 2, 27, 380, DateTimeKind.Utc).AddTicks(2304), new DateTime(2022, 11, 21, 20, 2, 27, 380, DateTimeKind.Utc).AddTicks(2304) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 11, 21, 20, 2, 27, 380, DateTimeKind.Utc).AddTicks(2310), new DateTime(2022, 11, 21, 20, 2, 27, 380, DateTimeKind.Utc).AddTicks(2309) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 11, 21, 20, 2, 27, 380, DateTimeKind.Utc).AddTicks(2312), new DateTime(2022, 11, 21, 20, 2, 27, 380, DateTimeKind.Utc).AddTicks(2311) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ManagerComment",
                table: "BloodUnitRequests");

            migrationBuilder.DropColumn(
                name: "Rejected",
                table: "BloodUnitRequests");

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
