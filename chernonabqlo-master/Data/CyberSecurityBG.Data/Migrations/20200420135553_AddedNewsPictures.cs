﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace CyberSecurityBG.Data.Migrations
{
    public partial class AddedNewsPictures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PictureUrl",
                table: "News",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PictureUrl",
                table: "News");
        }
    }
}
