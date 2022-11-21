using BookAndMore.Author.Application.DTO;

namespace BookAndMore.Author.Application.Services;

public interface IAuthorService
{
    Task<Domain.Models.Author> GetAuthorAsync(int id);
    Task<List<Domain.Models.Author>> GetAuthorsAsync();
    Task<Domain.Models.Author> CreateAuthorAsync(Domain.Models.Author author);
    
    Domain.Models.Author UpdateAuthor(int authorId, Domain.Models.Author author);
    
    void DeleteAuthor(int id);
}