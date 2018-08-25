using Microsoft.EntityFrameworkCore.Migrations;

namespace ChameleonStore.Web.Data.Migrations
{
    public partial class ProductReviwsCol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Reviews",
                table: "Products",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Reviews",
                table: "Products");
        }
    }
}
