using System;
using System.Collections.Generic;
using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Core.Model.ValueObject;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace IntegrationLibrary.Migrations
{
    public partial class bloodBankNewsSeed : Migration
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
                    APIKey = table.Column<string>(type: "text", nullable: false),
                    MonthlySubscriptionRoutingKey = table.Column<string>(type: "text", nullable: false)
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
                name: "TenderOffer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TenderID = table.Column<int>(type: "integer", nullable: false),
                    Offers = table.Column<List<BloodOffer>>(type: "jsonb", nullable: false),
                    BloodBankName = table.Column<string>(type: "text", nullable: false),
                    TenderOfferStatus = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenderOffer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tenders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    DateRange = table.Column<DateRange>(type: "jsonb", nullable: false),
                    Blood = table.Column<List<Blood>>(type: "jsonb", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UrgentRequest",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BloodBankId = table.Column<int>(type: "integer", nullable: false),
                    ObtainedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Blood = table.Column<List<Blood>>(type: "jsonb", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UrgentRequest", x => x.Id);
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

            migrationBuilder.CreateTable(
                name: "BloodRequestDelivery",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    AmountL = table.Column<int>(type: "integer", nullable: false),
                    DeliveryDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    BloodBankId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BloodRequestDelivery", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BloodRequestDelivery_BloodBanks_BloodBankId",
                        column: x => x.BloodBankId,
                        principalTable: "BloodBanks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MonthlySubscription",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RequestedBlood = table.Column<List<Blood>>(type: "jsonb", nullable: false),
                    DeliveryDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    BankId = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonthlySubscription", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MonthlySubscription_BloodBanks_BankId",
                        column: x => x.BankId,
                        principalTable: "BloodBanks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "BloodBanks",
                columns: new[] { "Id", "APIKey", "Email", "MonthlySubscriptionRoutingKey", "Name", "Password", "ServerAddress" },
                values: new object[,]
                {
                    { 1, "123", "test@test.com", "monthlySubscriptions29", "Banka 1", "unknown", "http://localhost:8081/" },
                    { 2, "321", "test@test.com", "monthlySubscriptions30", "Banka 2", "unknown", "http://localhost:8082/" },
                    { 3, "213", "test@test.com", "monthlySubscriptions31", "Banka 3", "unknown", "http://localhost:8083/" },
                    { 4, "231", "test@test.com", "monthlySubscriptions32", "Banka 4", "unknown", "http://localhost:8084/" }
                });

            migrationBuilder.InsertData(
                table: "BloodBankNews",
                columns: new[] { "Id", "Archived", "BloodBankId", "ImgSrc", "Published", "Subject", "Text" },
                values: new object[,]
                {
                    { 1, false, 1, "https://firebasestorage.googleapis.com/v0/b/isapsw-6ef61.appspot.com/o/9d54ef85-6fe8be15-untitled-10_850x460_acf_cropped.jpg?alt=media&token=3f080d8d-6bc1-4757-83ef-0dabfb6ea338", false, "Nestasica krvi", "Zbog konstantnog manjka krvi u odnosu na potrebe (posebno tokom praznika) i ovaj put organizujemo celodnevnu novogodisnju akciju davanja krvi. Krv mozete dati 26. janura od 8 do 13 ili od 15 do 18 casova. Ne sumnjamo u vasu humanost" },
                    { 2, false, 2, "https://firebasestorage.googleapis.com/v0/b/isapsw-6ef61.appspot.com/o/h3.jpg?alt=media&token=482263cb-3590-405f-9c1e-e1fcd46b5229", false, "Novogodisnja akcija davanja krvi", "Prva ovogodisnja akcija davanja krvi bice realizovana u ponedeljak 09. januara od 8 do 12 casova. Zapocnite godinu humanim gestom i pomozite onima koji vam to nikada ne mogu vratiti." },
                    { 3, false, 3, "https://firebasestorage.googleapis.com/v0/b/isapsw-6ef61.appspot.com/o/h4.jpeg?alt=media&token=5b420fc6-e490-453c-afce-5d57241eda35", false, "Nova akcija doniranja", "U ponedeljak, 05. decembra, od 8 do 12 casova realizuje se akcija dobrovoljnog davanja krvi u prostorijama Doma zdravlja. Kako je neuporedivo lepsi osecaj pomagati nego cekati pomoc od nekog pozivamo vas da i ovoga puta pokazete svoju humanost i spasete do tri zivota. " },
                    { 4, false, 4, "https://firebasestorage.googleapis.com/v0/b/isapsw-6ef61.appspot.com/o/Blood-Donation-1.jpg?alt=media&token=71f3c7ae-e5a0-4d51-ade8-1e253deb212d", false, "Hitno potrebna krv!", "Vreme je novogodisnjeg darivanja. Darujte zivot na jednoj od dve akcije davanja krvi tokom sledece sedmice.  \r\nPonedeljak 20. ili cetvrtak 23. decembar u istom terminu - od 16 do 19 casova" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BloodBankNews_BloodBankId",
                table: "BloodBankNews",
                column: "BloodBankId");

            migrationBuilder.CreateIndex(
                name: "IX_BloodRequestDelivery_BloodBankId",
                table: "BloodRequestDelivery",
                column: "BloodBankId");

            migrationBuilder.CreateIndex(
                name: "IX_MonthlySubscription_BankId",
                table: "MonthlySubscription",
                column: "BankId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BloodBankNews");

            migrationBuilder.DropTable(
                name: "BloodConsumptionConfiguration");

            migrationBuilder.DropTable(
                name: "BloodRequestDelivery");

            migrationBuilder.DropTable(
                name: "MonthlySubscription");

            migrationBuilder.DropTable(
                name: "TenderOffer");

            migrationBuilder.DropTable(
                name: "Tenders");

            migrationBuilder.DropTable(
                name: "UrgentRequest");

            migrationBuilder.DropTable(
                name: "BloodBanks");
        }
    }
}
