﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WalletAPI;

#nullable disable

namespace WalletAPI.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20230122134749_FixWalletModel")]
    partial class FixWalletModel
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WalletAPI.Model.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Patronymic")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customer");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FirstName = "Пётр",
                            LastName = "Сидоров",
                            Name = "Сидоров Пётр Олегович",
                            Patronymic = "Олегович"
                        },
                        new
                        {
                            Id = 2,
                            FirstName = "Музаффар",
                            LastName = "Усманов",
                            Name = "Усманов Музаффар Шавкатович",
                            Patronymic = "Шавкатович"
                        },
                        new
                        {
                            Id = 3,
                            FirstName = "Лола",
                            LastName = "Усманова",
                            Name = "Усманова Лола Юсуповна",
                            Patronymic = "Юсуповна"
                        },
                        new
                        {
                            Id = 4,
                            FirstName = "Надежда",
                            LastName = "Смирнова",
                            Name = "Смирнова Надежда Николаевна",
                            Patronymic = "Николаевна"
                        });
                });

            modelBuilder.Entity("WalletAPI.Model.Operation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.Property<int>("WalletId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Operation");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Amount = 1000.0,
                            Time = new DateTime(2022, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            WalletId = 3
                        },
                        new
                        {
                            Id = 2,
                            Amount = 2000.0,
                            Time = new DateTime(2023, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            WalletId = 3
                        },
                        new
                        {
                            Id = 3,
                            Amount = 1000.0,
                            Time = new DateTime(2023, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            WalletId = 3
                        },
                        new
                        {
                            Id = 4,
                            Amount = 12000.0,
                            Time = new DateTime(2023, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            WalletId = 3
                        },
                        new
                        {
                            Id = 5,
                            Amount = 100.0,
                            Time = new DateTime(2018, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            WalletId = 2
                        },
                        new
                        {
                            Id = 6,
                            Amount = 100.0,
                            Time = new DateTime(2023, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            WalletId = 2
                        },
                        new
                        {
                            Id = 7,
                            Amount = 260.0,
                            Time = new DateTime(2023, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            WalletId = 2
                        });
                });

            modelBuilder.Entity("WalletAPI.Model.Wallet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Account")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Balance")
                        .HasColumnType("float");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<bool>("IsIdentified")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Wallet");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Account = "2261684300342121200",
                            Balance = 0.0,
                            CustomerId = 1,
                            IsIdentified = true,
                            Name = "Кошелёк 1"
                        },
                        new
                        {
                            Id = 2,
                            Account = "2261684300214141200",
                            Balance = 460.0,
                            CustomerId = 2,
                            IsIdentified = false,
                            Name = "Кошелёк 2"
                        },
                        new
                        {
                            Id = 3,
                            Account = "2261684300897141200",
                            Balance = 16000.0,
                            CustomerId = 3,
                            IsIdentified = true,
                            Name = "Кошелёк 2"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
