using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalLibrary.Migrations
{
    public partial class addedBloodSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndWork", "StartWork" },
                values: new object[] { new DateTime(2022, 11, 20, 0, 37, 18, 547, DateTimeKind.Utc).AddTicks(4466), new DateTime(2022, 11, 20, 0, 37, 18, 547, DateTimeKind.Utc).AddTicks(4464) });

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndWork", "StartWork" },
                values: new object[] { new DateTime(2022, 11, 20, 0, 37, 18, 547, DateTimeKind.Utc).AddTicks(4470), new DateTime(2022, 11, 20, 0, 37, 18, 547, DateTimeKind.Utc).AddTicks(4470) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 11, 20, 0, 37, 18, 547, DateTimeKind.Utc).AddTicks(4542), new DateTime(2022, 11, 20, 0, 37, 18, 547, DateTimeKind.Utc).AddTicks(4542) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 11, 20, 0, 37, 18, 547, DateTimeKind.Utc).AddTicks(4549), new DateTime(2022, 11, 20, 0, 37, 18, 547, DateTimeKind.Utc).AddTicks(4549) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 11, 20, 0, 37, 18, 547, DateTimeKind.Utc).AddTicks(4552), new DateTime(2022, 11, 20, 0, 37, 18, 547, DateTimeKind.Utc).AddTicks(4552) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndWork", "StartWork" },
                values: new object[] { new DateTime(2022, 11, 19, 23, 13, 32, 730, DateTimeKind.Utc).AddTicks(81), new DateTime(2022, 11, 19, 23, 13, 32, 730, DateTimeKind.Utc).AddTicks(79) });

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndWork", "StartWork" },
                values: new object[] { new DateTime(2022, 11, 19, 23, 13, 32, 730, DateTimeKind.Utc).AddTicks(86), new DateTime(2022, 11, 19, 23, 13, 32, 730, DateTimeKind.Utc).AddTicks(85) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 11, 19, 23, 13, 32, 730, DateTimeKind.Utc).AddTicks(166), new DateTime(2022, 11, 19, 23, 13, 32, 730, DateTimeKind.Utc).AddTicks(165) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 11, 19, 23, 13, 32, 730, DateTimeKind.Utc).AddTicks(174), new DateTime(2022, 11, 19, 23, 13, 32, 730, DateTimeKind.Utc).AddTicks(173) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 11, 19, 23, 13, 32, 730, DateTimeKind.Utc).AddTicks(177), new DateTime(2022, 11, 19, 23, 13, 32, 730, DateTimeKind.Utc).AddTicks(176) });
        }
    }
}
