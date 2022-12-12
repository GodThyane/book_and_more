using BookAndMore.Authentication.Application.DTO;
using BookAndMore.Authentication.Application.Features.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookAndMore.Authentication.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class AccountController : ControllerBase
{

    private readonly IMediator _mediator;

    public AccountController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("Login")]
    public Task<AuthenticationResponse> Login([FromBody] LoginCommand command)
    {
        return _mediator.Send(command);
    }
    
    [HttpPost("Register")]
    public Task<UserDto> Register([FromBody] RegisterUserCommand command)
    {
        return _mediator.Send(command);
    }
}