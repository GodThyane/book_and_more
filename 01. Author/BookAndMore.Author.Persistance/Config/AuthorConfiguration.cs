using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookAndMore.Author.Persistance.Config;

public class AuthorConfiguration: IEntityTypeConfiguration<Domain.Models.Author>
{
    public void Configure(EntityTypeBuilder<Domain.Models.Author> builder)
    {
        builder.HasKey(e => e.Id);
        
        builder.Property(e => e.Id)
            .HasColumnName("author_id")
            .ValueGeneratedOnAdd();
        
        builder.Property(e => e.FirstName).HasColumnName("first_name").HasMaxLength(50).IsRequired();
        builder.Property(e => e.LastName).HasColumnName("last_name").HasMaxLength(50).IsRequired();
        builder.Property(e => e.Biography).HasColumnName("biography").HasMaxLength(1000);
        builder.Property(e => e.ImageUrl).HasColumnName("image_url");
        builder.Property(e => e.BirthDate).HasColumnName("birth_date");
    }
}