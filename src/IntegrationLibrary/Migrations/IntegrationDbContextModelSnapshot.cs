﻿// <auto-generated />
using System;
using System.Collections.Generic;
using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Core.Model.ValueObject;
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

                    b.Property<string>("MonthlySubscriptionRoutingKey")
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
                            APIKey = "123",
                            Email = "test@test.com",
                            MonthlySubscriptionRoutingKey = "monthlySubscriptions29",
                            Name = "Banka 1",
                            Password = "unknown",
                            ServerAddress = "http://localhost:8081/"
                        },
                        new
                        {
                            Id = 2,
                            APIKey = "321",
                            Email = "test@test.com",
                            MonthlySubscriptionRoutingKey = "monthlySubscriptions30",
                            Name = "Banka 2",
                            Password = "unknown",
                            ServerAddress = "http://localhost:8082/"
                        },
                        new
                        {
                            Id = 3,
                            APIKey = "213",
                            Email = "test@test.com",
                            MonthlySubscriptionRoutingKey = "monthlySubscriptions31",
                            Name = "Banka 3",
                            Password = "unknown",
                            ServerAddress = "http://localhost:8083/"
                        },
                        new
                        {
                            Id = 4,
                            APIKey = "231",
                            Email = "test@test.com",
                            MonthlySubscriptionRoutingKey = "monthlySubscriptions32",
                            Name = "Banka 4",
                            Password = "unknown",
                            ServerAddress = "http://localhost:8084/"
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
                            ImgSrc = "https://firebasestorage.googleapis.com/v0/b/isapsw-6ef61.appspot.com/o/9d54ef85-6fe8be15-untitled-10_850x460_acf_cropped.jpg?alt=media&token=3f080d8d-6bc1-4757-83ef-0dabfb6ea338",
                            Published = false,
                            Subject = "Nestasica krvi",
                            Text = "Zbog konstantnog manjka krvi u odnosu na potrebe (posebno tokom praznika) i ovaj put organizujemo celodnevnu novogodisnju akciju davanja krvi. Krv mozete dati 26. janura od 8 do 13 ili od 15 do 18 casova. Ne sumnjamo u vasu humanost"
                        },
                        new
                        {
                            Id = 2,
                            Archived = false,
                            BloodBankId = 2,
                            ImgSrc = "https://firebasestorage.googleapis.com/v0/b/isapsw-6ef61.appspot.com/o/h3.jpg?alt=media&token=482263cb-3590-405f-9c1e-e1fcd46b5229",
                            Published = false,
                            Subject = "Novogodisnja akcija davanja krvi",
                            Text = "Prva ovogodisnja akcija davanja krvi bice realizovana u ponedeljak 09. januara od 8 do 12 casova. Zapocnite godinu humanim gestom i pomozite onima koji vam to nikada ne mogu vratiti."
                        },
                        new
                        {
                            Id = 3,
                            Archived = false,
                            BloodBankId = 3,
                            ImgSrc = "https://firebasestorage.googleapis.com/v0/b/isapsw-6ef61.appspot.com/o/h4.jpeg?alt=media&token=5b420fc6-e490-453c-afce-5d57241eda35",
                            Published = false,
                            Subject = "Nova akcija doniranja",
                            Text = "U ponedeljak, 05. decembra, od 8 do 12 casova realizuje se akcija dobrovoljnog davanja krvi u prostorijama Doma zdravlja. Kako je neuporedivo lepsi osecaj pomagati nego cekati pomoc od nekog pozivamo vas da i ovoga puta pokazete svoju humanost i spasete do tri zivota. "
                        },
                        new
                        {
                            Id = 4,
                            Archived = false,
                            BloodBankId = 4,
                            ImgSrc = "https://firebasestorage.googleapis.com/v0/b/isapsw-6ef61.appspot.com/o/Blood-Donation-1.jpg?alt=media&token=71f3c7ae-e5a0-4d51-ade8-1e253deb212d",
                            Published = false,
                            Subject = "Hitno potrebna krv!",
                            Text = "Vreme je novogodisnjeg darivanja. Darujte zivot na jednoj od dve akcije davanja krvi tokom sledece sedmice.  \r\nPonedeljak 20. ili cetvrtak 23. decembar u istom terminu - od 16 do 19 casova"
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

            modelBuilder.Entity("IntegrationLibrary.Core.Model.BloodRequestDelivery", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AmountL")
                        .HasColumnType("integer");

                    b.Property<int>("BloodBankId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("DeliveryDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("BloodBankId");

                    b.ToTable("BloodRequestDelivery");
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

                    b.Property<string>("BloodBankName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<List<BloodOffer>>("Offers")
                        .IsRequired()
                        .HasColumnType("jsonb");

                    b.Property<int>("TenderID")
                        .HasColumnType("integer");

                    b.Property<int>("TenderOfferStatus")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("TenderOffer");
                });

            modelBuilder.Entity("IntegrationLibrary.Core.Model.UrgentRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<List<Blood>>("Blood")
                        .IsRequired()
                        .HasColumnType("jsonb");

                    b.Property<int>("BloodBankId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("ObtainedDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("UrgentRequest");
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

            modelBuilder.Entity("IntegrationLibrary.Core.Model.BloodRequestDelivery", b =>
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
