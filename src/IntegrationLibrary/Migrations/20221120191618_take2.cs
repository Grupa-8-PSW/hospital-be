using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace IntegrationLibrary.Migrations
{
    public partial class take2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BloodBankNews",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    text = table.Column<string>(type: "text", nullable: false),
                    subject = table.Column<string>(type: "text", nullable: false),
                    byteArray = table.Column<byte[]>(type: "bytea", nullable: false),
                    published = table.Column<bool>(type: "boolean", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BloodBankNews", x => x.id);
                });

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

            migrationBuilder.InsertData(
                table: "BloodBankNews",
                columns: new[] { "id", "archived", "byteArray", "published", "subject", "text" },
                values: new object[] { 1, false, new byte[0], false, "subject1", "text" });

            migrationBuilder.InsertData(
                table: "BloodBanks",
                columns: new[] { "Id", "APIKey", "Email", "Name", "Password", "ServerAddress" },
                values: new object[] { 1, "unknown", "test@test.com", "testName", "unknown", "testServAdd" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BloodBankNews");

            migrationBuilder.DropTable(
                name: "BloodBanks");

            migrationBuilder.DropTable(
                name: "BloodConsumptionConfiguration");
        }
    }
}
