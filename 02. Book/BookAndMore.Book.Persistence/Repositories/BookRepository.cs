using BookAndMore.Book.Application.Repositories;
using BookAndMore.Commons.Persistance.Repositories;

namespace BookAndMore.Book.Persistence.Repositories;

public class BookRepository : BaseRepository<Domain.Models.Book, BookContext, int>, IBookRepository
{
    public BookRepository(BookContext context) : base(context)
    {
    }
}