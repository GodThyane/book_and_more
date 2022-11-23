using BookAndMore.Commons.Application.Interfaces;

namespace BookAndMore.Book.Application.Repositories;

public interface IBookRepository : IRepository<Domain.Models.Book, int>
{
    
}