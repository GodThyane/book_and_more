using BookAndMore.Author.Application.DTO;
using MediatR;

namespace BookAndMore.Author.Application.Features.Queries;

public class GetAuthorQuery : IRequest<AuthorDto>
{
    public int Id { get; set; }

    public GetAuthorQuery(int id)
    {
        Id = id;
    }
}

public class GetAuthorsQuery : IRequest<List<AuthorBaseDto>>
{
}