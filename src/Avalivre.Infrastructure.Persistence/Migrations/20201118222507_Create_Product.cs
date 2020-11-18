using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Avalivre.Infrastructure.Persistence.Migrations
{
    public partial class Create_Product : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Users",
                newName: "USR_Password");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Users",
                newName: "USR_Name");

            migrationBuilder.RenameColumn(
                name: "IsAdmin",
                table: "Users",
                newName: "USR_IsAdmin");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Users",
                newName: "USR_Email");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Users",
                newName: "USR_Id");

            migrationBuilder.AlterColumn<string>(
                name: "USR_Password",
                table: "Users",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "USR_Name",
                table: "Users",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "USR_Email",
                table: "Users",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    PRD_Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PRD_Name = table.Column<string>(maxLength: 100, nullable: false),
                    PRD_CreationDate = table.Column<DateTime>(nullable: false),
                    PRD_UpdateDate = table.Column<DateTime>(nullable: true),
                    PRD_Brand = table.Column<string>(maxLength: 50, nullable: false),
                    PRD_ModelCode = table.Column<string>(maxLength: 30, nullable: true),
                    PRD_Material = table.Column<string>(maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.PRD_Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.RenameColumn(
                name: "USR_Password",
                table: "Users",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "USR_Name",
                table: "Users",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "USR_IsAdmin",
                table: "Users",
                newName: "IsAdmin");

            migrationBuilder.RenameColumn(
                name: "USR_Email",
                table: "Users",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "USR_Id",
                table: "Users",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 256);
        }
    }
}
