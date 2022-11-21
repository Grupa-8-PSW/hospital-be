﻿// <auto-generated />
using IntegrationLibrary.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace IntegrationLibrary.Migrations
{
    [DbContext(typeof(IntegrationDbContext))]
    partial class IntegrationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
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
                            ServerAddress = "testServAdd"
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


            modelBuilder.Entity("IntegrationLibrary.Core.Model.BloodBankNews", b =>
                {
                    b.HasOne("IntegrationLibrary.Core.Model.BloodBank", "BloodBank")
                        .WithMany()
                        .HasForeignKey("BloodBankId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BloodBank");

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
#pragma warning restore 612, 618

                });
        }
    }
}
