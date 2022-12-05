namespace BookAndMore.ShoppingCart.Application.DTO;

public class CreateShoppingCartDetailDto
{
    public DateTime? AggregationDate { get; set; }
    public int SelectedProductId { get; set; }
    public int Quantity { get; set; }
}