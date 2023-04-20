using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UrunSatinAlma.Migrations
{
    public partial class BasketFixv3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Baskets_Products_ProductsId",
                table: "Baskets");

            migrationBuilder.AlterColumn<long>(
                name: "ProductsId",
                table: "Baskets",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_Baskets_Products_ProductsId",
                table: "Baskets",
                column: "ProductsId",
                principalTable: "Products",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Baskets_Products_ProductsId",
                table: "Baskets");

            migrationBuilder.AlterColumn<long>(
                name: "ProductsId",
                table: "Baskets",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Baskets_Products_ProductsId",
                table: "Baskets",
                column: "ProductsId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
