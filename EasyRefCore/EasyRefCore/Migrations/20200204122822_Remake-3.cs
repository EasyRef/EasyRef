using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyRefCore.Migrations
{
    public partial class Remake3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Game_RefereeId",
                table: "Game",
                column: "RefereeId");

            migrationBuilder.CreateIndex(
                name: "IX_Game_SecondRefereeId",
                table: "Game",
                column: "SecondRefereeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Game_Referee_RefereeId",
                table: "Game",
                column: "RefereeId",
                principalTable: "Referee",
                principalColumn: "RefereeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Game_Referee_SecondRefereeId",
                table: "Game",
                column: "SecondRefereeId",
                principalTable: "Referee",
                principalColumn: "RefereeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Game_Referee_RefereeId",
                table: "Game");

            migrationBuilder.DropForeignKey(
                name: "FK_Game_Referee_SecondRefereeId",
                table: "Game");

            migrationBuilder.DropIndex(
                name: "IX_Game_RefereeId",
                table: "Game");

            migrationBuilder.DropIndex(
                name: "IX_Game_SecondRefereeId",
                table: "Game");
        }
    }
}
