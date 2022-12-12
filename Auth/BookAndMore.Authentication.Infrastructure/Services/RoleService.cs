using BookAndMore.Authentication.Application.DTO;
using BookAndMore.Authentication.Application.Services;
using BookAndMore.Commons.Application.Exceptions;
using Microsoft.AspNetCore.Identity;

namespace BookAndMore.Authentication.Infrastructure.Services;

public class RoleService : IRoleService
{
    private readonly RoleManager<IdentityRole> _roleManager;

    public RoleService(RoleManager<IdentityRole> roleManager)
    {
        _roleManager = roleManager;
    }

    public async Task<RoleDto> CreateRoleAsync(string name)
    {
        // Validar que el rol no exista
        var result = await _roleManager.RoleExistsAsync(name);
        if (result) throw new BadRequestException("El rol ya existe");
        
        // Crear el rol
        var role = new IdentityRole(name);
        var createResult = await _roleManager.CreateAsync(role);
        if (!createResult.Succeeded) throw new BadRequestException("No se pudo crear el rol");
        
        // Retornar el rol creado
        return new RoleDto
        {
            Id = role.Id,
            Name = role.Name
        };
    }
}