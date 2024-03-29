﻿// <auto-generated />
using System;
using Hr_Portal.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HrPortal.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230308120725_Updated resume nullable")]
    partial class Updatedresumenullable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Hr_Portal.Models.LoginModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Logins");
                });

            modelBuilder.Entity("Hr_Portal.Models.ResumeModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Comments")
                        .HasColumnType("nvarchar(MAX)");

                    b.Property<long>("ContactNo")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("Dates")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Experience")
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Qualification")
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Reference")
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("ResumeFilePath")
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("ResumeName")
                        .HasColumnType("nvarchar(255)");

                    b.Property<int?>("Score")
                        .HasColumnType("int");

                    b.Property<string>("SkillSet")
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("TestTaken")
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Resumes");
                });
#pragma warning restore 612, 618
        }
    }
}
