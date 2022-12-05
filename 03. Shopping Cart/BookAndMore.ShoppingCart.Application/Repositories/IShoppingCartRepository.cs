using BookAndMore.Commons.Application.Interfaces;

namespace BookAndMore.ShoppingCart.Application.Repositories;

public interface IShoppingCartRepository : IRepository<Domain.Models.ShoppingCart, int>
{
}