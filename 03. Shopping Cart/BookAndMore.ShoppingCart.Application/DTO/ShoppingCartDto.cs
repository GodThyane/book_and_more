namespace BookAndMore.ShoppingCart.Application.DTO;

public class ShoppingCartDto
{
    public int Id { get; set; }
    public DateTime? CreatedDate { get; set; }
    public List<ShoppingCartDetailDto> ShoppingCartDetails { get; set; }
}

public class ShoppingCartBaseDto
{
    public int Id { get; set; }
    public DateTime? CreatedDate { get; set; }
    public List<ShoppingCartDetailBaseDto> ShoppingCartDetails { get; set; }
}