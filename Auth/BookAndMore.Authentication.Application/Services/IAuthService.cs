using BookAndMore.Authentication.Application.DTO;
using BookAndMore.Authentication.Application.Features.Commands;

namespace BookAndMore.Authentication.Application.Services;

public interface IAuthService
{
    Task<AuthenticationResponse> Login(LoginCommand command);
    Task<UserDto> Register(RegisterUserCommand command);
}