using Microsoft.EntityFrameworkCore.Migrations;

namespace CyberSecurityBG.Data.Migrations
{
    public partial class NewsCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NewsComments_NewsComments_ParentId",
                table: "NewsComments");

            migrationBuilder.DropIndex(
                name: "IX_NewsComments_ParentId",
                table: "NewsComments");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "NewsComments");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "News",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "News");

            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                table: "NewsComments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_NewsComments_ParentId",
                table: "NewsComments",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_NewsComments_NewsComments_ParentId",
                table: "NewsComments",
                column: "ParentId",
                principalTable: "NewsComments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
