using BookAndMore.Commons.Domain.Models;

namespace BookAndMore.ShoppingCart.Domain.Models;

public class ShoppingCartDetail : DatabaseObj<int>
{
    public DateTime? AggregationDate { get; set; }
    public int SelectedProductId { get; set; }
    public int ShoppingCartId { get; set; }
    public int Quantity { get; set; }

    public ShoppingCart ShoppingCart { get; set; } = null!;
}