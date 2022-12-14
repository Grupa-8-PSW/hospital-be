using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalLibrary.Migrations
{
    public partial class inicijalna : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Therapies",
                keyColumn: "Id",
                keyValue: 1,
                column: "WhenPrescribed",
                value: new DateTime(2022, 12, 14, 16, 32, 41, 457, DateTimeKind.Utc).AddTicks(5029));

            migrationBuilder.UpdateData(
                table: "Therapies",
                keyColumn: "Id",
                keyValue: 2,
                column: "WhenPrescribed",
                value: new DateTime(2022, 12, 14, 16, 32, 41, 457, DateTimeKind.Utc).AddTicks(5032));

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 12, 14, 16, 32, 41, 457, DateTimeKind.Utc).AddTicks(4965), new DateTime(2022, 12, 14, 16, 32, 41, 457, DateTimeKind.Utc).AddTicks(4964) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 12, 14, 16, 32, 41, 457, DateTimeKind.Utc).AddTicks(4971), new DateTime(2022, 12, 14, 16, 32, 41, 457, DateTimeKind.Utc).AddTicks(4971) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 12, 14, 16, 32, 41, 457, DateTimeKind.Utc).AddTicks(4973), new DateTime(2022, 12, 14, 16, 32, 41, 457, DateTimeKind.Utc).AddTicks(4973) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 4,
                column: "StartDate",
                value: new DateTime(2022, 12, 14, 16, 32, 41, 457, DateTimeKind.Utc).AddTicks(4975));

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 5,
                column: "StartDate",
                value: new DateTime(2022, 12, 14, 16, 32, 41, 457, DateTimeKind.Utc).AddTicks(4976));

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 6,
                column: "StartDate",
                value: new DateTime(2022, 12, 14, 16, 32, 41, 457, DateTimeKind.Utc).AddTicks(4978));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Therapies",
                keyColumn: "Id",
                keyValue: 1,
                column: "WhenPrescribed",
                value: new DateTime(2022, 12, 14, 16, 32, 5, 958, DateTimeKind.Utc).AddTicks(9878));

            migrationBuilder.UpdateData(
                table: "Therapies",
                keyColumn: "Id",
                keyValue: 2,
                column: "WhenPrescribed",
                value: new DateTime(2022, 12, 14, 16, 32, 5, 958, DateTimeKind.Utc).AddTicks(9882));

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 12, 14, 16, 32, 5, 958, DateTimeKind.Utc).AddTicks(9815), new DateTime(2022, 12, 14, 16, 32, 5, 958, DateTimeKind.Utc).AddTicks(9814) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 12, 14, 16, 32, 5, 958, DateTimeKind.Utc).AddTicks(9821), new DateTime(2022, 12, 14, 16, 32, 5, 958, DateTimeKind.Utc).AddTicks(9821) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 12, 14, 16, 32, 5, 958, DateTimeKind.Utc).AddTicks(9823), new DateTime(2022, 12, 14, 16, 32, 5, 958, DateTimeKind.Utc).AddTicks(9823) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 4,
                column: "StartDate",
                value: new DateTime(2022, 12, 14, 16, 32, 5, 958, DateTimeKind.Utc).AddTicks(9825));

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 5,
                column: "StartDate",
                value: new DateTime(2022, 12, 14, 16, 32, 5, 958, DateTimeKind.Utc).AddTicks(9826));

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 6,
                column: "StartDate",
                value: new DateTime(2022, 12, 14, 16, 32, 5, 958, DateTimeKind.Utc).AddTicks(9828));
        }
    }
}
