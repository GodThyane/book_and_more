using BookAndMore.ShoppingCart.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookAndMore.ShoppingCart.Persistence.Config;

public class ShoppingCartDetailConfiguration : IEntityTypeConfiguration<ShoppingCartDetail>
{
    public void Configure(EntityTypeBuilder<ShoppingCartDetail> builder)
    {
        
        builder.ToTable("Shopping_Cart_Details");
        
        builder.HasKey(e => e.Id);

        builder.Property(b => b.Id)
            .HasColumnName("shopping_cart_detail_id")
            .ValueGeneratedOnAdd();
        
        builder.Property(b => b.AggregationDate).HasColumnName("aggregation_date");
        builder.Property(b => b.SelectedProductId).HasColumnName("selected_product_id").IsRequired();
        builder.Property(b => b.Quantity).HasColumnName("quantity").IsRequired();
        builder.Property(b => b.ShoppingCartId).HasColumnName("shopping_cart_id").IsRequired();

        builder.HasOne(b => b.ShoppingCart)
            .WithMany(b => b.ShoppingCartDetails)
            .HasForeignKey(b => b.ShoppingCartId)
            .OnDelete(DeleteBehavior.ClientSetNull);

    }
}