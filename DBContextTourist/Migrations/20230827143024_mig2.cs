using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBContextTourist.Migrations
{
    public partial class mig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "TourCompany",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "TourCompany",
                type: "nvarchar(225)",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "openingHour",
                table: "Restaurant",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "closingHour",
                table: "Restaurant",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Market",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTime>(
                name: "startTime",
                table: "Activity",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "closeTime",
                table: "Activity",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.CreateIndex(
                name: "IX_TourCompany_UserId1",
                table: "TourCompany",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_TourCompany_AspNetUsers_UserId1",
                table: "TourCompany",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TourCompany_AspNetUsers_UserId1",
                table: "TourCompany");

            migrationBuilder.DropIndex(
                name: "IX_TourCompany_UserId1",
                table: "TourCompany");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "TourCompany");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "TourCompany");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Market");

            migrationBuilder.AlterColumn<DateTime>(
                name: "openingHour",
                table: "Restaurant",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "closingHour",
                table: "Restaurant",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "startTime",
                table: "Activity",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "closeTime",
                table: "Activity",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");
        }
    }
}
