using AutoMapper;
using BookAndMore.Author.Application.DTO;
using BookAndMore.Author.Application.Features.Commands;
using BookAndMore.Author.Application.Services;
using MediatR;

namespace BookAndMore.Author.Application.Features.Handlers.Commands;

public class CreateAuthorHandler : IRequestHandler<CreateAuthorCommand, AuthorDto>
{

    private readonly IAuthorService _authorService;
    private readonly IMapper _mapper;

    public CreateAuthorHandler(IAuthorService authorService, IMapper mapper)
    {
        _authorService = authorService;
        _mapper = mapper;
    }

    public async Task<AuthorDto> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
    {
        var author = _mapper.Map<Domain.Models.Author>(request);
        var authorCreated = await _authorService.CreateAuthorAsync(author);
        return _mapper.Map<AuthorDto>(authorCreated);
    }
}