using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalLibrary.Migrations
{
    public partial class SeedSymptoms1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Symptoms",
                columns: new[] { "Id", "ExaminationDoneId", "Name" },
                values: new object[,]
                {
                    { 1, null, "Temperatura" },
                    { 2, null, "Glavobolja" },
                    { 3, null, "Bol u stomaku" }
                });

            migrationBuilder.UpdateData(
                table: "Therapies",
                keyColumn: "Id",
                keyValue: 1,
                column: "WhenPrescribed",
                value: new DateTime(2022, 12, 8, 1, 4, 9, 992, DateTimeKind.Utc).AddTicks(4395));

            migrationBuilder.UpdateData(
                table: "Therapies",
                keyColumn: "Id",
                keyValue: 2,
                column: "WhenPrescribed",
                value: new DateTime(2022, 12, 8, 1, 4, 9, 992, DateTimeKind.Utc).AddTicks(4406));

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 12, 8, 1, 4, 9, 992, DateTimeKind.Utc).AddTicks(4131), new DateTime(2022, 12, 8, 1, 4, 9, 992, DateTimeKind.Utc).AddTicks(4127) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 12, 8, 1, 4, 9, 992, DateTimeKind.Utc).AddTicks(4152), new DateTime(2022, 12, 8, 1, 4, 9, 992, DateTimeKind.Utc).AddTicks(4151) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 12, 8, 1, 4, 9, 992, DateTimeKind.Utc).AddTicks(4159), new DateTime(2022, 12, 8, 1, 4, 9, 992, DateTimeKind.Utc).AddTicks(4158) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 4,
                column: "StartDate",
                value: new DateTime(2022, 12, 8, 1, 4, 9, 992, DateTimeKind.Utc).AddTicks(4161));

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 5,
                column: "StartDate",
                value: new DateTime(2022, 12, 8, 1, 4, 9, 992, DateTimeKind.Utc).AddTicks(4166));

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 6,
                column: "StartDate",
                value: new DateTime(2022, 12, 8, 1, 4, 9, 992, DateTimeKind.Utc).AddTicks(4169));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Symptoms",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Symptoms",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Symptoms",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Therapies",
                keyColumn: "Id",
                keyValue: 1,
                column: "WhenPrescribed",
                value: new DateTime(2022, 12, 8, 0, 55, 36, 589, DateTimeKind.Utc).AddTicks(7520));

            migrationBuilder.UpdateData(
                table: "Therapies",
                keyColumn: "Id",
                keyValue: 2,
                column: "WhenPrescribed",
                value: new DateTime(2022, 12, 8, 0, 55, 36, 589, DateTimeKind.Utc).AddTicks(7528));

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 12, 8, 0, 55, 36, 589, DateTimeKind.Utc).AddTicks(6985), new DateTime(2022, 12, 8, 0, 55, 36, 589, DateTimeKind.Utc).AddTicks(6980) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 12, 8, 0, 55, 36, 589, DateTimeKind.Utc).AddTicks(6998), new DateTime(2022, 12, 8, 0, 55, 36, 589, DateTimeKind.Utc).AddTicks(6997) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 12, 8, 0, 55, 36, 589, DateTimeKind.Utc).AddTicks(7002), new DateTime(2022, 12, 8, 0, 55, 36, 589, DateTimeKind.Utc).AddTicks(7001) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 4,
                column: "StartDate",
                value: new DateTime(2022, 12, 8, 0, 55, 36, 589, DateTimeKind.Utc).AddTicks(7005));

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 5,
                column: "StartDate",
                value: new DateTime(2022, 12, 8, 0, 55, 36, 589, DateTimeKind.Utc).AddTicks(7009));

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 6,
                column: "StartDate",
                value: new DateTime(2022, 12, 8, 0, 55, 36, 589, DateTimeKind.Utc).AddTicks(7015));
        }
    }
}
