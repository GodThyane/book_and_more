using BookAndMore.Commons.Domain.Models;

namespace BookAndMore.ShoppingCart.Domain.Models;

public class ShoppingCart : DatabaseObj<int>
{
    public DateTime? CreatedDate { get; set; }
    public ICollection<ShoppingCartDetail> ShoppingCartDetails { get; set; } = new List<ShoppingCartDetail>();
}