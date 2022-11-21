namespace BookAndMore.Commons.Domain.Models;

public abstract class DatabaseObj<TId>
{
    public TId Id { get; set; } = default!;
}