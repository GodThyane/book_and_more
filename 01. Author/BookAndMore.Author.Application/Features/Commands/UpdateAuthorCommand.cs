using BookAndMore.Author.Application.DTO;
using MediatR;

namespace BookAndMore.Author.Application.Features.Commands;

public class UpdateAuthorCommand : IRequest<AuthorDto>
{
    public UpdateAuthorDto Author { get; set; } = new();
    public int Id { get; set; }
}