using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookAndMore.ShoppingCart.Persistence.Config;

public class ShoppingCartConfiguration : IEntityTypeConfiguration<Domain.Models.ShoppingCart>
{
    public void Configure(EntityTypeBuilder<Domain.Models.ShoppingCart> builder)
    {
        
        builder.ToTable("Shopping_Carts");
        
        builder.HasKey(e => e.Id);

        builder.Property(b => b.Id)
            .HasColumnName("shopping_cart_id")
            .ValueGeneratedOnAdd();
        
        builder.Property(b => b.CreatedDate).HasColumnName("created_date");
    }
}