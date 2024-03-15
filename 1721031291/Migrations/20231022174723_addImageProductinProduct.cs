using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _1721031291_DaoHoangNhi.Migrations
{
    /// <inheritdoc />
    public partial class addImageProductinProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "ImageProducts",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ImageProducts_ProductId",
                table: "ImageProducts",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ImageProducts_Products_ProductId",
                table: "ImageProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImageProducts_Products_ProductId",
                table: "ImageProducts");

            migrationBuilder.DropIndex(
                name: "IX_ImageProducts_ProductId",
                table: "ImageProducts");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "ImageProducts");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Products",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
