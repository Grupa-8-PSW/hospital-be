using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalLibrary.Migrations
{
    public partial class HospitalMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 11, 27, 16, 55, 9, 774, DateTimeKind.Utc).AddTicks(8684), new DateTime(2022, 11, 27, 16, 55, 9, 774, DateTimeKind.Utc).AddTicks(8683) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 11, 27, 16, 55, 9, 774, DateTimeKind.Utc).AddTicks(8688), new DateTime(2022, 11, 27, 16, 55, 9, 774, DateTimeKind.Utc).AddTicks(8688) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 11, 27, 16, 55, 9, 774, DateTimeKind.Utc).AddTicks(8690), new DateTime(2022, 11, 27, 16, 55, 9, 774, DateTimeKind.Utc).AddTicks(8690) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 4,
                column: "StartDate",
                value: new DateTime(2022, 11, 27, 16, 55, 9, 774, DateTimeKind.Utc).AddTicks(8691));

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 5,
                column: "StartDate",
                value: new DateTime(2022, 11, 27, 16, 55, 9, 774, DateTimeKind.Utc).AddTicks(8692));

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 6,
                column: "StartDate",
                value: new DateTime(2022, 11, 27, 16, 55, 9, 774, DateTimeKind.Utc).AddTicks(8693));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 11, 24, 1, 16, 20, 513, DateTimeKind.Utc).AddTicks(7247), new DateTime(2022, 11, 24, 1, 16, 20, 513, DateTimeKind.Utc).AddTicks(7246) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 11, 24, 1, 16, 20, 513, DateTimeKind.Utc).AddTicks(7252), new DateTime(2022, 11, 24, 1, 16, 20, 513, DateTimeKind.Utc).AddTicks(7251) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 11, 24, 1, 16, 20, 513, DateTimeKind.Utc).AddTicks(7253), new DateTime(2022, 11, 24, 1, 16, 20, 513, DateTimeKind.Utc).AddTicks(7253) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 4,
                column: "StartDate",
                value: new DateTime(2022, 11, 24, 1, 16, 20, 513, DateTimeKind.Utc).AddTicks(7254));

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 5,
                column: "StartDate",
                value: new DateTime(2022, 11, 24, 1, 16, 20, 513, DateTimeKind.Utc).AddTicks(7256));

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 6,
                column: "StartDate",
                value: new DateTime(2022, 11, 24, 1, 16, 20, 513, DateTimeKind.Utc).AddTicks(7257));
        }
    }
}
