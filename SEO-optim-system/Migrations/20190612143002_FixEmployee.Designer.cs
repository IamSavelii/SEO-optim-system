﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SEO_optim_system.Models;

namespace SEO_optim_system.Migrations
{
    [DbContext(typeof(seoContext))]
    [Migration("20190612143002_FixEmployee")]
    partial class FixEmployee
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SEO_optim_system.Models.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City");

                    b.Property<string>("Country");

                    b.Property<string>("LPR");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("PhoneNumber");

                    b.HasKey("Id");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("SEO_optim_system.Models.Contract", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CompanyId");

                    b.Property<DateTime>("Date");

                    b.Property<int?>("EmployeeId");

                    b.Property<int>("GooglePoz");

                    b.Property<string>("Keywords");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<bool>("OptimImg");

                    b.Property<bool>("OptimTag");

                    b.Property<bool>("OptimText");

                    b.Property<string>("Url")
                        .IsRequired();

                    b.Property<int>("YandexPoz");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Contracts");
                });

            modelBuilder.Entity("SEO_optim_system.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Birthday");

                    b.Property<int>("Department");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<int>("Experience");

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<string>("Patronymic")
                        .IsRequired();

                    b.Property<string>("PhoneNumber");

                    b.Property<string>("Position")
                        .IsRequired();

                    b.Property<string>("SecondName")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("SEO_optim_system.Models.Report", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Activity");

                    b.Property<int?>("ContractId");

                    b.Property<DateTime>("Date");

                    b.Property<int?>("EmployeeId");

                    b.HasKey("Id");

                    b.HasIndex("ContractId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Reports");
                });

            modelBuilder.Entity("SEO_optim_system.Models.Contract", b =>
                {
                    b.HasOne("SEO_optim_system.Models.Company", "Company")
                        .WithMany("Contracts")
                        .HasForeignKey("CompanyId");

                    b.HasOne("SEO_optim_system.Models.Employee", "Employee")
                        .WithMany("Contracts")
                        .HasForeignKey("EmployeeId");
                });

            modelBuilder.Entity("SEO_optim_system.Models.Report", b =>
                {
                    b.HasOne("SEO_optim_system.Models.Contract", "Contract")
                        .WithMany("Reports")
                        .HasForeignKey("ContractId");

                    b.HasOne("SEO_optim_system.Models.Employee", "Employee")
                        .WithMany("Reports")
                        .HasForeignKey("EmployeeId");
                });
#pragma warning restore 612, 618
        }
    }
}
