using AutoMapper;
using BookAndMore.Author.Application.Repositories;
using BookAndMore.Author.Application.Services;
using BookAndMore.Commons.Application.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace BookAndMore.Author.Infrastructure.Services;

public class AuthorService : IAuthorService
{
    private readonly IAuthorRepository _authorRepository;
    private readonly IMapper _mapper;

    public AuthorService(IAuthorRepository authorRepository, IMapper mapper)
    {
        _authorRepository = authorRepository;
        _mapper = mapper;
    }

    public async Task<Domain.Models.Author> GetAuthorAsync(int id)
    {
        var author = await _authorRepository.GetByIdAsync(id);
        if(author == null)
        {
            throw new EntityNotFoundException(typeof(Domain.Models.Author), id,"id");
        }
        return author;
    }


    public async Task<List<Domain.Models.Author>> GetAuthorsAsync()
    {
        var authors = await _authorRepository.GetAllAsync();
        return await authors.ToListAsync();
    }

    public async Task<Domain.Models.Author> CreateAuthorAsync(Domain.Models.Author author)
    {
        await _authorRepository.AddAsync(author);
        await _authorRepository.SaveChangesAsync();
        return (await _authorRepository.GetByIdAsync(author.Id))!;
    }

    public Domain.Models.Author UpdateAuthor(int authorId, Domain.Models.Author author)
    {
        var authorToUpdate = _authorRepository.GetById(authorId);
        if (authorToUpdate == null)
        {
            throw new EntityNotFoundException(typeof(Domain.Models.Author), author.Id, "id");
        }
        _mapper.Map(author, authorToUpdate);
        _authorRepository.Update(authorToUpdate);
        _authorRepository.SaveChanges();
        
        return authorToUpdate;
    }

    public void DeleteAuthor(int id)
    {
        var author = _authorRepository.GetById(id);
        if (author == null)
        {
            throw new EntityNotFoundException(typeof(Domain.Models.Author), id, "id");
        }
        _authorRepository.Delete(author);
        _authorRepository.SaveChanges();
    }
}