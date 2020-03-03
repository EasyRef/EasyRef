using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyRefCore.Migrations
{
    public partial class Identityrename2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ApplicationUserId",
                table: "UserRole",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_ApplicationUserId",
                table: "UserRole",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRole_Users_ApplicationUserId",
                table: "UserRole",
                column: "ApplicationUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRole_Users_ApplicationUserId",
                table: "UserRole");

            migrationBuilder.DropIndex(
                name: "IX_UserRole_ApplicationUserId",
                table: "UserRole");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "UserRole");
        }
    }
}
