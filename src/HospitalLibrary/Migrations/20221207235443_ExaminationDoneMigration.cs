using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HospitalLibrary.Migrations
{
    public partial class ExaminationDoneMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExaminationsDone",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ExaminationId = table.Column<int>(type: "integer", nullable: false),
                    Record = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExaminationsDone", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExaminationsDone_Examinations_ExaminationId",
                        column: x => x.ExaminationId,
                        principalTable: "Examinations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Prescription",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ExaminationDoneId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescription", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prescription_ExaminationsDone_ExaminationDoneId",
                        column: x => x.ExaminationDoneId,
                        principalTable: "ExaminationsDone",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Symptoms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ExaminationDoneId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Symptoms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Symptoms_ExaminationsDone_ExaminationDoneId",
                        column: x => x.ExaminationDoneId,
                        principalTable: "ExaminationsDone",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "Therapies",
                keyColumn: "Id",
                keyValue: 1,
                column: "WhenPrescribed",
                value: new DateTime(2022, 12, 7, 23, 54, 38, 341, DateTimeKind.Utc).AddTicks(7142));

            migrationBuilder.UpdateData(
                table: "Therapies",
                keyColumn: "Id",
                keyValue: 2,
                column: "WhenPrescribed",
                value: new DateTime(2022, 12, 7, 23, 54, 38, 341, DateTimeKind.Utc).AddTicks(7150));

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 12, 7, 23, 54, 38, 341, DateTimeKind.Utc).AddTicks(6870), new DateTime(2022, 12, 7, 23, 54, 38, 341, DateTimeKind.Utc).AddTicks(6867) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 12, 7, 23, 54, 38, 341, DateTimeKind.Utc).AddTicks(6887), new DateTime(2022, 12, 7, 23, 54, 38, 341, DateTimeKind.Utc).AddTicks(6886) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 12, 7, 23, 54, 38, 341, DateTimeKind.Utc).AddTicks(6891), new DateTime(2022, 12, 7, 23, 54, 38, 341, DateTimeKind.Utc).AddTicks(6890) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 4,
                column: "StartDate",
                value: new DateTime(2022, 12, 7, 23, 54, 38, 341, DateTimeKind.Utc).AddTicks(6893));

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 5,
                column: "StartDate",
                value: new DateTime(2022, 12, 7, 23, 54, 38, 341, DateTimeKind.Utc).AddTicks(6896));

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 6,
                column: "StartDate",
                value: new DateTime(2022, 12, 7, 23, 54, 38, 341, DateTimeKind.Utc).AddTicks(6898));

            migrationBuilder.CreateIndex(
                name: "IX_ExaminationsDone_ExaminationId",
                table: "ExaminationsDone",
                column: "ExaminationId");

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_ExaminationDoneId",
                table: "Prescription",
                column: "ExaminationDoneId");

            migrationBuilder.CreateIndex(
                name: "IX_Symptoms_ExaminationDoneId",
                table: "Symptoms",
                column: "ExaminationDoneId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prescription");

            migrationBuilder.DropTable(
                name: "Symptoms");

            migrationBuilder.DropTable(
                name: "ExaminationsDone");

            migrationBuilder.UpdateData(
                table: "Therapies",
                keyColumn: "Id",
                keyValue: 1,
                column: "WhenPrescribed",
                value: new DateTime(2022, 12, 6, 11, 36, 22, 933, DateTimeKind.Utc).AddTicks(3006));

            migrationBuilder.UpdateData(
                table: "Therapies",
                keyColumn: "Id",
                keyValue: 2,
                column: "WhenPrescribed",
                value: new DateTime(2022, 12, 6, 11, 36, 22, 933, DateTimeKind.Utc).AddTicks(3007));

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 12, 6, 11, 36, 22, 933, DateTimeKind.Utc).AddTicks(2975), new DateTime(2022, 12, 6, 11, 36, 22, 933, DateTimeKind.Utc).AddTicks(2974) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 12, 6, 11, 36, 22, 933, DateTimeKind.Utc).AddTicks(2978), new DateTime(2022, 12, 6, 11, 36, 22, 933, DateTimeKind.Utc).AddTicks(2978) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 12, 6, 11, 36, 22, 933, DateTimeKind.Utc).AddTicks(2979), new DateTime(2022, 12, 6, 11, 36, 22, 933, DateTimeKind.Utc).AddTicks(2979) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 4,
                column: "StartDate",
                value: new DateTime(2022, 12, 6, 11, 36, 22, 933, DateTimeKind.Utc).AddTicks(2980));

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 5,
                column: "StartDate",
                value: new DateTime(2022, 12, 6, 11, 36, 22, 933, DateTimeKind.Utc).AddTicks(2980));

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 6,
                column: "StartDate",
                value: new DateTime(2022, 12, 6, 11, 36, 22, 933, DateTimeKind.Utc).AddTicks(2981));
        }
    }
}
