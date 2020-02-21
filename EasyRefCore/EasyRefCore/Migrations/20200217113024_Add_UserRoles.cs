using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyRefCore.Migrations
{
    public partial class Add_UserRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "Referee",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserRole",
                table: "Referee",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "Coach",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserRole",
                table: "Coach",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserRole = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Referee_RoleId",
                table: "Referee",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Coach_RoleId",
                table: "Coach",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Coach_Role_RoleId",
                table: "Coach",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Referee_Role_RoleId",
                table: "Referee",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Coach_Role_RoleId",
                table: "Coach");

            migrationBuilder.DropForeignKey(
                name: "FK_Referee_Role_RoleId",
                table: "Referee");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropIndex(
                name: "IX_Referee_RoleId",
                table: "Referee");

            migrationBuilder.DropIndex(
                name: "IX_Coach_RoleId",
                table: "Coach");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "Referee");

            migrationBuilder.DropColumn(
                name: "UserRole",
                table: "Referee");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "Coach");

            migrationBuilder.DropColumn(
                name: "UserRole",
                table: "Coach");
        }
    }
}
