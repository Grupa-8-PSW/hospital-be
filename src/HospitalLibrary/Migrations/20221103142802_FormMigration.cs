using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HospitalLibrary.Migrations
{
    public partial class FormMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Forms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    StartHourWorkDay = table.Column<string>(type: "text", nullable: false),
                    EndHourWorkDay = table.Column<string>(type: "text", nullable: false),
                    StartHourSaturday = table.Column<string>(type: "text", nullable: false),
                    EndHourSaturday = table.Column<string>(type: "text", nullable: false),
                    StartHourSunday = table.Column<string>(type: "text", nullable: false),
                    EndHourSunday = table.Column<string>(type: "text", nullable: false),
                    RoomId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Forms", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Forms",
                columns: new[] { "Id", "Description", "EndHourSaturday", "EndHourSunday", "EndHourWorkDay", "Name", "RoomId", "StartHourSaturday", "StartHourSunday", "StartHourWorkDay" },
                values: new object[,]
                {
                    { 1, "Pregledi za decu", "17:00h", "CLOSED", "17:00h", "101,Pedijatrija", 1, "12:00h", "CLOSED", "10:00h" },
                    { 2, "Opustanje za radnike i posetioce", "17:00h", "CLOSED", "17:00h", "102,Kafeterija", 2, "12:00h", "CLOSED", "10:00h" },
                    { 3, "UHO,GRLO,NOS", "17:00h", "CLOSED", "17:00h", "103,Otorinolaringologija", 3, "12:00h", "CLOSED", "10:00h" },
                    { 4, "Pregled misica i povreda", "17:00h", "CLOSED", "17:00h", "201,Fizioterapeut", 4, "12:00h", "CLOSED", "10:00h" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Forms");
        }
    }
}
