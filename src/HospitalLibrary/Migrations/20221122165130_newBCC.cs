using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalLibrary.Migrations
{
    public partial class newBCC : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndWork", "StartWork" },
                values: new object[] { new DateTime(2022, 11, 22, 16, 51, 29, 477, DateTimeKind.Utc).AddTicks(4129), new DateTime(2022, 11, 22, 16, 51, 29, 477, DateTimeKind.Utc).AddTicks(4128) });

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndWork", "StartWork" },
                values: new object[] { new DateTime(2022, 11, 22, 16, 51, 29, 477, DateTimeKind.Utc).AddTicks(4130), new DateTime(2022, 11, 22, 16, 51, 29, 477, DateTimeKind.Utc).AddTicks(4130) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 11, 22, 16, 51, 29, 477, DateTimeKind.Utc).AddTicks(4155), new DateTime(2022, 11, 22, 16, 51, 29, 477, DateTimeKind.Utc).AddTicks(4155) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 11, 22, 16, 51, 29, 477, DateTimeKind.Utc).AddTicks(4163), new DateTime(2022, 11, 22, 16, 51, 29, 477, DateTimeKind.Utc).AddTicks(4163) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 11, 22, 16, 51, 29, 477, DateTimeKind.Utc).AddTicks(4165), new DateTime(2022, 11, 22, 16, 51, 29, 477, DateTimeKind.Utc).AddTicks(4164) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
