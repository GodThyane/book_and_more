using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookAndMore.ShoppingCart.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Iddetailchange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShoppingCartDetailId",
                table: "Shopping_Cart_Details");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ShoppingCartDetailId",
                table: "Shopping_Cart_Details",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
