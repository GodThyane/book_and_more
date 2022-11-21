using BookAndMore.Author.Application.DTO;
using MediatR;

namespace BookAndMore.Author.Application.Features.Commands;

public class CreateAuthorCommand : IRequest<AuthorDto>
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string? Biography { get; set; }
    public string? ImageUrl { get; set; }
    public DateTime? BirthDate { get; set; }
}