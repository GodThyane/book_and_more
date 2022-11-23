using BookAndMore.Book.Application.DTO;
using BookAndMore.Book.Application.Features.Commands;
using BookAndMore.Book.Application.Features.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookAndMore.Book.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BookController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public Task<List<BookBaseDto>> Get()
       => _mediator.Send(new GetBooksQuery());
        
        [HttpGet("{id:int}")]
        public Task<BookDto> Get(int id)
        => _mediator.Send(new GetBookQuery(id));

        [HttpPost]
        public Task<BookDto> Post([FromBody] CreateBookCommand command)
        => _mediator.Send(command);
    }
}