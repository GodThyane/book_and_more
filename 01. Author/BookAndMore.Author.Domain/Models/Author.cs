using BookAndMore.Commons.Domain.Models;

namespace BookAndMore.Author.Domain.Models;

public class Author : DatabaseObj<int>
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string? Biography { get; set; }
    public string? ImageUrl { get; set; }
    public DateTime? BirthDate { get; set; }
}