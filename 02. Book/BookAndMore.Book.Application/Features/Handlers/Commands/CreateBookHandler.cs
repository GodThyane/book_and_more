using AutoMapper;
using BookAndMore.Book.Application.DTO;
using BookAndMore.Book.Application.Features.Commands;
using BookAndMore.Book.Application.Features.Queries;
using BookAndMore.Book.Application.Services;
using BookAndMore.Book.Proxy.Author;
using MediatR;

namespace BookAndMore.Book.Application.Features.Handlers.Commands;

public class CreateBookHandler : IRequestHandler<CreateBookCommand, BookDto>
{

    private readonly IBookService _bookService;
    private readonly IMapper _mapper;
    private readonly IAuthorProxy _authorProxy;
    private readonly IMediator _mediator;

    public CreateBookHandler(IBookService bookService, IMapper mapper, IAuthorProxy authorProxy, IMediator mediator)
    {
        _bookService = bookService;
        _mapper = mapper;
        _authorProxy = authorProxy;
        _mediator = mediator;
    }


    public async Task<BookDto> Handle(CreateBookCommand request, CancellationToken cancellationToken)
    {
        var book = _mapper.Map<Domain.Models.Book>(request);
        await _authorProxy.GetAuthorAsync(book.AuthorId);
        var bookCreated = await _bookService.CreateBookAsync(book);
        return await _mediator.Send(new GetBookQuery(bookCreated.Id), cancellationToken);
    }
}