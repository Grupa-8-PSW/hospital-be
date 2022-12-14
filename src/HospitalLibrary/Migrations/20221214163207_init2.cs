using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalLibrary.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Therapies",
                keyColumn: "Id",
                keyValue: 1,
                column: "WhenPrescribed",
                value: new DateTime(2022, 12, 14, 16, 18, 10, 100, DateTimeKind.Utc).AddTicks(6477));

            migrationBuilder.UpdateData(
                table: "Therapies",
                keyColumn: "Id",
                keyValue: 2,
                column: "WhenPrescribed",
                value: new DateTime(2022, 12, 14, 16, 18, 10, 100, DateTimeKind.Utc).AddTicks(6479));

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 12, 14, 16, 18, 10, 100, DateTimeKind.Utc).AddTicks(6424), new DateTime(2022, 12, 14, 16, 18, 10, 100, DateTimeKind.Utc).AddTicks(6423) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 12, 14, 16, 18, 10, 100, DateTimeKind.Utc).AddTicks(6429), new DateTime(2022, 12, 14, 16, 18, 10, 100, DateTimeKind.Utc).AddTicks(6429) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 12, 14, 16, 18, 10, 100, DateTimeKind.Utc).AddTicks(6431), new DateTime(2022, 12, 14, 16, 18, 10, 100, DateTimeKind.Utc).AddTicks(6430) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 4,
                column: "StartDate",
                value: new DateTime(2022, 12, 14, 16, 18, 10, 100, DateTimeKind.Utc).AddTicks(6432));

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 5,
                column: "StartDate",
                value: new DateTime(2022, 12, 14, 16, 18, 10, 100, DateTimeKind.Utc).AddTicks(6433));

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 6,
                column: "StartDate",
                value: new DateTime(2022, 12, 14, 16, 18, 10, 100, DateTimeKind.Utc).AddTicks(6434));
        }
    }
}
