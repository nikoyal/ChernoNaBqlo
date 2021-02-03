using Microsoft.EntityFrameworkCore.Migrations;

namespace CyberSecurityBG.Data.Migrations
{
    public partial class UpdatedNews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "CreatedByAdmin",
                table: "News",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Source",
                table: "News",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedByAdmin",
                table: "News");

            migrationBuilder.DropColumn(
                name: "Source",
                table: "News");
        }
    }
}
