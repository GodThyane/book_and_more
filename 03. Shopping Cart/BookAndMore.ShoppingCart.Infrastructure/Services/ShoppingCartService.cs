using AutoMapper;
using BookAndMore.Commons.Application.Exceptions;
using BookAndMore.ShoppingCart.Application.Repositories;
using BookAndMore.ShoppingCart.Application.Services;

namespace BookAndMore.ShoppingCart.Infrastructure.Services;

public class ShoppingCartService : IShoppingCartService
{

    private readonly IShoppingCartRepository _shoppingCartRepository;

    public ShoppingCartService(IShoppingCartRepository shoppingCartRepository)
    {
        _shoppingCartRepository = shoppingCartRepository;
    }

    public async Task<Domain.Models.ShoppingCart> GetShoppingCartAsync(int id)
    {
        var shoppingCart = await _shoppingCartRepository.GetByIdAsync(id);
        if (shoppingCart == null)
        {
            throw new EntityNotFoundException(typeof(Domain.Models.ShoppingCart), id, "id");
        }
        return shoppingCart;
    }

    public async Task<IEnumerable<Domain.Models.ShoppingCart>> GetShoppingCartsAsync()
    {
        var shoppingCarts = await _shoppingCartRepository.GetAllAsync();
        return shoppingCarts;
    }

    public async Task<Domain.Models.ShoppingCart> CreateShoppingCartAsync(Domain.Models.ShoppingCart shoppingCart)
    {
        await _shoppingCartRepository.AddAsync(shoppingCart);
        await _shoppingCartRepository.SaveChangesAsync();
        return (await _shoppingCartRepository.GetByIdAsync(shoppingCart.Id))!;
    }
}