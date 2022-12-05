namespace BookAndMore.ShoppingCart.Application.Services;

public interface IShoppingCartService
{
    Task<Domain.Models.ShoppingCart> GetShoppingCartAsync(int id);
    Task<IEnumerable<Domain.Models.ShoppingCart>> GetShoppingCartsAsync();
    Task<Domain.Models.ShoppingCart> CreateShoppingCartAsync(Domain.Models.ShoppingCart shoppingCart);
}