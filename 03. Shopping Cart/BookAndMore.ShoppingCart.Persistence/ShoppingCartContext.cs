using BookAndMore.ShoppingCart.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BookAndMore.ShoppingCart.Persistence;

public class ShoppingCartContext : DbContext
{
    public ShoppingCartContext(DbContextOptions<ShoppingCartContext> options) : base(options) { }
    
    public virtual DbSet<Domain.Models.ShoppingCart> ShoppingCarts { get; set; } = default!;
    public virtual DbSet<ShoppingCartDetail> ShoppingCartDetails { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ShoppingCartContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}