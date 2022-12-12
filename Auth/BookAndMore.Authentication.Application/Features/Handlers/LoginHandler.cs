using BookAndMore.Authentication.Application.DTO;
using BookAndMore.Authentication.Application.Features.Commands;
using BookAndMore.Authentication.Application.Services;
using MediatR;

namespace BookAndMore.Authentication.Application.Features.Handlers;

public class LoginHandler : IRequestHandler<LoginCommand, AuthenticationResponse>
{
    private readonly IAuthService _authService;

    public LoginHandler(IAuthService authService)
    {
        _authService = authService;
    }

    public Task<AuthenticationResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        => _authService.Login(request);
}