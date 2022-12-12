﻿// <auto-generated />
using System;
using System.Collections.Generic;
using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Core.Model.ValueObject;
using IntegrationLibrary.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace IntegrationLibrary.Migrations
{
    [DbContext(typeof(IntegrationDbContext))]
    [Migration("20221211170222_djoni")]
    partial class djoni
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("IntegrationLibrary.Core.Model.BloodBank", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("APIKey")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ServerAddress")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("BloodBanks");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            APIKey = "unknown",
                            Email = "test@test.com",
                            Name = "testName",
                            Password = "unknown",
                            ServerAddress = "htttp://localhost:8081/"
                        });
                });

            modelBuilder.Entity("IntegrationLibrary.Core.Model.BloodBankNews", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("Archived")
                        .HasColumnType("boolean");

                    b.Property<int>("BloodBankId")
                        .HasColumnType("integer");

                    b.Property<string>("ImgSrc")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("Published")
                        .HasColumnType("boolean");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("BloodBankId");

                    b.ToTable("BloodBankNews");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Archived = false,
                            BloodBankId = 1,
                            ImgSrc = "",
                            Published = false,
                            Subject = "subject1",
                            Text = "text"
                        });
                });

            modelBuilder.Entity("IntegrationLibrary.Core.Model.BloodConsumptionConfiguration", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<TimeSpan>("ConsumptionPeriodHours")
                        .HasColumnType("interval");

                    b.Property<TimeSpan>("FrequencyPeriodInHours")
                        .HasColumnType("interval");

                    b.Property<DateTime>("NextSendingTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("StartDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("BloodConsumptionConfiguration");
                });

            modelBuilder.Entity("IntegrationLibrary.Core.Model.MonthlySubscription", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("BankId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("DeliveryDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<List<Blood>>("RequestedBlood")
                        .IsRequired()
                        .HasColumnType("jsonb");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("BankId");

                    b.ToTable("MonthlySubscription");
                });

            modelBuilder.Entity("IntegrationLibrary.Core.Model.Tender", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<List<Blood>>("Blood")
                        .IsRequired()
                        .HasColumnType("jsonb");

                    b.Property<DateRange>("DateRange")
                        .IsRequired()
                        .HasColumnType("jsonb");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Tenders");
                });

            modelBuilder.Entity("IntegrationLibrary.Core.Model.TenderOffer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<List<BloodOffer>>("Offers")
                        .IsRequired()
                        .HasColumnType("jsonb");

                    b.Property<int>("TenderID")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("TenderOffer");
                });

            modelBuilder.Entity("IntegrationLibrary.Core.Model.BloodBankNews", b =>
                {
                    b.HasOne("IntegrationLibrary.Core.Model.BloodBank", "BloodBank")
                        .WithMany()
                        .HasForeignKey("BloodBankId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BloodBank");
                });

            modelBuilder.Entity("IntegrationLibrary.Core.Model.MonthlySubscription", b =>
                {
                    b.HasOne("IntegrationLibrary.Core.Model.BloodBank", "Bank")
                        .WithMany()
                        .HasForeignKey("BankId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bank");
                });
#pragma warning restore 612, 618
        }
    }
}
