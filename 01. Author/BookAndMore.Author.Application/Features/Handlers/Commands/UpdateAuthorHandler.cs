using AutoMapper;
using BookAndMore.Author.Application.DTO;
using BookAndMore.Author.Application.Features.Commands;
using BookAndMore.Author.Application.Services;
using MediatR;

namespace BookAndMore.Author.Application.Features.Handlers.Commands;

public class UpdateAuthorHandler : IRequestHandler<UpdateAuthorCommand, AuthorDto>
{

    private readonly IAuthorService _authorService;
    private readonly IMapper _mapper;

    public UpdateAuthorHandler(IAuthorService authorService, IMapper mapper)
    {
        _authorService = authorService;
        _mapper = mapper;
    }

    public Task<AuthorDto> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
    {
        var author = _mapper.Map<Domain.Models.Author>(request.Author);
        var authorUpdated = _authorService.UpdateAuthor(request.Id,author);
        return Task.FromResult(_mapper.Map<AuthorDto>(authorUpdated));
    }
}