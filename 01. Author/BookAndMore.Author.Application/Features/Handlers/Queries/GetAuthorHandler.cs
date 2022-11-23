using AutoMapper;
using BookAndMore.Author.Application.DTO;
using BookAndMore.Author.Application.Features.Queries;
using BookAndMore.Author.Application.Services;
using MediatR;

namespace BookAndMore.Author.Application.Features.Handlers.Queries;

public class GetAuthorHandler : IRequestHandler<GetAuthorQuery, AuthorDto>
{

    private readonly IAuthorService _authorService;
    private readonly IMapper _mapper;

    public GetAuthorHandler(IAuthorService authorService, IMapper mapper)
    {
        _authorService = authorService;
        _mapper = mapper;
    }

    public async Task<AuthorDto> Handle(GetAuthorQuery request, CancellationToken cancellationToken)
    {
        var author = await _authorService.GetAuthorAsync(request.Id);
        return _mapper.Map<AuthorDto>(author);
    }
}

public class GetAuthorsHandler : IRequestHandler<GetAuthorsQuery, List<AuthorBaseDto>>
{

    private readonly IAuthorService _authorService;
    private readonly IMapper _mapper;

    public GetAuthorsHandler(IAuthorService authorService, IMapper mapper)
    {
        _authorService = authorService;
        _mapper = mapper;
    }

    public async Task<List<AuthorBaseDto>> Handle(GetAuthorsQuery request, CancellationToken cancellationToken)
    {
        var authors = await _authorService.GetAuthorsAsync();
        return _mapper.Map<List<AuthorBaseDto>>(authors);
        
    }
}