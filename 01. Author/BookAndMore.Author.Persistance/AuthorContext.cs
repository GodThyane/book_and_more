using Microsoft.EntityFrameworkCore;

namespace BookAndMore.Author.Persistance;

public class AuthorContext : DbContext
{
    public AuthorContext(DbContextOptions<AuthorContext> options): base(options)
    {
    }
    
    public virtual DbSet<Domain.Models.Author> Authors { get; set; } = default!;


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AuthorContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}