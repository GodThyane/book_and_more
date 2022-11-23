using Microsoft.EntityFrameworkCore;

namespace BookAndMore.Book.Persistence;

public class BookContext : DbContext
{
    public BookContext(DbContextOptions<BookContext> options) : base(options)
    {
    }

    public virtual DbSet<Domain.Models.Book> Books { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BookContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}