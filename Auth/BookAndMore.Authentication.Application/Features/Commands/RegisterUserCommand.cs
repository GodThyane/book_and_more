using BookAndMore.Authentication.Application.DTO;
using MediatR;

namespace BookAndMore.Authentication.Application.Features.Commands;

public class RegisterUserCommand : IRequest<UserDto>
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public List<string> Roles { get; set; } = new();
}