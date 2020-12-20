using Microsoft.EntityFrameworkCore.Migrations;

namespace MyBlogApp.WebUI.Migrations
{
    public partial class AddColumnIsSlider2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isSlider",
                table: "Blogs",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isSlider",
                table: "Blogs");
        }
    }
}
