using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyRefCore.Migrations
{
    public partial class Identity5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserProperties_PropertiesId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "UserProperties");

            migrationBuilder.DropIndex(
                name: "IX_Users_PropertiesId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PropertiesId",
                table: "Users");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PropertiesId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UserProperties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExtendedValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProperties", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "UserProperties",
                columns: new[] { "Id", "ExtendedValue" },
                values: new object[,]
                {
                    { 1, "5 man" },
                    { 2, "7 man" },
                    { 3, "9 man" },
                    { 4, "11 man" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_PropertiesId",
                table: "Users",
                column: "PropertiesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserProperties_PropertiesId",
                table: "Users",
                column: "PropertiesId",
                principalTable: "UserProperties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
