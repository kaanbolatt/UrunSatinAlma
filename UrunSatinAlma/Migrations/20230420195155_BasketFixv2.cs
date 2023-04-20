using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UrunSatinAlma.Migrations
{
    public partial class BasketFixv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Baskets_BasketId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_BasketId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "BasketId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "Baskets");

            migrationBuilder.AddColumn<long>(
                name: "ProductId",
                table: "Baskets",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "ProductsId",
                table: "Baskets",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Baskets_ProductsId",
                table: "Baskets",
                column: "ProductsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Baskets_Products_ProductsId",
                table: "Baskets",
                column: "ProductsId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Baskets_Products_ProductsId",
                table: "Baskets");

            migrationBuilder.DropIndex(
                name: "IX_Baskets_ProductsId",
                table: "Baskets");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Baskets");

            migrationBuilder.DropColumn(
                name: "ProductsId",
                table: "Baskets");

            migrationBuilder.AddColumn<long>(
                name: "BasketId",
                table: "Products",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalPrice",
                table: "Baskets",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_Products_BasketId",
                table: "Products",
                column: "BasketId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Baskets_BasketId",
                table: "Products",
                column: "BasketId",
                principalTable: "Baskets",
                principalColumn: "Id");
        }
    }
}
