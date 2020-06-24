using Microsoft.EntityFrameworkCore.Migrations;

namespace WebPhotoArchive.Migrations
{
    public partial class littlecorrect : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdComment",
                table: "Comments",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdComment",
                table: "Comments");
        }
    }
}
