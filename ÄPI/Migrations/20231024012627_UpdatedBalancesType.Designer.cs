﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ÄPI.DataAccess;

#nullable disable

namespace ÄPI.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20231024012627_UpdatedBalancesType")]
    partial class UpdatedBalancesType
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.23")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ÄPI.Entities.Account", b =>
                {
                    b.Property<int>("AccountNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AccountNumber"), 1L, 1);

                    b.Property<int>("AccountTypeID")
                        .HasColumnType("int");

                    b.Property<string>("Alias")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<decimal>("Balance")
                        .HasColumnType("DECIMAL(18,3)");

                    b.Property<string>("CBU")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("CurrencyID")
                        .HasColumnType("int");

                    b.Property<string>("UUID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("AccountNumber");

                    b.HasIndex("AccountTypeID");

                    b.HasIndex("CBU")
                        .IsUnique()
                        .HasFilter("[CBU] IS NOT NULL");

                    b.HasIndex("CurrencyID");

                    b.HasIndex("UUID")
                        .IsUnique()
                        .HasFilter("[UUID] IS NOT NULL");

                    b.HasIndex("UserID");

                    b.ToTable("Accounts");

                    b.HasData(
                        new
                        {
                            AccountNumber = 12345,
                            AccountTypeID = 1,
                            Alias = "Cuenta Ahorro Pesos",
                            Balance = 0m,
                            CBU = "1234-5-6789-1111111111111",
                            CurrencyID = 1,
                            UserID = 1
                        },
                        new
                        {
                            AccountNumber = 67891,
                            AccountTypeID = 1,
                            Alias = "Cuenta Ahorro Dolares",
                            Balance = 0m,
                            CBU = "1234-5-6789-2222222222222",
                            CurrencyID = 2,
                            UserID = 1
                        },
                        new
                        {
                            AccountNumber = 54321,
                            AccountTypeID = 2,
                            Alias = "Cuenta BTC",
                            Balance = 0m,
                            CurrencyID = 3,
                            UUID = "A1B2C3D4-E5F6-G8H9-I110-J11K12L13M14",
                            UserID = 1
                        },
                        new
                        {
                            AccountNumber = 78645,
                            AccountTypeID = 1,
                            Alias = "Mis pesitos",
                            Balance = 0m,
                            CBU = "4321-3-9876-3333333333333",
                            CurrencyID = 1,
                            UserID = 2
                        },
                        new
                        {
                            AccountNumber = 78432,
                            AccountTypeID = 2,
                            Alias = "Mi bitcoin",
                            Balance = 0m,
                            CurrencyID = 3,
                            UUID = "D1C2B3A4-F5E6-H8G9-110I-M11L12K13J14",
                            UserID = 2
                        });
                });

            modelBuilder.Entity("ÄPI.Entities.AccountType", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("VARCHAR(30)");

                    b.HasKey("ID");

                    b.ToTable("AccountTypes");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Description = "Fiduciary"
                        },
                        new
                        {
                            ID = 2,
                            Description = "Cryptocurrency"
                        });
                });

            modelBuilder.Entity("ÄPI.Entities.AccountType_Currency", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("AccountTypeID")
                        .HasColumnType("int");

                    b.Property<int>("CurrencyID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("AccountTypeID");

                    b.HasIndex("CurrencyID");

                    b.ToTable("AccountType_Currencies");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            AccountTypeID = 1,
                            CurrencyID = 1
                        },
                        new
                        {
                            ID = 2,
                            AccountTypeID = 1,
                            CurrencyID = 2
                        },
                        new
                        {
                            ID = 3,
                            AccountTypeID = 2,
                            CurrencyID = 3
                        });
                });

            modelBuilder.Entity("ÄPI.Entities.Credentials", b =>
                {
                    b.Property<int>("ID")
                        .HasColumnType("int")
                        .HasColumnName("UserID");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("VARCHAR(75)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("VARCHAR(250)");

                    b.HasKey("ID");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Credentials");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Email = "maxiviand@gmail.com",
                            Password = "6d57ea0e81183fa3650fa1daa22a681125cd0fc3ff6ba2b1a351153f0f5980b0"
                        },
                        new
                        {
                            ID = 2,
                            Email = "gerardviand@gmail.com",
                            Password = "bb033c213cf9f85b975a595aa919cde5dad931fef91cdfd598e27a27ff6185b2"
                        });
                });

            modelBuilder.Entity("ÄPI.Entities.Currency", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("VARCHAR(30)");

                    b.HasKey("ID");

                    b.ToTable("Currencies");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Description = "ARS"
                        },
                        new
                        {
                            ID = 2,
                            Description = "USD"
                        },
                        new
                        {
                            ID = 3,
                            Description = "BTC"
                        });
                });

            modelBuilder.Entity("ÄPI.Entities.CurrencyConvertion", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("From_Currency")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("DECIMAL(18,10)");

                    b.Property<int>("To_Currency")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("From_Currency");

                    b.HasIndex("To_Currency");

                    b.ToTable("CurrenciesConvertions");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            From_Currency = 1,
                            Price = 0.00286m,
                            To_Currency = 2
                        },
                        new
                        {
                            ID = 2,
                            From_Currency = 1,
                            Price = 0.00000008465883m,
                            To_Currency = 3
                        },
                        new
                        {
                            ID = 3,
                            From_Currency = 2,
                            Price = 349.84207m,
                            To_Currency = 1
                        },
                        new
                        {
                            ID = 4,
                            From_Currency = 2,
                            Price = 0.00002962053m,
                            To_Currency = 3
                        },
                        new
                        {
                            ID = 5,
                            From_Currency = 3,
                            Price = 11810780m,
                            To_Currency = 1
                        },
                        new
                        {
                            ID = 6,
                            From_Currency = 3,
                            Price = 33759.98m,
                            To_Currency = 2
                        });
                });

            modelBuilder.Entity("ÄPI.Entities.Transaction", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("AccountID")
                        .HasColumnType("int");

                    b.Property<decimal>("Amount")
                        .HasColumnType("DECIMAL(18,10)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("VARCHAR(40)");

                    b.HasKey("ID");

                    b.HasIndex("AccountID");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("ÄPI.Entities.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("DATE")
                        .HasColumnName("DateOfBirth");

                    b.Property<int>("DNI")
                        .HasMaxLength(8)
                        .HasColumnType("int");

                    b.Property<string>("Fullname")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasColumnType("VARCHAR(25)");

                    b.HasKey("ID");

                    b.HasIndex("DNI")
                        .IsUnique();

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            BirthDate = new DateTime(2002, 8, 27, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DNI = 44380182,
                            Fullname = "Maximo Viand",
                            Genre = "Masculino"
                        },
                        new
                        {
                            ID = 2,
                            BirthDate = new DateTime(1966, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DNI = 40898968,
                            Fullname = "Gerardo Viand",
                            Genre = "Masculino"
                        });
                });

            modelBuilder.Entity("ÄPI.Entities.Account", b =>
                {
                    b.HasOne("ÄPI.Entities.AccountType", "AccountType")
                        .WithMany("Accounts")
                        .HasForeignKey("AccountTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ÄPI.Entities.Currency", "Currency")
                        .WithMany("Accounts")
                        .HasForeignKey("CurrencyID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ÄPI.Entities.User", "User")
                        .WithMany("Accounts")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AccountType");

                    b.Navigation("Currency");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ÄPI.Entities.AccountType_Currency", b =>
                {
                    b.HasOne("ÄPI.Entities.AccountType", "AccountType")
                        .WithMany("AccountType_Currencies")
                        .HasForeignKey("AccountTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ÄPI.Entities.Currency", "Currency")
                        .WithMany("AccountType_Currencies")
                        .HasForeignKey("CurrencyID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AccountType");

                    b.Navigation("Currency");
                });

            modelBuilder.Entity("ÄPI.Entities.Credentials", b =>
                {
                    b.HasOne("ÄPI.Entities.User", "User")
                        .WithOne("Credentials")
                        .HasForeignKey("ÄPI.Entities.Credentials", "ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ÄPI.Entities.CurrencyConvertion", b =>
                {
                    b.HasOne("ÄPI.Entities.Currency", "Currency_From")
                        .WithMany("From_CurrenciesConvertions")
                        .HasForeignKey("From_Currency")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ÄPI.Entities.Currency", "Currency_To")
                        .WithMany("To_CurrenciesConvertions")
                        .HasForeignKey("To_Currency")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Currency_From");

                    b.Navigation("Currency_To");
                });

            modelBuilder.Entity("ÄPI.Entities.Transaction", b =>
                {
                    b.HasOne("ÄPI.Entities.Account", "Account")
                        .WithMany("TransactionsOrigin")
                        .HasForeignKey("AccountID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("ÄPI.Entities.Account", b =>
                {
                    b.Navigation("TransactionsOrigin");
                });

            modelBuilder.Entity("ÄPI.Entities.AccountType", b =>
                {
                    b.Navigation("AccountType_Currencies");

                    b.Navigation("Accounts");
                });

            modelBuilder.Entity("ÄPI.Entities.Currency", b =>
                {
                    b.Navigation("AccountType_Currencies");

                    b.Navigation("Accounts");

                    b.Navigation("From_CurrenciesConvertions");

                    b.Navigation("To_CurrenciesConvertions");
                });

            modelBuilder.Entity("ÄPI.Entities.User", b =>
                {
                    b.Navigation("Accounts");

                    b.Navigation("Credentials")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
