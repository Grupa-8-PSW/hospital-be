using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IntegrationLibrary.Migrations
{
    public partial class migracijaname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "BloodBanks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "Name" },
                values: new object[] { "nbloodbank@mail.com", "National blood bank" });

            migrationBuilder.UpdateData(
                table: "BloodBanks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Email", "Name" },
                values: new object[] { "bloodsource@mail.com", "BloodSource" });

            migrationBuilder.UpdateData(
                table: "BloodBanks",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Email", "Name" },
                values: new object[] { "bloodalliance@mail.com", "The Blood Alliance" });

            migrationBuilder.UpdateData(
                table: "BloodBanks",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Email", "Name" },
                values: new object[] { "fingercross@mail.com", "Finger cross" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "BloodBanks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "Name" },
                values: new object[] { "test@test.com", "Banka 1" });

            migrationBuilder.UpdateData(
                table: "BloodBanks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Email", "Name" },
                values: new object[] { "test@test.com", "Banka 2" });

            migrationBuilder.UpdateData(
                table: "BloodBanks",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Email", "Name" },
                values: new object[] { "test@test.com", "Banka 3" });

            migrationBuilder.UpdateData(
                table: "BloodBanks",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Email", "Name" },
                values: new object[] { "test@test.com", "Banka 4" });
        }
    }
}
