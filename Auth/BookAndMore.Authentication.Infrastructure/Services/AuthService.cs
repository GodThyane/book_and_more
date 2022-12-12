using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BookAndMore.Authentication.Application.DTO;
using BookAndMore.Authentication.Application.Features.Commands;
using BookAndMore.Authentication.Application.Services;
using BookAndMore.Authentication.Domain.Models;
using BookAndMore.Commons.Application.Config;
using BookAndMore.Commons.Application.Exceptions;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace BookAndMore.Authentication.Infrastructure.Services;

public class AuthService : IAuthService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private const int JwtTokenValidityMin = 20;

    public AuthService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task<AuthenticationResponse> Login(LoginCommand command)
    {
        // Validar que el usuario existe
        var user = await _userManager.FindByEmailAsync(command.Username);
        if(user == null) throw new BadRequestException("El usuario ingresado no existe");
        
        // Validar que la contraseña es correcta
        var result = await _userManager.CheckPasswordAsync(user, command.Password);
        if(!result) throw new BadRequestException("La contraseña ingresada es incorrecta");

        var roles = await _userManager.GetRolesAsync(user);
        
        return GenerateJwtToken(new UserDto
        {
            Email = user.Email,
            Id = user.Id,
            Roles = new List<string>(roles),
            FirstName = user.FirstName,
            LastName = user.LastName
        });
    }

    public async Task<UserDto> Register(RegisterUserCommand command)
    {
        // Validar que el usuario no existe
        var user = await _userManager.FindByEmailAsync(command.Email);
        if(user != null) throw new BadRequestException("El usuario ingresado ya existe");
        
        // Validar que los roles existen
        foreach (var roleName in command.Roles)
        {
            var role = await _roleManager.FindByNameAsync(roleName);
            if(role == null) throw new BadRequestException($"El rol {roleName} no existe");
        }

        // Crear el usuario
        var newUser = new ApplicationUser
        {
            FirstName = command.FirstName,
            LastName = command.LastName,
            Email = command.Email,
            UserName = command.Email
        };
        
        // Guardar el usuario
        var result = await _userManager.CreateAsync(newUser, command.Password);
        if (!result.Succeeded)
        {
            var firstError = result.Errors.FirstOrDefault();
            throw new BadRequestException(firstError?.Description ?? "Error al crear el usuario");
        }
        
        // Asignar los roles
        await _userManager.AddToRolesAsync(newUser, command.Roles);
        
        // Retornar el usuario
        return new UserDto
        {
            Email = newUser.Email,
            Id = newUser.Id,
            Roles = command.Roles,
            FirstName = newUser.FirstName,
            LastName = newUser.LastName
        };
    }
    
    private static AuthenticationResponse GenerateJwtToken(UserDto userDto)
    {
        var tokenExpirationTime = DateTime.UtcNow.AddMinutes(JwtTokenValidityMin);
        var tokenKey = Encoding.ASCII.GetBytes(Configuration.JwtKey);
        var claimsIdentity = new ClaimsIdentity(new[]
        {
            new Claim(ClaimTypes.Email, userDto.Email),
            new Claim(ClaimTypes.Name, userDto.FirstName + " " + userDto.LastName),
        });
        
        claimsIdentity.AddClaims(userDto.Roles.Select(x => new Claim("Role", x)));

        var signingCredentials =
            new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature);

        var securityTokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = claimsIdentity,
            Expires = tokenExpirationTime,
            SigningCredentials = signingCredentials
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var securityToken = tokenHandler.CreateToken(securityTokenDescriptor);
        var token = tokenHandler.WriteToken(securityToken);

        return new AuthenticationResponse
        {
            Username = userDto.Email,
            ExpiresIn = (int)tokenExpirationTime.Subtract(DateTime.Now).TotalSeconds,
            JwtToken = token
        };
    }
}