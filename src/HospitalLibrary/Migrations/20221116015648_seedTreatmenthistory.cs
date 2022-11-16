using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalLibrary.Migrations
{
    public partial class seedTreatmenthistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndWork", "StartWork" },
                values: new object[] { new DateTime(2022, 11, 16, 1, 56, 46, 40, DateTimeKind.Utc).AddTicks(9800), new DateTime(2022, 11, 16, 1, 56, 46, 40, DateTimeKind.Utc).AddTicks(9798) });

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndWork", "StartWork" },
                values: new object[] { new DateTime(2022, 11, 16, 1, 56, 46, 40, DateTimeKind.Utc).AddTicks(9805), new DateTime(2022, 11, 16, 1, 56, 46, 40, DateTimeKind.Utc).AddTicks(9804) });

            migrationBuilder.InsertData(
                table: "TreatmentHistories",
                columns: new[] { "Id", "Active", "BedId", "DischargeReason", "EndDate", "PatientId", "Reason", "StartDate" },
                values: new object[,]
                {
                    { 1, true, 1, "abc", new DateTime(2022, 11, 16, 1, 56, 46, 40, DateTimeKind.Utc).AddTicks(9918), 1, null, new DateTime(2022, 11, 16, 1, 56, 46, 40, DateTimeKind.Utc).AddTicks(9917) },
                    { 2, true, 2, "abc", new DateTime(2022, 11, 16, 1, 56, 46, 40, DateTimeKind.Utc).AddTicks(9928), 2, null, new DateTime(2022, 11, 16, 1, 56, 46, 40, DateTimeKind.Utc).AddTicks(9927) },
                    { 3, true, 3, "abc", new DateTime(2022, 11, 16, 1, 56, 46, 40, DateTimeKind.Utc).AddTicks(9932), 3, null, new DateTime(2022, 11, 16, 1, 56, 46, 40, DateTimeKind.Utc).AddTicks(9931) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndWork", "StartWork" },
                values: new object[] { new DateTime(2022, 11, 16, 1, 44, 22, 327, DateTimeKind.Utc).AddTicks(436), new DateTime(2022, 11, 16, 1, 44, 22, 327, DateTimeKind.Utc).AddTicks(433) });

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndWork", "StartWork" },
                values: new object[] { new DateTime(2022, 11, 16, 1, 44, 22, 327, DateTimeKind.Utc).AddTicks(439), new DateTime(2022, 11, 16, 1, 44, 22, 327, DateTimeKind.Utc).AddTicks(438) });
        }
    }
}
