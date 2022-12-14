using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalLibrary.Migrations
{
    public partial class AddedExaminationsToSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Examinations",
                keyColumn: "Id",
                keyValue: 1,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Examinations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PatientId", "Status" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "Examinations",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DoctorId", "PatientId", "RoomId", "DateRange_End", "DateRange_Start" },
                values: new object[] { 2, 1, 2, new DateTime(2022, 12, 15, 12, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 12, 15, 12, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Examinations",
                columns: new[] { "Id", "DoctorId", "PatientId", "RoomId", "Status", "DateRange_End", "DateRange_Start" },
                values: new object[,]
                {
                    { 4, 3, 1, 3, 0, new DateTime(2023, 1, 22, 8, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 22, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 1, 1, 1, 0, new DateTime(2023, 2, 5, 9, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 2, 5, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 1, 1, 1, 2, new DateTime(2022, 12, 27, 7, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 12, 27, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, 1, 3, 3, 1, new DateTime(2022, 12, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 12, 1, 8, 30, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.UpdateData(
                table: "Therapies",
                keyColumn: "Id",
                keyValue: 1,
                column: "WhenPrescribed",
                value: new DateTime(2022, 12, 14, 19, 36, 26, 129, DateTimeKind.Utc).AddTicks(9787));

            migrationBuilder.UpdateData(
                table: "Therapies",
                keyColumn: "Id",
                keyValue: 2,
                column: "WhenPrescribed",
                value: new DateTime(2022, 12, 14, 19, 36, 26, 129, DateTimeKind.Utc).AddTicks(9789));

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 12, 14, 19, 36, 26, 129, DateTimeKind.Utc).AddTicks(9759), new DateTime(2022, 12, 14, 19, 36, 26, 129, DateTimeKind.Utc).AddTicks(9758) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 12, 14, 19, 36, 26, 129, DateTimeKind.Utc).AddTicks(9762), new DateTime(2022, 12, 14, 19, 36, 26, 129, DateTimeKind.Utc).AddTicks(9762) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 12, 14, 19, 36, 26, 129, DateTimeKind.Utc).AddTicks(9764), new DateTime(2022, 12, 14, 19, 36, 26, 129, DateTimeKind.Utc).AddTicks(9763) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 4,
                column: "StartDate",
                value: new DateTime(2022, 12, 14, 19, 36, 26, 129, DateTimeKind.Utc).AddTicks(9764));

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 5,
                column: "StartDate",
                value: new DateTime(2022, 12, 14, 19, 36, 26, 129, DateTimeKind.Utc).AddTicks(9765));

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 6,
                column: "StartDate",
                value: new DateTime(2022, 12, 14, 19, 36, 26, 129, DateTimeKind.Utc).AddTicks(9766));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Examinations",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Examinations",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Examinations",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Examinations",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.UpdateData(
                table: "Examinations",
                keyColumn: "Id",
                keyValue: 1,
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Examinations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PatientId", "Status" },
                values: new object[] { 2, 0 });

            migrationBuilder.UpdateData(
                table: "Examinations",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DoctorId", "PatientId", "RoomId", "DateRange_End", "DateRange_Start" },
                values: new object[] { 1, 3, 3, new DateTime(2022, 12, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 12, 1, 8, 30, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Therapies",
                keyColumn: "Id",
                keyValue: 1,
                column: "WhenPrescribed",
                value: new DateTime(2022, 12, 14, 19, 16, 33, 136, DateTimeKind.Utc).AddTicks(2614));

            migrationBuilder.UpdateData(
                table: "Therapies",
                keyColumn: "Id",
                keyValue: 2,
                column: "WhenPrescribed",
                value: new DateTime(2022, 12, 14, 19, 16, 33, 136, DateTimeKind.Utc).AddTicks(2616));

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 12, 14, 19, 16, 33, 136, DateTimeKind.Utc).AddTicks(2585), new DateTime(2022, 12, 14, 19, 16, 33, 136, DateTimeKind.Utc).AddTicks(2584) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 12, 14, 19, 16, 33, 136, DateTimeKind.Utc).AddTicks(2588), new DateTime(2022, 12, 14, 19, 16, 33, 136, DateTimeKind.Utc).AddTicks(2587) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 12, 14, 19, 16, 33, 136, DateTimeKind.Utc).AddTicks(2589), new DateTime(2022, 12, 14, 19, 16, 33, 136, DateTimeKind.Utc).AddTicks(2589) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 4,
                column: "StartDate",
                value: new DateTime(2022, 12, 14, 19, 16, 33, 136, DateTimeKind.Utc).AddTicks(2590));

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 5,
                column: "StartDate",
                value: new DateTime(2022, 12, 14, 19, 16, 33, 136, DateTimeKind.Utc).AddTicks(2591));

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 6,
                column: "StartDate",
                value: new DateTime(2022, 12, 14, 19, 16, 33, 136, DateTimeKind.Utc).AddTicks(2591));
        }
    }
}
