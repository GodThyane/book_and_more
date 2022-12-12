namespace BookAndMore.Authentication.Application.DTO;

public class AuthenticationResponse
{
    public string Username { get; set; } = string.Empty;
    public string JwtToken { get; set; } = string.Empty;
    public int ExpiresIn { get; set; }
}