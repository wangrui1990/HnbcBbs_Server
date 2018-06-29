using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace HnbcInfo.Bbs.Migrations
{
    public partial class useraddfromandsignature : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "From",
                table: "AbpUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Signature",
                table: "AbpUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "From",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "Signature",
                table: "AbpUsers");
        }
    }
}
