using BookAndMore.Authentication.Application.DTO;
using MediatR;

namespace BookAndMore.Authentication.Application.Features.Commands;

public class LoginCommand : IRequest<AuthenticationResponse>
{
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}