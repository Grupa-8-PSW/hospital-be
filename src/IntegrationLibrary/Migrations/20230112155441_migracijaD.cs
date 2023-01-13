using System;
using System.Collections.Generic;
using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Core.Model.ValueObject;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace IntegrationLibrary.Migrations
{
    public partial class migracijaD : Migration
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
                    Image = table.Column<string>(type: "text", nullable: false),
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
                columns: new[] { "Id", "APIKey", "Email", "Image", "MonthlySubscriptionRoutingKey", "Name", "Password", "ServerAddress" },
                values: new object[,]
                {
                    { 1, "123", "test@test.com", "https://firebasestorage.googleapis.com/v0/b/isapsw-6ef61.appspot.com/o/hospital%20images%2Fhospital2.jpg?alt=media&token=86e5b815-e371-4b88-9411-fc5e6cc179df", "monthlySubscriptions29", "Banka 1", "unknown", "http://localhost:8081/" },
                    { 2, "321", "test@test.com", "https://firebasestorage.googleapis.com/v0/b/isapsw-6ef61.appspot.com/o/hospital%20images%2Fhospital3.jpg?alt=media&token=522f1c18-ae7f-494b-b696-091fac455630", "monthlySubscriptions30", "Banka 2", "unknown", "http://localhost:8082/" },
                    { 3, "213", "test@test.com", "https://firebasestorage.googleapis.com/v0/b/isapsw-6ef61.appspot.com/o/hospital%20images%2Fhospital4.jpg?alt=media&token=415ce5f8-c22d-4090-9ee2-3960d10a2b25", "monthlySubscriptions31", "Banka 3", "unknown", "http://localhost:8083/" },
                    { 4, "231", "test@test.com", "https://firebasestorage.googleapis.com/v0/b/isapsw-6ef61.appspot.com/o/hospital%20images%2Fhospital1.jpg?alt=media&token=db040d31-6fb8-4615-a875-3ff3f4aa78f5", "monthlySubscriptions32", "Banka 4", "unknown", "http://localhost:8084/" }
                });

            migrationBuilder.InsertData(
                table: "BloodBankNews",
                columns: new[] { "Id", "Archived", "BloodBankId", "ImgSrc", "Published", "Subject", "Text" },
                values: new object[] { 1, false, 1, "", false, "subject1", "text" });

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
