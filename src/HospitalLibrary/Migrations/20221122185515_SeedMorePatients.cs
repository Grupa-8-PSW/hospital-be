using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalLibrary.Migrations
{
    public partial class SeedMorePatients : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndWork", "StartWork" },
                values: new object[] { new DateTime(2022, 11, 22, 18, 55, 9, 657, DateTimeKind.Utc).AddTicks(2895), new DateTime(2022, 11, 22, 18, 55, 9, 657, DateTimeKind.Utc).AddTicks(2893) });

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndWork", "StartWork" },
                values: new object[] { new DateTime(2022, 11, 22, 18, 55, 9, 657, DateTimeKind.Utc).AddTicks(2901), new DateTime(2022, 11, 22, 18, 55, 9, 657, DateTimeKind.Utc).AddTicks(2898) });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 5, "Mika", "Mikic" },
                    { 6, "Ana", "Anic" },
                    { 7, "Andjela", "Andjelic" },
                    { 8, "Slobodan", "Slobic" }
                });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 11, 22, 18, 55, 9, 657, DateTimeKind.Utc).AddTicks(3094), new DateTime(2022, 11, 22, 18, 55, 9, 657, DateTimeKind.Utc).AddTicks(3090) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 11, 22, 18, 55, 9, 657, DateTimeKind.Utc).AddTicks(3110), new DateTime(2022, 11, 22, 18, 55, 9, 657, DateTimeKind.Utc).AddTicks(3109) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 11, 22, 18, 55, 9, 657, DateTimeKind.Utc).AddTicks(3114), new DateTime(2022, 11, 22, 18, 55, 9, 657, DateTimeKind.Utc).AddTicks(3113) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 4,
                column: "StartDate",
                value: new DateTime(2022, 11, 22, 18, 55, 9, 657, DateTimeKind.Utc).AddTicks(3117));

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 5,
                column: "StartDate",
                value: new DateTime(2022, 11, 22, 18, 55, 9, 657, DateTimeKind.Utc).AddTicks(3120));

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 6,
                column: "StartDate",
                value: new DateTime(2022, 11, 22, 18, 55, 9, 657, DateTimeKind.Utc).AddTicks(3123));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndWork", "StartWork" },
                values: new object[] { new DateTime(2022, 11, 19, 18, 38, 27, 223, DateTimeKind.Utc).AddTicks(7959), new DateTime(2022, 11, 19, 18, 38, 27, 223, DateTimeKind.Utc).AddTicks(7957) });

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndWork", "StartWork" },
                values: new object[] { new DateTime(2022, 11, 19, 18, 38, 27, 223, DateTimeKind.Utc).AddTicks(7964), new DateTime(2022, 11, 19, 18, 38, 27, 223, DateTimeKind.Utc).AddTicks(7963) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 11, 19, 18, 38, 27, 223, DateTimeKind.Utc).AddTicks(8156), new DateTime(2022, 11, 19, 18, 38, 27, 223, DateTimeKind.Utc).AddTicks(8154) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 11, 19, 18, 38, 27, 223, DateTimeKind.Utc).AddTicks(8172), new DateTime(2022, 11, 19, 18, 38, 27, 223, DateTimeKind.Utc).AddTicks(8171) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 11, 19, 18, 38, 27, 223, DateTimeKind.Utc).AddTicks(8178), new DateTime(2022, 11, 19, 18, 38, 27, 223, DateTimeKind.Utc).AddTicks(8177) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 4,
                column: "StartDate",
                value: new DateTime(2022, 11, 19, 18, 38, 27, 223, DateTimeKind.Utc).AddTicks(8182));

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 5,
                column: "StartDate",
                value: new DateTime(2022, 11, 19, 18, 38, 27, 223, DateTimeKind.Utc).AddTicks(8187));

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 6,
                column: "StartDate",
                value: new DateTime(2022, 11, 19, 18, 38, 27, 223, DateTimeKind.Utc).AddTicks(8190));
        }
    }
}
