using BookAndMore.Authentication.Application.DTO;
using BookAndMore.Authentication.Application.Features.Commands;
using BookAndMore.Authentication.Application.Services;
using MediatR;

namespace BookAndMore.Authentication.Application.Features.Handlers;

public class CreateRoleHandler : IRequestHandler<CreateRoleCommand, RoleDto>
{
    private readonly IRoleService _roleService;

    public CreateRoleHandler(IRoleService roleService)
    {
        _roleService = roleService;
    }

    public Task<RoleDto> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        return _roleService.CreateRoleAsync(request.Name);
    }
}