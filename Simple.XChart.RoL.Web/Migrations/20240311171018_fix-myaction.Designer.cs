﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Simple.XChart.RoL.Common.Data;

#nullable disable

namespace Simple.XChart.RoL.Web.Migrations
{
    [DbContext(typeof(RoLDBContext))]
    [Migration("20240311171018_fix-myaction")]
    partial class fixmyaction
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.27")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Simple.XChart.RoL.Common.Entities.AppInformation", b =>
                {
                    b.Property<string>("InfoKey")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("InfoValue")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("InfoKey");

                    b.ToTable("AppInformations");

                    b.HasData(
                        new
                        {
                            InfoKey = "PhotoTheme",
                            DateUpdated = new DateTime(2024, 3, 12, 6, 10, 18, 151, DateTimeKind.Local).AddTicks(4529),
                            InfoValue = "natural landscape"
                        });
                });

            modelBuilder.Entity("Simple.XChart.RoL.Common.Entities.AttachVerse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("BibleId")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("BookId")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ChapterId")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("DailyReflectionId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VerseId")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("AttachVerses");
                });

            modelBuilder.Entity("Simple.XChart.RoL.Common.Entities.BannerImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AverageColor")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImageAlt")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("ImageLandscapeUrl")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("Photographer")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("PhotographerUrl")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.HasKey("Id");

                    b.ToTable("BannerImages");
                });

            modelBuilder.Entity("Simple.XChart.RoL.Common.Entities.ChartOccurence", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("DaysCount")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Occurences");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DaysCount = 1,
                            Description = "Daily"
                        },
                        new
                        {
                            Id = 2,
                            DaysCount = 7,
                            Description = "Weekly"
                        },
                        new
                        {
                            Id = 3,
                            DaysCount = 30,
                            Description = "Montly"
                        });
                });

            modelBuilder.Entity("Simple.XChart.RoL.Common.Entities.ChartPeriod", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DateEnd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateStart")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("ChartPeriods");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateEnd = new DateTime(2024, 7, 10, 6, 10, 18, 151, DateTimeKind.Local).AddTicks(4500),
                            DateStart = new DateTime(2024, 3, 12, 6, 10, 18, 151, DateTimeKind.Local).AddTicks(4473),
                            Description = "Guide thru Easter",
                            Title = "Lent"
                        });
                });

            modelBuilder.Entity("Simple.XChart.RoL.Common.Entities.ChartPeriodMap", b =>
                {
                    b.Property<int>("ChartPeriodId")
                        .HasColumnType("int");

                    b.Property<int>("DailyReflectionId")
                        .HasColumnType("int");

                    b.Property<int>("MyPracticeId")
                        .HasColumnType("int");

                    b.Property<int>("OccurenceId")
                        .HasColumnType("int");

                    b.ToTable("ChartPeriodMap");
                });

            modelBuilder.Entity("Simple.XChart.RoL.Common.Entities.DailyReflection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("DailyReflrections");
                });

            modelBuilder.Entity("Simple.XChart.RoL.Common.Entities.MyAction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ChartPeriodId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<int>("OccurenceId")
                        .HasColumnType("int");

                    b.Property<int>("PracticeId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("MyActions");
                });

            modelBuilder.Entity("Simple.XChart.RoL.Common.Entities.MyGoal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("TaskPeriodId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("MyGoals");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Be With Jesus",
                            TaskPeriodId = 1
                        },
                        new
                        {
                            Id = 2,
                            Description = "Become Like Jesus",
                            TaskPeriodId = 1
                        },
                        new
                        {
                            Id = 3,
                            Description = "Do what Jesus did",
                            TaskPeriodId = 1
                        });
                });

            modelBuilder.Entity("Simple.XChart.RoL.Common.Entities.MyPractice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("GoalId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("MyPractices");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Silence & Solitude",
                            GoalId = 1
                        },
                        new
                        {
                            Id = 2,
                            Description = "Scripture",
                            GoalId = 1
                        },
                        new
                        {
                            Id = 3,
                            Description = "Prayer",
                            GoalId = 1
                        },
                        new
                        {
                            Id = 4,
                            Description = "Community",
                            GoalId = 2
                        },
                        new
                        {
                            Id = 5,
                            Description = "Sabbath",
                            GoalId = 2
                        },
                        new
                        {
                            Id = 6,
                            Description = "Vocation",
                            GoalId = 3
                        },
                        new
                        {
                            Id = 7,
                            Description = "Hospitality",
                            GoalId = 3
                        },
                        new
                        {
                            Id = 8,
                            Description = "Simplicity",
                            GoalId = 3
                        });
                });

            modelBuilder.Entity("Simple.XChart.RoL.Common.Entities.MyPRacticeDailyReflectionMap", b =>
                {
                    b.Property<int>("DailyReflectionId")
                        .HasColumnType("int");

                    b.Property<int>("MyPracticeId")
                        .HasColumnType("int");

                    b.ToTable("MyPracticeDailyReflrectionMap");
                });
#pragma warning restore 612, 618
        }
    }
}