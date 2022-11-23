using BookAndMore.Book.Proxy.Author.DTO;

namespace BookAndMore.Book.Application.DTO;

public class BookBaseDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public int AuthorId { get; set; } = new();
    public DateTime? PublishedDate { get; set; }
}
public class BookDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public AuthorBaseDto Author { get; set; } = new();
    public DateTime? PublishedDate { get; set; }
}