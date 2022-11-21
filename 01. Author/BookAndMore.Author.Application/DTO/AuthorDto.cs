namespace BookAndMore.Author.Application.DTO;

public class AuthorBaseDto
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string? ImageUrl { get; set; }
    public DateTime? BirthDate { get; set; }
}


public class AuthorDto
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string? ImageUrl { get; set; }
    public string? Biography { get; set; }
    public DateTime? BirthDate { get; set; }
}