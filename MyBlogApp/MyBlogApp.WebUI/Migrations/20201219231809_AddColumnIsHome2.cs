using Microsoft.EntityFrameworkCore.Migrations;

namespace MyBlogApp.WebUI.Migrations
{
    public partial class AddColumnIsHome2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isHome",
                table: "Blogs",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isHome",
                table: "Blogs");
        }
    }
}
