using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace IntegrationLibrary.Migrations
{
    public partial class BloodBankNewsUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BloodBanks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    ServerAddress = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    APIKey = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BloodBanks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BloodConsumptionConfiguration",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StartDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FrequencyPeriodInHours = table.Column<TimeSpan>(type: "interval", nullable: false),
                    ConsumptionPeriodHours = table.Column<TimeSpan>(type: "interval", nullable: false),
                    NextSendingTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BloodConsumptionConfiguration", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BloodBankNews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Text = table.Column<string>(type: "text", nullable: false),
                    Subject = table.Column<string>(type: "text", nullable: false),
                    ImgSrc = table.Column<string>(type: "text", nullable: false),
                    BloodBankId = table.Column<int>(type: "integer", nullable: false),
                    Published = table.Column<bool>(type: "boolean", nullable: false),
                    Archived = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BloodBankNews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BloodBankNews_BloodBanks_BloodBankId",
                        column: x => x.BloodBankId,
                        principalTable: "BloodBanks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "BloodBanks",
                columns: new[] { "Id", "APIKey", "Email", "Name", "Password", "ServerAddress" },
                values: new object[] { 1, "unknown", "test@test.com", "testName", "unknown", "testServAdd" });

            migrationBuilder.InsertData(
                table: "BloodBankNews",
                columns: new[] { "Id", "Archived", "BloodBankId", "ImgSrc", "Published", "Subject", "Text" },
                values: new object[] { 1, false, 1, "", false, "subject1", "text" });

            migrationBuilder.CreateIndex(
                name: "IX_BloodBankNews_BloodBankId",
                table: "BloodBankNews",
                column: "BloodBankId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BloodBankNews");

            migrationBuilder.DropTable(
                name: "BloodConsumptionConfiguration");

            migrationBuilder.DropTable(
                name: "BloodBanks");
        }
    }
}
