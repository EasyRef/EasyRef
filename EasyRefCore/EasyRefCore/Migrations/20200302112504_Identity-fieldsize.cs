using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyRefCore.Migrations
{
    public partial class Identityfieldsize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FieldSizeId",
                table: "Users",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_FieldSizeId",
                table: "Users",
                column: "FieldSizeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_GameFieldSize_FieldSizeId",
                table: "Users",
                column: "FieldSizeId",
                principalTable: "GameFieldSize",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_GameFieldSize_FieldSizeId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_FieldSizeId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "FieldSizeId",
                table: "Users");
        }
    }
}
