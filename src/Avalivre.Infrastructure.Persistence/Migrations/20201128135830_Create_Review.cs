using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Avalivre.Infrastructure.Persistence.Migrations
{
    public partial class Create_Review : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    RVW_Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RVW_Description = table.Column<string>(type: "text", nullable: false),
                    RVW_Rating = table.Column<byte>(type: "tinyint", nullable: false),
                    RVW_CreationDate = table.Column<DateTime>(nullable: false),
                    RVW_UpdateDate = table.Column<DateTime>(nullable: true),
                    RVW_UserProductImageUrl = table.Column<string>(nullable: true),
                    RVW_ProductId = table.Column<long>(nullable: false),
                    RVW_UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.RVW_Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Products_RVW_ProductId",
                        column: x => x.RVW_ProductId,
                        principalTable: "Products",
                        principalColumn: "PRD_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reviews_Users_RVW_UserId",
                        column: x => x.RVW_UserId,
                        principalTable: "Users",
                        principalColumn: "USR_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_RVW_ProductId",
                table: "Reviews",
                column: "RVW_ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_RVW_UserId",
                table: "Reviews",
                column: "RVW_UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reviews");
        }
    }
}
