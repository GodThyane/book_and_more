using AutoMapper;
using BookAndMore.Book.Application.DTO;
using BookAndMore.Book.Application.Features.Commands;
using BookAndMore.Book.Application.Features.Queries;
using BookAndMore.Book.Application.Services;
using BookAndMore.Book.Proxy.Author;
using MediatR;

namespace BookAndMore.Book.Application.Features.Handlers.Commands;

public class UpdateAuthorHandler : IRequestHandler<UpdateBookCommand, BookDto>
{

    private readonly IBookService _bookService;
    private readonly IMapper _mapper;
    private readonly IAuthorProxy _authorProxy;
    private readonly IMediator _mediator;

    public UpdateAuthorHandler(IBookService bookService, IMapper mapper, IAuthorProxy authorProxy, IMediator mediator)
    {
        _bookService = bookService;
        _mapper = mapper;
        _authorProxy = authorProxy;
        _mediator = mediator;
    }

    public async Task<BookDto> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
    {
        var book = _mapper.Map<Domain.Models.Book>(request.Book);
        await _authorProxy.GetAuthorAsync(book.AuthorId);
        var bookUpdated = _bookService.UpdateBook(request.Id,book);
        return await _mediator.Send(new GetBookQuery(bookUpdated.Id), cancellationToken);
    }
}