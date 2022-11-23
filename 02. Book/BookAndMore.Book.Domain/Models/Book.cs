using BookAndMore.Commons.Domain.Models;

namespace BookAndMore.Book.Domain.Models;

public class Book : DatabaseObj<int>
{
    public string Title { get; set; } = string.Empty;
    public int AuthorId { get; set; }
    public DateTime? PublishedDate { get; set; }
}