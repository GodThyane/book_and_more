namespace BookAndMore.Book.Application.Services;

public interface IBookService
{
    Task<Domain.Models.Book> GetBookAsync(int id);
    Task<IEnumerable<Domain.Models.Book>> GetBooksAsync();
    Task<Domain.Models.Book> CreateBookAsync(Domain.Models.Book book);
    Domain.Models.Book UpdateBook(int bookId, Domain.Models.Book book);
    void DeleteBook(int id);
}