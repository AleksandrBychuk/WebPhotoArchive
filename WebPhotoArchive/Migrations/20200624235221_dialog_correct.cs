using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebPhotoArchive.Migrations
{
    public partial class dialog_correct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "LastMessageTime",
                table: "Dialogs",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastMessageTime",
                table: "Dialogs");
        }
    }
}
