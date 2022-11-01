using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IntegrationLibrary.Migrations
{
    public partial class mig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "APIKey",
                table: "BloodBanks",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "BloodBanks",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "BloodBanks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "APIKey", "Password" },
                values: new object[] { "unknown", "unknown" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "APIKey",
                table: "BloodBanks");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "BloodBanks");
        }
    }
}
