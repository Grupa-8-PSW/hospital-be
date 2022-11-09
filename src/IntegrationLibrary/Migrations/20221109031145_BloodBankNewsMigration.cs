using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IntegrationLibrary.Migrations
{
    public partial class BloodBankNewsMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "BloodBankNews",
                keyColumn: "id",
                keyValue: 1,
                column: "subject",
                value: "subject1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "BloodBankNews",
                keyColumn: "id",
                keyValue: 1,
                column: "subject",
                value: "subject");
        }
    }
}
