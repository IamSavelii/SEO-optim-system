﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SEO_optim_system.Models;

namespace SEO_optim_system.Migrations
{
    [DbContext(typeof(seoContext))]
    partial class seoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

            modelBuilder.Entity("SEO_optim_system.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Birthday");

                    b.Property<int>("Department");

                    b.Property<int>("Experience");

                    b.Property<string>("FirstName")
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

            modelBuilder.Entity("SEO_optim_system.Models.Requirement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GooglePoz");

                    b.Property<string>("Keywords");

                    b.Property<bool>("OptimImg");

                    b.Property<bool>("OptimTag");

                    b.Property<bool>("OptimText");

                    b.Property<int>("YandexPoz");

                    b.HasKey("Id");

                    b.ToTable("Requirements");
                });
#pragma warning restore 612, 618
        }
    }
}
