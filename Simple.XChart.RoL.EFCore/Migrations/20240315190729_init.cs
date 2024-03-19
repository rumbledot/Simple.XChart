using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Simple.XChart.RoL.EFCore.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppInformations",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Information = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppInformations", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "AttachVerses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BibleId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    BookId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ChapterId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    VerseId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MyActionId = table.Column<int>(type: "int", nullable: false)
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
                    ImageUrl = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    ImageLandscapeUrl = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    ImageAlt = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Photographer = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    PhotographerUrl = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AverageColor = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BannerImages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Charts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    DateStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateEnd = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Charts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Goals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ChartId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Goals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MyActions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PracticeId = table.Column<int>(type: "int", nullable: false),
                    OccurenceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyActions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Occurences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DaysCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Occurences", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Practices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    GoalId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Practices", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AppInformations",
                columns: new[] { "Code", "DateUpdated", "Information" },
                values: new object[] { "PhotoTheme", new DateTime(2024, 3, 16, 8, 7, 29, 288, DateTimeKind.Local).AddTicks(3002), "natural landscape" });

            migrationBuilder.InsertData(
                table: "Charts",
                columns: new[] { "Id", "DateEnd", "DateStart", "Description", "Title" },
                values: new object[] { 1, new DateTime(2024, 7, 14, 8, 7, 29, 288, DateTimeKind.Local).AddTicks(2955), new DateTime(2024, 3, 16, 8, 7, 29, 288, DateTimeKind.Local).AddTicks(2930), "Guide thru Easter", "Lent" });

            migrationBuilder.InsertData(
                table: "Goals",
                columns: new[] { "Id", "ChartId", "Description" },
                values: new object[,]
                {
                    { 1, 1, "Be With Jesus" },
                    { 2, 1, "Become Like Jesus" },
                    { 3, 1, "Do what Jesus did" }
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

            migrationBuilder.InsertData(
                table: "Practices",
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
                name: "Charts");

            migrationBuilder.DropTable(
                name: "Goals");

            migrationBuilder.DropTable(
                name: "MyActions");

            migrationBuilder.DropTable(
                name: "Occurences");

            migrationBuilder.DropTable(
                name: "Practices");
        }
    }
}
