using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Simple.XChart.RoL.Web.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppInformations",
                columns: table => new
                {
                    InfoKey = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    InfoValue = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppInformations", x => x.InfoKey);
                });

            migrationBuilder.CreateTable(
                name: "AttachVerses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DailyReflectionId = table.Column<int>(type: "int", nullable: false),
                    BibleId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    BookId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ChapterId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    VerseId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttachVerses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BannerImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUrl = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    ImageLandscapeUrl = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    ImageAlt = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Photographer = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    PhotographerUrl = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AverageColor = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BannerImages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChartPeriodMap",
                columns: table => new
                {
                    ChartPeriodId = table.Column<int>(type: "int", nullable: false),
                    MyPracticeId = table.Column<int>(type: "int", nullable: false),
                    OccurenceId = table.Column<int>(type: "int", nullable: false),
                    DailyReflectionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "ChartPeriods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    DateStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateEnd = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChartPeriods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DailyReflrections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyReflrections", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MyActions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Occurence = table.Column<int>(type: "int", nullable: false),
                    PracticeId = table.Column<int>(type: "int", nullable: false),
                    TaskId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyActions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MyGoals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    TaskPeriodId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyGoals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MyPracticeDailyReflrectionMap",
                columns: table => new
                {
                    MyPracticeId = table.Column<int>(type: "int", nullable: false),
                    DailyReflectionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "MyPractices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    GoalId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyPractices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Occurences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DaysCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Occurences", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AppInformations",
                columns: new[] { "InfoKey", "DateUpdated", "InfoValue" },
                values: new object[] { "PhotoTheme", new DateTime(2024, 3, 10, 18, 45, 33, 864, DateTimeKind.Local).AddTicks(9988), "christianity" });

            migrationBuilder.InsertData(
                table: "ChartPeriods",
                columns: new[] { "Id", "DateEnd", "DateStart", "Description", "Title" },
                values: new object[] { 1, new DateTime(2024, 7, 8, 18, 45, 33, 864, DateTimeKind.Local).AddTicks(9959), new DateTime(2024, 3, 10, 18, 45, 33, 864, DateTimeKind.Local).AddTicks(9933), "Guide thru Easter", "Lent" });

            migrationBuilder.InsertData(
                table: "MyGoals",
                columns: new[] { "Id", "Description", "TaskPeriodId" },
                values: new object[,]
                {
                    { 1, "Be With Jesus", 1 },
                    { 2, "Become Like Jesus", 1 },
                    { 3, "Do what Jesus did", 1 }
                });

            migrationBuilder.InsertData(
                table: "MyPractices",
                columns: new[] { "Id", "Description", "GoalId" },
                values: new object[,]
                {
                    { 1, "Silence & Solitude", 1 },
                    { 2, "Scripture", 1 },
                    { 3, "Prayer", 1 },
                    { 4, "Community", 2 },
                    { 5, "Sabbath", 2 },
                    { 6, "Vocation", 3 },
                    { 7, "Hospitality", 3 },
                    { 8, "Simplicity", 3 }
                });

            migrationBuilder.InsertData(
                table: "Occurences",
                columns: new[] { "Id", "DaysCount", "Description" },
                values: new object[,]
                {
                    { 1, 1, "Daily" },
                    { 2, 7, "Weekly" },
                    { 3, 30, "Montly" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppInformations");

            migrationBuilder.DropTable(
                name: "AttachVerses");

            migrationBuilder.DropTable(
                name: "BannerImages");

            migrationBuilder.DropTable(
                name: "ChartPeriodMap");

            migrationBuilder.DropTable(
                name: "ChartPeriods");

            migrationBuilder.DropTable(
                name: "DailyReflrections");

            migrationBuilder.DropTable(
                name: "MyActions");

            migrationBuilder.DropTable(
                name: "MyGoals");

            migrationBuilder.DropTable(
                name: "MyPracticeDailyReflrectionMap");

            migrationBuilder.DropTable(
                name: "MyPractices");

            migrationBuilder.DropTable(
                name: "Occurences");
        }
    }
}
