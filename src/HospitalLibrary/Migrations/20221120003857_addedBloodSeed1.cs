using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalLibrary.Migrations
{
    public partial class addedBloodSeed1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Bloods",
                columns: new[] { "Id", "Quantity", "Type" },
                values: new object[,]
                {
                    { 1, 100, 0 },
                    { 2, 100, 1 },
                    { 3, 100, 2 },
                    { 4, 100, 3 },
                    { 5, 100, 4 },
                    { 6, 100, 5 },
                    { 7, 100, 6 },
                    { 8, 100, 7 }
                });

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndWork", "StartWork" },
                values: new object[] { new DateTime(2022, 11, 20, 0, 38, 55, 207, DateTimeKind.Utc).AddTicks(4576), new DateTime(2022, 11, 20, 0, 38, 55, 207, DateTimeKind.Utc).AddTicks(4574) });

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndWork", "StartWork" },
                values: new object[] { new DateTime(2022, 11, 20, 0, 38, 55, 207, DateTimeKind.Utc).AddTicks(4581), new DateTime(2022, 11, 20, 0, 38, 55, 207, DateTimeKind.Utc).AddTicks(4580) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 11, 20, 0, 38, 55, 207, DateTimeKind.Utc).AddTicks(4641), new DateTime(2022, 11, 20, 0, 38, 55, 207, DateTimeKind.Utc).AddTicks(4640) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 11, 20, 0, 38, 55, 207, DateTimeKind.Utc).AddTicks(4650), new DateTime(2022, 11, 20, 0, 38, 55, 207, DateTimeKind.Utc).AddTicks(4649) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 11, 20, 0, 38, 55, 207, DateTimeKind.Utc).AddTicks(4757), new DateTime(2022, 11, 20, 0, 38, 55, 207, DateTimeKind.Utc).AddTicks(4756) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Bloods",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Bloods",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Bloods",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Bloods",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Bloods",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Bloods",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Bloods",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Bloods",
                keyColumn: "Id",
                keyValue: 8);

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
    }
}
