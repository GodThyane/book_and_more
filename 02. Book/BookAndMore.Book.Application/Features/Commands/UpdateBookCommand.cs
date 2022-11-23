using BookAndMore.Book.Application.DTO;
using MediatR;

namespace BookAndMore.Book.Application.Features.Commands;

public class UpdateBookCommand : IRequest<BookDto>
{
    public UpdateBookDto Book { get; set; } = new();
    public int Id { get; set; }
}