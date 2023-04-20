using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UrunSatinAlma.Migrations
{
    public partial class BasketFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "Baskets",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Baskets_UserId",
                table: "Baskets",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Baskets_Users_UserId",
                table: "Baskets",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Baskets_Users_UserId",
                table: "Baskets");

            migrationBuilder.DropIndex(
                name: "IX_Baskets_UserId",
                table: "Baskets");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Baskets");
        }
    }
}
