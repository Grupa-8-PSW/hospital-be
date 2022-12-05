using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalLibrary.Migrations
{
    public partial class Added_Consiliums_To_Doctor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Consiliums_ConsiliumId",
                table: "Doctors");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_ConsiliumId",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "ConsiliumId",
                table: "Doctors");

            migrationBuilder.CreateTable(
                name: "ConsiliumDoctor",
                columns: table => new
                {
                    ConsiliumsId = table.Column<int>(type: "integer", nullable: false),
                    DoctorsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsiliumDoctor", x => new { x.ConsiliumsId, x.DoctorsId });
                    table.ForeignKey(
                        name: "FK_ConsiliumDoctor_Consiliums_ConsiliumsId",
                        column: x => x.ConsiliumsId,
                        principalTable: "Consiliums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConsiliumDoctor_Doctors_DoctorsId",
                        column: x => x.DoctorsId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConsiliumDoctor_DoctorsId",
                table: "ConsiliumDoctor",
                column: "DoctorsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConsiliumDoctor");

            migrationBuilder.AddColumn<int>(
                name: "ConsiliumId",
                table: "Doctors",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_ConsiliumId",
                table: "Doctors",
                column: "ConsiliumId");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Consiliums_ConsiliumId",
                table: "Doctors",
                column: "ConsiliumId",
                principalTable: "Consiliums",
                principalColumn: "Id");
        }
    }
}
