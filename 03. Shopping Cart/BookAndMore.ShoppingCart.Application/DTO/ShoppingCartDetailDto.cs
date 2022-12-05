using BookAndMore.ShoppingCart.Proxy.Book.DTO;

namespace BookAndMore.ShoppingCart.Application.DTO;

public class ShoppingCartDetailDto
{
    public int Id { get; set; }
    public DateTime? AggregationDate { get; set; }
    public BookDto Book { get; set; } = new();
    public int Quantity { get; set; }
}

public class ShoppingCartDetailBaseDto
{
    public int Id { get; set; }
    public DateTime? AggregationDate { get; set; }
    public int SelectedProductId { get; set; }
    public int Quantity { get; set; }
}