using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HospitalLibrary.Migrations
{
    public partial class Updated_Perscriptions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PrescriptionItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MedicalDrugId = table.Column<int>(type: "integer", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    PrescriptionId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrescriptionItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrescriptionItem_MedicalDrugs_MedicalDrugId",
                        column: x => x.MedicalDrugId,
                        principalTable: "MedicalDrugs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PrescriptionItem_Prescription_PrescriptionId",
                        column: x => x.PrescriptionId,
                        principalTable: "Prescription",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PrescriptionItem_MedicalDrugId",
                table: "PrescriptionItem",
                column: "MedicalDrugId");

            migrationBuilder.CreateIndex(
                name: "IX_PrescriptionItem_PrescriptionId",
                table: "PrescriptionItem",
                column: "PrescriptionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PrescriptionItem");
        }
    }
}
