using BookAndMore.Authentication.Application.DTO;
using MediatR;

namespace BookAndMore.Authentication.Application.Features.Commands;

public class CreateRoleCommand : IRequest<RoleDto>
{
    public string Name { get; set; } = default!;
}