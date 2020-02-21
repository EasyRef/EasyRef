using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyRefCore.Migrations
{
    public partial class Add_UserRoles2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Coach_Role_RoleId",
                table: "Coach");

            migrationBuilder.DropForeignKey(
                name: "FK_Referee_Role_RoleId",
                table: "Referee");

            migrationBuilder.DropColumn(
                name: "UserRole",
                table: "Referee");

            migrationBuilder.DropColumn(
                name: "UserRole",
                table: "Coach");

            migrationBuilder.AlterColumn<int>(
                name: "RoleId",
                table: "Referee",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RoleId",
                table: "Coach",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Coach_Role_RoleId",
                table: "Coach",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Referee_Role_RoleId",
                table: "Referee",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Coach_Role_RoleId",
                table: "Coach");

            migrationBuilder.DropForeignKey(
                name: "FK_Referee_Role_RoleId",
                table: "Referee");

            migrationBuilder.AlterColumn<int>(
                name: "RoleId",
                table: "Referee",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "UserRole",
                table: "Referee",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "RoleId",
                table: "Coach",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "UserRole",
                table: "Coach",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
    }
}
