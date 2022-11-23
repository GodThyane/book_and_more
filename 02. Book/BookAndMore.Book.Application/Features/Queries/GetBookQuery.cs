using BookAndMore.Book.Application.DTO;
using MediatR;

namespace BookAndMore.Book.Application.Features.Queries;

public class GetBookQuery : IRequest<BookDto>
{
    public int Id { get; set; }

    public GetBookQuery(int id)
    {
        Id = id;
    }
}

public class GetBooksQuery : IRequest<List<BookBaseDto>>
{
}