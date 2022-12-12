using BookAndMore.Commons.Domain.Models;

namespace BookAndMore.Authentication.Application.DTO;

public class UserDto : DatabaseObj<string>
{
    public string Email { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public List<string> Roles { get; set; } = new();
}