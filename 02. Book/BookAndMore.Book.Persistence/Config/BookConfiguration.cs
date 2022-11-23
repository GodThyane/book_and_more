using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookAndMore.Book.Persistence.Config;

public class BookConfiguration : IEntityTypeConfiguration<Domain.Models.Book>
{
    public void Configure(EntityTypeBuilder<Domain.Models.Book> builder)
    {
        builder.HasKey(e => e.Id);
        
        builder.Property(b => b.Id)
            .HasColumnName("book_id")
            .ValueGeneratedOnAdd();
        
        builder.Property(b => b.Title).HasColumnName("title").IsRequired();
        builder.Property(b => b.AuthorId).HasColumnName("author_id").IsRequired();
        builder.Property(e => e.PublishedDate).HasColumnName("published_date");
    }
}