using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HospitalLibrary.Migrations
{
    public partial class Added_Consiliums : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ConsiliumId",
                table: "Doctors",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Consiliums",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Subject = table.Column<string>(type: "text", nullable: false),
                    Interval_From = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Interval_To = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Duration = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consiliums", x => x.Id);
                });


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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Consiliums_ConsiliumId",
                table: "Doctors");

            migrationBuilder.DropTable(
                name: "Consiliums");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_ConsiliumId",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "ConsiliumId",
                table: "Doctors");

        }
    }
}
