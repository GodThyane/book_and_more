namespace BookAndMore.Book.Proxy.Author.DTO;

public class AuthorBaseDto
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string? ImageUrl { get; set; }
    public DateTime? BirthDate { get; set; }
}