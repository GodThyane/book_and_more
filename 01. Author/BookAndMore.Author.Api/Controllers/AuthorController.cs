using BookAndMore.Author.Application.DTO;
using BookAndMore.Author.Application.Features.Commands;
using BookAndMore.Author.Application.Features.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookAndMore.Author.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AuthorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public Task<List<AuthorBaseDto>> Get()
       => _mediator.Send(new GetAuthorsQuery());

        [HttpGet("{id:int}")]
        public Task<AuthorDto> Get(int id)
        => _mediator.Send(new GetAuthorQuery(id));

        [HttpPost]
        public Task<AuthorDto> Post([FromBody] CreateAuthorCommand command)
            => _mediator.Send(command);
        
        [HttpPut("{id:int}")]
        public Task<AuthorDto> Put([FromBody] UpdateAuthorDto dto, int id)
            => _mediator.Send(new UpdateAuthorCommand{Id = id, Author = dto});
    }
}