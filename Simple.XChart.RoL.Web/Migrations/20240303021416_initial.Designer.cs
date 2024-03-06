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
    [Migration("20240303021416_initial")]
    partial class initial
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
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InfoValue")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("AppInformations");
                });

            modelBuilder.Entity("Simple.XChart.RoL.Common.Entities.AttachVerse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("BibleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MyActionId")
                        .HasColumnType("int");

                    b.Property<string>("VerseId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AttachVerses");
                });

            modelBuilder.Entity("Simple.XChart.RoL.Common.Entities.BannerImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImageAlt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageLandscapeUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Photographer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhotographerUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("BannerImages");
                });

            modelBuilder.Entity("Simple.XChart.RoL.Common.Entities.MyAction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Occurence")
                        .HasColumnType("int");

                    b.Property<int>("PracticeId")
                        .HasColumnType("int");

                    b.Property<int>("TaskId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("MyActions");
                });

            modelBuilder.Entity("Simple.XChart.RoL.Common.Entities.MyPractice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GoalId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("MyPractices");
                });

            modelBuilder.Entity("Simple.XChart.RoL.Common.Entities.Occurence", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("DaysCount")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

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

            modelBuilder.Entity("Simple.XChart.RoL.Common.Entities.TaskPeriod", b =>
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
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TaskPeriods");
                });

            modelBuilder.Entity("Simple.XChart.RoL.Common.Entities.TobeGoal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TaskPeriodId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("TobeGoals");
                });
#pragma warning restore 612, 618
        }
    }
}
