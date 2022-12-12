using BookAndMore.Authentication.Application.DTO;
using BookAndMore.Authentication.Application.Features.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookAndMore.Authentication.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class RoleController
{
    private readonly IMediator _mediator;

    public RoleController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public Task<RoleDto> CreateRole([FromBody] CreateRoleCommand command)
    {
        return _mediator.Send(command);
    }
}