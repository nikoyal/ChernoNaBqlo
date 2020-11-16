using Microsoft.EntityFrameworkCore.Migrations;

namespace CyberSecurityBG.Data.Migrations
{
    public partial class AddedRecursiveComments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "parentId",
                table: "Comments",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_parentId",
                table: "Comments",
                column: "parentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Comments_parentId",
                table: "Comments",
                column: "parentId",
                principalTable: "Comments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Comments_parentId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_parentId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "parentId",
                table: "Comments");
        }
    }
}
