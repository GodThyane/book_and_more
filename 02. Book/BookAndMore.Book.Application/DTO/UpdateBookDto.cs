namespace BookAndMore.Book.Application.DTO;

public class UpdateBookDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public int AuthorId { get; set; }
    public DateTime? PublishedDate { get; set; }
}