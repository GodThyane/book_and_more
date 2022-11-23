using BookAndMore.Book.Application.DTO;
using MediatR;

namespace BookAndMore.Book.Application.Features.Commands;

public class CreateBookCommand : IRequest<BookDto>
{
    public string Title { get; set; } = string.Empty;
    public int AuthorId { get; set; }
    public DateTime? PublishedDate { get; set; }
}