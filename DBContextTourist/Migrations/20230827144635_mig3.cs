using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBContextTourist.Migrations
{
    public partial class mig3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TourCompany_AspNetUsers_UserId1",
                table: "TourCompany");

            migrationBuilder.DropIndex(
                name: "IX_TourCompany_UserId1",
                table: "TourCompany");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "TourCompany");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "TourCompany",
                type: "nvarchar(225)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_TourCompany_UserId",
                table: "TourCompany",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TourCompany_AspNetUsers_UserId",
                table: "TourCompany",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TourCompany_AspNetUsers_UserId",
                table: "TourCompany");

            migrationBuilder.DropIndex(
                name: "IX_TourCompany_UserId",
                table: "TourCompany");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "TourCompany",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(225)");

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "TourCompany",
                type: "nvarchar(225)",
                nullable: true);

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
    }
}
