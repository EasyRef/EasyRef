using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyRefCore.Migrations
{
    public partial class Remake1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Game_Referee_ThirdRefereeId",
                table: "Game");

            migrationBuilder.DropIndex(
                name: "IX_Game_ThirdRefereeId",
                table: "Game");

            migrationBuilder.CreateIndex(
                name: "IX_Game_SecondRefereeId",
                table: "Game",
                column: "SecondRefereeId");

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
                name: "FK_Game_Referee_SecondRefereeId",
                table: "Game");

            migrationBuilder.DropIndex(
                name: "IX_Game_SecondRefereeId",
                table: "Game");

            migrationBuilder.CreateIndex(
                name: "IX_Game_ThirdRefereeId",
                table: "Game",
                column: "ThirdRefereeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Game_Referee_ThirdRefereeId",
                table: "Game",
                column: "ThirdRefereeId",
                principalTable: "Referee",
                principalColumn: "RefereeId");
        }
    }
}
