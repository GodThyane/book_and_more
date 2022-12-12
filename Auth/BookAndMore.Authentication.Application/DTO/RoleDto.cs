using BookAndMore.Commons.Domain.Models;

namespace BookAndMore.Authentication.Application.DTO;

public class RoleDto : DatabaseObj<string>
{
    public string Name { get; set; } = default!;
}