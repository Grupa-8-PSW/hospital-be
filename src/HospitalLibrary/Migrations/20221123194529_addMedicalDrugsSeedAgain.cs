using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalLibrary.Migrations
{
    public partial class addMedicalDrugsSeedAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndWork", "StartWork" },
                values: new object[] { new DateTime(2022, 11, 23, 19, 45, 27, 613, DateTimeKind.Utc).AddTicks(7921), new DateTime(2022, 11, 23, 19, 45, 27, 613, DateTimeKind.Utc).AddTicks(7919) });

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndWork", "StartWork" },
                values: new object[] { new DateTime(2022, 11, 23, 19, 45, 27, 613, DateTimeKind.Utc).AddTicks(7925), new DateTime(2022, 11, 23, 19, 45, 27, 613, DateTimeKind.Utc).AddTicks(7924) });

            migrationBuilder.UpdateData(
                table: "MedicalDrugs",
                keyColumn: "Id",
                keyValue: 1,
                column: "Amount",
                value: 50);

            migrationBuilder.InsertData(
                table: "MedicalDrugs",
                columns: new[] { "Id", "Amount", "Code", "Name" },
                values: new object[,]
                {
                    { 2, 50, "Code2", "Drugs2" },
                    { 3, 50, "Code3", "Drugs3" }
                });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 11, 23, 19, 45, 27, 613, DateTimeKind.Utc).AddTicks(7990), new DateTime(2022, 11, 23, 19, 45, 27, 613, DateTimeKind.Utc).AddTicks(7989) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 11, 23, 19, 45, 27, 613, DateTimeKind.Utc).AddTicks(7999), new DateTime(2022, 11, 23, 19, 45, 27, 613, DateTimeKind.Utc).AddTicks(7998) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 11, 23, 19, 45, 27, 613, DateTimeKind.Utc).AddTicks(8002), new DateTime(2022, 11, 23, 19, 45, 27, 613, DateTimeKind.Utc).AddTicks(8002) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MedicalDrugs",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MedicalDrugs",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndWork", "StartWork" },
                values: new object[] { new DateTime(2022, 11, 23, 19, 39, 37, 805, DateTimeKind.Utc).AddTicks(4291), new DateTime(2022, 11, 23, 19, 39, 37, 805, DateTimeKind.Utc).AddTicks(4288) });

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndWork", "StartWork" },
                values: new object[] { new DateTime(2022, 11, 23, 19, 39, 37, 805, DateTimeKind.Utc).AddTicks(4294), new DateTime(2022, 11, 23, 19, 39, 37, 805, DateTimeKind.Utc).AddTicks(4293) });

            migrationBuilder.UpdateData(
                table: "MedicalDrugs",
                keyColumn: "Id",
                keyValue: 1,
                column: "Amount",
                value: 0);

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 11, 23, 19, 39, 37, 805, DateTimeKind.Utc).AddTicks(4365), new DateTime(2022, 11, 23, 19, 39, 37, 805, DateTimeKind.Utc).AddTicks(4364) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 11, 23, 19, 39, 37, 805, DateTimeKind.Utc).AddTicks(4375), new DateTime(2022, 11, 23, 19, 39, 37, 805, DateTimeKind.Utc).AddTicks(4374) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 11, 23, 19, 39, 37, 805, DateTimeKind.Utc).AddTicks(4378), new DateTime(2022, 11, 23, 19, 39, 37, 805, DateTimeKind.Utc).AddTicks(4377) });
        }
    }
}
