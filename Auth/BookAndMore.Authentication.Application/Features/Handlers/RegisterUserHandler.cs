using BookAndMore.Authentication.Application.DTO;
using BookAndMore.Authentication.Application.Features.Commands;
using BookAndMore.Authentication.Application.Services;
using MediatR;

namespace BookAndMore.Authentication.Application.Features.Handlers;

public class RegisterUserHandler : IRequestHandler<RegisterUserCommand, UserDto>
{

    private readonly IAuthService _authService;

    public RegisterUserHandler(IAuthService authService)
    {
        _authService = authService;
    }

    public Task<UserDto> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        return _authService.Register(request);
    }
}