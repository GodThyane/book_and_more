﻿namespace BookAndMore.Author.Application.DTO;

public class UpdateAuthorDto
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string? Biography { get; set; }
    public string? ImageUrl { get; set; }
    public DateTime? BirthDate { get; set; }
}