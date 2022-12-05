using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookAndMore.ShoppingCart.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Shopping_Carts",
                columns: table => new
                {
                    shoppingcartid = table.Column<int>(name: "shopping_cart_id", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    createddate = table.Column<DateTime>(name: "created_date", type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shopping_Carts", x => x.shoppingcartid);
                });

            migrationBuilder.CreateTable(
                name: "Shopping_Cart_Details",
                columns: table => new
                {
                    shoppingcartdetailid = table.Column<int>(name: "shopping_cart_detail_id", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShoppingCartDetailId = table.Column<int>(type: "int", nullable: false),
                    aggregationdate = table.Column<DateTime>(name: "aggregation_date", type: "datetime2", nullable: true),
                    selectedproductid = table.Column<int>(name: "selected_product_id", type: "int", nullable: false),
                    shoppingcartid = table.Column<int>(name: "shopping_cart_id", type: "int", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shopping_Cart_Details", x => x.shoppingcartdetailid);
                    table.ForeignKey(
                        name: "FK_Shopping_Cart_Details_Shopping_Carts_shopping_cart_id",
                        column: x => x.shoppingcartid,
                        principalTable: "Shopping_Carts",
                        principalColumn: "shopping_cart_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Shopping_Cart_Details_shopping_cart_id",
                table: "Shopping_Cart_Details",
                column: "shopping_cart_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Shopping_Cart_Details");

            migrationBuilder.DropTable(
                name: "Shopping_Carts");
        }
    }
}
