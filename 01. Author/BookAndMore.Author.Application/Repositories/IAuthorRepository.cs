using BookAndMore.Commons.Application.Interfaces;

namespace BookAndMore.Author.Application.Repositories;

public interface IAuthorRepository: IRepository<Domain.Models.Author, int>
{
    
}