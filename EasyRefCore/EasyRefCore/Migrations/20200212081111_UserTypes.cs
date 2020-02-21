using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyRefCore.Migrations
{
    public partial class UserTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropColumn(
                name: "Compund",
                table: "Referee");

            migrationBuilder.AddColumn<string>(
                name: "Compound",
                table: "Referee",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Referee",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Referee",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Coach",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Coach",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Compound",
                table: "Referee");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Referee");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Referee");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Coach");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Coach");

            migrationBuilder.AddColumn<string>(
                name: "Compund",
                table: "Referee",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Compund = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });
        }
    }
}
