using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyRefCore.Migrations
{
    public partial class Identity2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_ExtendedUserTypes_PropertiesId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_UserType_TypeId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Coach_UserType_RoleId",
                table: "Coach");

            migrationBuilder.DropForeignKey(
                name: "FK_Referee_UserType_RoleId",
                table: "Referee");

            migrationBuilder.DropTable(
                name: "ExtendedUserTypes");

            migrationBuilder.DropTable(
                name: "UserType");

            migrationBuilder.DropIndex(
                name: "IX_Referee_RoleId",
                table: "Referee");

            migrationBuilder.DropIndex(
                name: "IX_Coach_RoleId",
                table: "Coach");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_TypeId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "Referee");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "Coach");

            migrationBuilder.DropColumn(
                name: "Admin",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "PropertiesId",
                table: "AspNetUsers",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "UserProperties",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExtendedValue = table.Column<string>(nullable: true)
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

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_UserProperties_PropertiesId",
                table: "AspNetUsers",
                column: "PropertiesId",
                principalTable: "UserProperties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_UserProperties_PropertiesId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "UserProperties");

            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "Referee",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "Coach",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "PropertiesId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Admin",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ExtendedUserTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExtendedValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExtendedUserTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserType", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ExtendedUserTypes",
                columns: new[] { "Id", "ExtendedValue" },
                values: new object[,]
                {
                    { 1, "5 man" },
                    { 2, "7 man" },
                    { 3, "9 man" },
                    { 4, "11 man" }
                });

            migrationBuilder.InsertData(
                table: "UserType",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { 1, "Coach" },
                    { 2, "Referee" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Referee_RoleId",
                table: "Referee",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Coach_RoleId",
                table: "Coach",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_TypeId",
                table: "AspNetUsers",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_ExtendedUserTypes_PropertiesId",
                table: "AspNetUsers",
                column: "PropertiesId",
                principalTable: "ExtendedUserTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_UserType_TypeId",
                table: "AspNetUsers",
                column: "TypeId",
                principalTable: "UserType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Coach_UserType_RoleId",
                table: "Coach",
                column: "RoleId",
                principalTable: "UserType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Referee_UserType_RoleId",
                table: "Referee",
                column: "RoleId",
                principalTable: "UserType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
