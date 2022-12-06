using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalLibrary.Migrations
{
    public partial class gascina : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Therapies",
                keyColumn: "Id",
                keyValue: 1,
                column: "WhenPrescribed",
                value: new DateTime(2022, 12, 6, 12, 30, 55, 898, DateTimeKind.Utc).AddTicks(8916));

            migrationBuilder.UpdateData(
                table: "Therapies",
                keyColumn: "Id",
                keyValue: 2,
                column: "WhenPrescribed",
                value: new DateTime(2022, 12, 6, 12, 30, 55, 898, DateTimeKind.Utc).AddTicks(8918));

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 12, 6, 12, 30, 55, 898, DateTimeKind.Utc).AddTicks(8872), new DateTime(2022, 12, 6, 12, 30, 55, 898, DateTimeKind.Utc).AddTicks(8870) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 12, 6, 12, 30, 55, 898, DateTimeKind.Utc).AddTicks(8876), new DateTime(2022, 12, 6, 12, 30, 55, 898, DateTimeKind.Utc).AddTicks(8875) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 12, 6, 12, 30, 55, 898, DateTimeKind.Utc).AddTicks(8878), new DateTime(2022, 12, 6, 12, 30, 55, 898, DateTimeKind.Utc).AddTicks(8877) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 4,
                column: "StartDate",
                value: new DateTime(2022, 12, 6, 12, 30, 55, 898, DateTimeKind.Utc).AddTicks(8880));

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 5,
                column: "StartDate",
                value: new DateTime(2022, 12, 6, 12, 30, 55, 898, DateTimeKind.Utc).AddTicks(8881));

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 6,
                column: "StartDate",
                value: new DateTime(2022, 12, 6, 12, 30, 55, 898, DateTimeKind.Utc).AddTicks(8882));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Therapies",
                keyColumn: "Id",
                keyValue: 1,
                column: "WhenPrescribed",
                value: new DateTime(2022, 11, 29, 13, 39, 10, 774, DateTimeKind.Utc).AddTicks(2590));

            migrationBuilder.UpdateData(
                table: "Therapies",
                keyColumn: "Id",
                keyValue: 2,
                column: "WhenPrescribed",
                value: new DateTime(2022, 11, 29, 13, 39, 10, 774, DateTimeKind.Utc).AddTicks(2593));

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
    }
}
