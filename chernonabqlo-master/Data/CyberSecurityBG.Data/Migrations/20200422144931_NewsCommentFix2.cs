using Microsoft.EntityFrameworkCore.Migrations;

namespace CyberSecurityBG.Data.Migrations
{
    public partial class NewsCommentFix2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                table: "NewsComments",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
