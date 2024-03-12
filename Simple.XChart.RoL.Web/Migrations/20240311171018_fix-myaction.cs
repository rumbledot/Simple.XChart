using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Simple.XChart.RoL.Web.Migrations
{
    public partial class fixmyaction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TaskId",
                table: "MyActions",
                newName: "OccurenceId");

            migrationBuilder.RenameColumn(
                name: "Occurence",
                table: "MyActions",
                newName: "ChartPeriodId");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "MyActions",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "MyActions",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "DailyReflrections",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(2000)",
                oldMaxLength: 2000);

            migrationBuilder.UpdateData(
                table: "AppInformations",
                keyColumn: "InfoKey",
                keyValue: "PhotoTheme",
                columns: new[] { "DateUpdated", "InfoValue" },
                values: new object[] { new DateTime(2024, 3, 12, 6, 10, 18, 151, DateTimeKind.Local).AddTicks(4529), "natural landscape" });

            migrationBuilder.UpdateData(
                table: "ChartPeriods",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateEnd", "DateStart" },
                values: new object[] { new DateTime(2024, 7, 10, 6, 10, 18, 151, DateTimeKind.Local).AddTicks(4500), new DateTime(2024, 3, 12, 6, 10, 18, 151, DateTimeKind.Local).AddTicks(4473) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "MyActions");

            migrationBuilder.RenameColumn(
                name: "OccurenceId",
                table: "MyActions",
                newName: "TaskId");

            migrationBuilder.RenameColumn(
                name: "ChartPeriodId",
                table: "MyActions",
                newName: "Occurence");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "MyActions",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(2000)",
                oldMaxLength: 2000);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "DailyReflrections",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AppInformations",
                keyColumn: "InfoKey",
                keyValue: "PhotoTheme",
                columns: new[] { "DateUpdated", "InfoValue" },
                values: new object[] { new DateTime(2024, 3, 10, 18, 45, 33, 864, DateTimeKind.Local).AddTicks(9988), "christianity" });

            migrationBuilder.UpdateData(
                table: "ChartPeriods",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateEnd", "DateStart" },
                values: new object[] { new DateTime(2024, 7, 8, 18, 45, 33, 864, DateTimeKind.Local).AddTicks(9959), new DateTime(2024, 3, 10, 18, 45, 33, 864, DateTimeKind.Local).AddTicks(9933) });
        }
    }
}
