namespace BookAndMore.Commons.Application.Config;

public static class Configuration
{
    public static readonly string JwtKey = Environment.GetEnvironmentVariable("JWT_KEY")!;
}