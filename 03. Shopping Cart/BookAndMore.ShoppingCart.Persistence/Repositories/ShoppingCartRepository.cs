using BookAndMore.Commons.Persistance.Repositories;
using BookAndMore.ShoppingCart.Application.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BookAndMore.ShoppingCart.Persistence.Repositories;

public class ShoppingCartRepository : BaseRepository<Domain.Models.ShoppingCart, ShoppingCartContext, int>,
    IShoppingCartRepository
{
    public ShoppingCartRepository(ShoppingCartContext context) : base(context)
    {
    }

    public new Task<Domain.Models.ShoppingCart?> GetByIdAsync(int id)
    {
        return Entities
            .Include(x => x.ShoppingCartDetails)
            .SingleOrDefaultAsync(x => x.Id == id);
    }

    public new Domain.Models.ShoppingCart? GetById(int id)
    {
        return Entities
            .Include(x => x.ShoppingCartDetails)
            .SingleOrDefault(x => x.Id == id);
    }

    public new Task<IQueryable<Domain.Models.ShoppingCart>> GetAllAsync()
    {
        return Task.FromResult(Entities.Include(x => x.ShoppingCartDetails).AsQueryable());
    }
}