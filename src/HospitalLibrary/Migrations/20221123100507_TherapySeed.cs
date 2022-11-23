using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalLibrary.Migrations
{
    public partial class TherapySeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Therapies",
                columns: new[] { "Id", "Amount", "DoctorId", "Reason", "TherapySubject", "TherapyType", "TreatmentHistoryId", "WhenPrescribed" },
                values: new object[,]
                {
                    { 1, 1, 1, "Headache", "Bromazepam 500mg", 0, 1, new DateTime(2022, 11, 23, 11, 5, 6, 620, DateTimeKind.Utc).AddTicks(3872) },
                    { 2, 1, 2, "Blood loss", "A+ 500ml", 1, 1, new DateTime(2022, 11, 23, 11, 5, 6, 620, DateTimeKind.Utc).AddTicks(3905) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Therapies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Therapies",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
