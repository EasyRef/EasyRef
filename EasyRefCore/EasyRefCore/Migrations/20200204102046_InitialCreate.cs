using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyRefCore.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Coach",
                columns: table => new
                {
                    CoachId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Compound = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coach", x => x.CoachId);
                });

            migrationBuilder.CreateTable(
                name: "GameAge",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Age = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameAge", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GameDivison",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Division = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameDivison", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GameFieldSize",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FieldSize = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameFieldSize", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GameGender",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Gender = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameGender", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    RoleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Compund = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Referee",
                columns: table => new
                {
                    RefereeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    FieldSizeId = table.Column<int>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Compund = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Referee", x => x.RefereeId);
                    table.ForeignKey(
                        name: "FK_Referee_GameFieldSize_FieldSizeId",
                        column: x => x.FieldSizeId,
                        principalTable: "GameFieldSize",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Game",
                columns: table => new
                {
                    GameId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CoachId = table.Column<int>(nullable: true),
                    RefereeId = table.Column<int>(nullable: true),
                    SecondRefereeId = table.Column<int>(nullable: true),
                    ThirdRefereeId = table.Column<int>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    HomeTeam = table.Column<string>(nullable: true),
                    AwayTeam = table.Column<string>(nullable: true),
                    GameGenderId = table.Column<int>(nullable: false),
                    GameAgeId = table.Column<int>(nullable: false),
                    FieldLocation = table.Column<string>(nullable: true),
                    GameFieldSizeId = table.Column<int>(nullable: true),
                    GameDivisionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Game", x => x.GameId);
                    table.ForeignKey(
                        name: "FK_Game_Coach_CoachId",
                        column: x => x.CoachId,
                        principalTable: "Coach",
                        principalColumn: "CoachId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Game_GameAge_GameAgeId",
                        column: x => x.GameAgeId,
                        principalTable: "GameAge",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Game_GameDivison_GameDivisionId",
                        column: x => x.GameDivisionId,
                        principalTable: "GameDivison",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Game_GameFieldSize_GameFieldSizeId",
                        column: x => x.GameFieldSizeId,
                        principalTable: "GameFieldSize",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Game_GameGender_GameGenderId",
                        column: x => x.GameGenderId,
                        principalTable: "GameGender",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Game_Referee_ThirdRefereeId",
                        column: x => x.ThirdRefereeId,
                        principalTable: "Referee",
                        principalColumn: "RefereeId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Game_CoachId",
                table: "Game",
                column: "CoachId");

            migrationBuilder.CreateIndex(
                name: "IX_Game_GameAgeId",
                table: "Game",
                column: "GameAgeId");

            migrationBuilder.CreateIndex(
                name: "IX_Game_GameDivisionId",
                table: "Game",
                column: "GameDivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_Game_GameFieldSizeId",
                table: "Game",
                column: "GameFieldSizeId");

            migrationBuilder.CreateIndex(
                name: "IX_Game_GameGenderId",
                table: "Game",
                column: "GameGenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Game_ThirdRefereeId",
                table: "Game",
                column: "ThirdRefereeId");

            migrationBuilder.CreateIndex(
                name: "IX_Referee_FieldSizeId",
                table: "Referee",
                column: "FieldSizeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Game");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Coach");

            migrationBuilder.DropTable(
                name: "GameAge");

            migrationBuilder.DropTable(
                name: "GameDivison");

            migrationBuilder.DropTable(
                name: "GameGender");

            migrationBuilder.DropTable(
                name: "Referee");

            migrationBuilder.DropTable(
                name: "GameFieldSize");
        }
    }
}
