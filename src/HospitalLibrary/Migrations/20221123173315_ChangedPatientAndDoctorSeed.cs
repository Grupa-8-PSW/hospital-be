using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalLibrary.Migrations
{
    public partial class ChangedPatientAndDoctorSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "EndWork", "FirstName", "LastName", "RoomId", "Specialization", "StartWork" },
                values: new object[,]
                {
                    { 1, new DateTime(1998, 4, 30, 15, 0, 0, 0, DateTimeKind.Utc), "Zeljko", "Babic", 1, 0, new DateTime(1998, 4, 30, 7, 0, 0, 0, DateTimeKind.Utc) },
                    { 2, new DateTime(1998, 4, 30, 16, 0, 0, 0, DateTimeKind.Utc), "Bora", "Stevanovic", 2, 0, new DateTime(1998, 4, 30, 8, 0, 0, 0, DateTimeKind.Utc) }
                });

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 1,
                column: "SelectedDoctorId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 2,
                column: "SelectedDoctorId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 3,
                column: "SelectedDoctorId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 4,
                column: "SelectedDoctorId",
                value: 2);

            migrationBuilder.CreateIndex(
                name: "IX_Patients_SelectedDoctorId",
                table: "Patients",
                column: "SelectedDoctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Doctors_SelectedDoctorId",
                table: "Patients",
                column: "SelectedDoctorId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Doctors_SelectedDoctorId",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Patients_SelectedDoctorId",
                table: "Patients");

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 1,
                column: "SelectedDoctorId",
                value: 22);

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 2,
                column: "SelectedDoctorId",
                value: 22);

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 3,
                column: "SelectedDoctorId",
                value: 22);

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 4,
                column: "SelectedDoctorId",
                value: 22);
        }
    }
}
