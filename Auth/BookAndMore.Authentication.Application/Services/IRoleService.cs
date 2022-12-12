using BookAndMore.Authentication.Application.DTO;

namespace BookAndMore.Authentication.Application.Services;

public interface IRoleService
{
    Task<RoleDto> CreateRoleAsync(string name);
}