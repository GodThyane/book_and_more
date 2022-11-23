using AutoMapper;
using BookAndMore.Book.Application.Repositories;
using BookAndMore.Book.Application.Services;
using BookAndMore.Commons.Application.Exceptions;

namespace BookAndMore.Book.Infrastructure.Services;

public class BookService : IBookService
{
    private readonly IBookRepository _bookRepository;
    private readonly IMapper _mapper;

    public BookService(IBookRepository bookRepository, IMapper mapper)
    {
        _bookRepository = bookRepository;
        _mapper = mapper;
    }

    public async Task<Domain.Models.Book> GetBookAsync(int id)
    {
        var book = await _bookRepository.GetByIdAsync(id);
        if (book == null)
        {
            throw new EntityNotFoundException(typeof(Domain.Models.Book), id, "id");
        }

        return book;
    }

    public async Task<IEnumerable<Domain.Models.Book>> GetBooksAsync()
    {
        var books = await _bookRepository.GetAllAsync();
        return books;
    }

    public async Task<Domain.Models.Book> CreateBookAsync(Domain.Models.Book book)
    {
        await _bookRepository.AddAsync(book);
        await _bookRepository.SaveChangesAsync();
        return (await _bookRepository.GetByIdAsync(book.Id))!;
    }

    public Domain.Models.Book UpdateBook(int bookId, Domain.Models.Book book)
    {
        var bookToUpdate = _bookRepository.GetById(bookId);
        if (bookToUpdate == null)
        {
            throw new EntityNotFoundException(typeof(Domain.Models.Book), book.Id, "id");
        }
        _mapper.Map(book, bookToUpdate);
        _bookRepository.Update(bookToUpdate);
        _bookRepository.SaveChanges();
        
        return bookToUpdate;
    }

    public void DeleteBook(int id)
    {
        var book = _bookRepository.GetById(id);
        if (book == null)
        {
            throw new EntityNotFoundException(typeof(Domain.Models.Book), id, "id");
        }
        _bookRepository.Delete(book);
        _bookRepository.SaveChanges();
    }
}