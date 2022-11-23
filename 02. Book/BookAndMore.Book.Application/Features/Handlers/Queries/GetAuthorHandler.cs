using AutoMapper;
using BookAndMore.Book.Application.DTO;
using BookAndMore.Book.Application.Features.Queries;
using BookAndMore.Book.Application.Services;
using BookAndMore.Book.Proxy.Author;
using MediatR;

namespace BookAndMore.Book.Application.Features.Handlers.Queries;

public class GetAuthorHandler : IRequestHandler<GetBookQuery, BookDto>
{
    private readonly IBookService _bookService;
    private readonly IMapper _mapper;
    private readonly IAuthorProxy _authorProxy;

    public GetAuthorHandler(IMapper mapper, IBookService bookService, IAuthorProxy authorProxy)
    {
        _mapper = mapper;
        _bookService = bookService;
        _authorProxy = authorProxy;
    }

    public async Task<BookDto> Handle(GetBookQuery request, CancellationToken cancellationToken)
    {
        var book = await _bookService.GetBookAsync(request.Id);
        var author = await _authorProxy.GetAuthorAsync(book.AuthorId);
        var bookDto = _mapper.Map<BookDto>(book);
        bookDto.Author = author;
        return bookDto;
    }
}

public class GetAuthorsHandler : IRequestHandler<GetBooksQuery, List<BookBaseDto>>
{
    private readonly IBookService _bookService;
    private readonly IMapper _mapper;

    public GetAuthorsHandler(IBookService bookService, IMapper mapper)
    {
        _bookService = bookService;
        _mapper = mapper;
    }

    public async Task<List<BookBaseDto>> Handle(GetBooksQuery request, CancellationToken cancellationToken)
    {
        var books = await _bookService.GetBooksAsync();
        return _mapper.Map<List<BookBaseDto>>(books);
    }
}