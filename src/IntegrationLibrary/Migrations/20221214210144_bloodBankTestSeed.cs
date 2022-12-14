using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IntegrationLibrary.Migrations
{
    public partial class bloodBankTestSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "BloodBanks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "MonthlySubscriptionRoutingKey", "Name", "ServerAddress" },
                values: new object[] { "monthlySubscriptions29", "Banka 1", "http://localhost:8081/" });

            migrationBuilder.InsertData(
                table: "BloodBanks",
                columns: new[] { "Id", "APIKey", "Email", "MonthlySubscriptionRoutingKey", "Name", "Password", "ServerAddress" },
                values: new object[,]
                {
                    { 2, "321", "test@test.com", "monthlySubscriptions30", "Banka 2", "unknown", "http://localhost:8082/" },
                    { 3, "213", "test@test.com", "monthlySubscriptions31", "Banka 3", "unknown", "http://localhost:8083/" },
                    { 4, "231", "test@test.com", "monthlySubscriptions32", "Banka 4", "unknown", "http://localhost:8084/" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BloodBanks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BloodBanks",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "BloodBanks",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "BloodBanks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "MonthlySubscriptionRoutingKey", "Name", "ServerAddress" },
                values: new object[] { "monthlySubscriptionsRoutingKey29", "bloodBank", "htttp://localhost:8081/" });
        }
    }
}
