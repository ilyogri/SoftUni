using Microsoft.EntityFrameworkCore.Migrations;

namespace ChameleonStore.Web.Data.Migrations
{
    public partial class ProductColNameChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Reviews",
                table: "Products",
                newName: "Views");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Views",
                table: "Products",
                newName: "Reviews");
        }
    }
}
